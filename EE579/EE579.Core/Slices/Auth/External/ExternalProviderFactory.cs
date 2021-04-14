using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EE579.Core.Slices.Auth.External
{
    public class ExternalProviderFactory : IExternalProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ExternalProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IExternalProvider GetProvider(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var decoded = tokenHandler.ReadJwtToken(token);

            var externalProviders = _serviceProvider.GetServices<IExternalProvider>();
            var provider = externalProviders.FirstOrDefault(x => x.IssuedToken(decoded.Issuer));

            return provider;
        }
    }
}
