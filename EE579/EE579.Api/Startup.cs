using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EE579.Api.Infrastructure.Middleware;
using EE579.Api.Infrastructure.Swagger;
using EE579.Core.Infrastructure.Extensions;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.Auth.Models;
using EE579.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using EE579.Core.Slices.Users;
using EE579.Core.Slices.Users.Impl;
using EE579.Core.Slices.Auth;
using EE579.Core.Slices.Auth.External;
using EE579.Core.Slices.Auth.Impl;
using EE579.Core.Slices.DeviceGroups;
using EE579.Core.Slices.DeviceGroups.Impl;
using EE579.Core.Slices.Devices;
using EE579.Core.Slices.Email;
using EE579.Core.Slices.Tenants;
using Microsoft.IdentityModel.Tokens;
using EE579.Core.Slices.IotHub;
using EE579.Core.Slices.IotHub.Impl;
using EE579.Core.Slices.Rules;
using EE579.Domain.Entities;
using EE579.Domain.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using EE579.Core.Slices.WebHooks;
using EE579.Core.Slices.WebHooks.Impl;

namespace EE579.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<SmtpSettings>(Configuration.GetSection("AppSettings:SmtpSettings"));
            ConfigureEfCore(services);
            services.AddControllers(opts =>
                    opts.Filters.Add(new HttpStatusCodeExceptionFilter()
                ))
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EE579.Api", Version = "v1" });

                c.OperationFilter<AuthorizationOperationFilter>();
                c.OperationFilter<TenantHeaderOperationFilter>();

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme()
                    {
                        In = ParameterLocation.Header,
                        Description = "Enter a JWT to authorize - in the form 'Bearer {JWT}'",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                c.ExampleFilters();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                    .Union(new AssemblyName[] { currentAssembly.GetName() })
                    .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                    .Where(f => File.Exists(f)).ToArray();

                Array.ForEach(xmlDocs, (d) =>
                {
                    c.IncludeXmlComments(d);
                });

                c.EnableAnnotations();
                
            });

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            ConfigureAuth(services);

            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpContextAccessor();

            services.AddHostedService<IotHubWorkerService>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<ICurrentUser, CurrentUser>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IDeviceGroupService, DeviceGroupService>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<ICurrentTenant, CurrentTenant>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IRuleService, RuleService>();
            services.AddTransient<IWebHookService, WebHookService>();

            services.AddTransient<IExternalProviderFactory, ExternalProviderFactory>();

            services.AddScoped<GoogleAuthProvider>()
                .AddScoped<IExternalProvider, GoogleAuthProvider>(s => s.GetService<GoogleAuthProvider>());
            services.AddScoped<MicrosoftAuthProvider>()
                .AddScoped<IExternalProvider, MicrosoftAuthProvider>(s => s.GetService<MicrosoftAuthProvider>());

            var appSettings = Configuration.GetSection("AppSettings");
            services.AddSingleton(Configuration);
        }

        private void ConfigureEfCore(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(opts =>
                opts.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("Default")));
        }

        private void ConfigureAuth(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes("zFXaqM10Dw55jz9SZla3EHl1jhcseBSClXhE0A2Q35HtXzTfGHQiNAqOB4MOOWb");
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "394944070114-das844gmn89hk3t9npp62680n52tjtlu.apps.googleusercontent.com";
                    options.ClientSecret = "2V9Izcr_NV0aLBHCtjrwJfp4";
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var db = context.HttpContext.RequestServices.GetRequiredService<DatabaseContext>();
                            var userId = new Guid(context.Principal.Identity.Name);

                            var tenantId = context.HttpContext.GetTenantId();
                            var user = await db.Users.FindAsync(userId);
                            if (user == null || tenantId.HasValue && !await db.TenantUsers.IgnoreQueryFilters().AnyAsync(x => x.UserId == userId && x.TenantId == tenantId))
                            {
                                // return unauthorized if user no longer exists
                                context.Fail("Unauthorized");
                            }
                        }

                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false
                    };
                })
                .AddOpenIdConnect("microsoft-oidc", "Microsoft", options =>
                {
                    options.SaveTokens = true;

                    options.Authority = "https://login.microsoftonline.com/common/v2.0";
                    options.ClientId = "2cd06fdd-20cd-4981-8d9e-11862ce58b37";
                    options.ClientSecret = "6S.j186kX0Rbko.rD~b4-LVplDGA~~I3pf";
                    options.ResponseType = "id_token";
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add(OpenIdConnectScope.Email);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role",
                        ValidateIssuer = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EE579.Api v1"));

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", context => context.Response.WriteAsync("EE579 Api"));
                endpoints.MapControllers();
            });
        }
    }
}
