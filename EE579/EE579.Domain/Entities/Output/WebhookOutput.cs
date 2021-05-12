using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace EE579.Domain.Entities.Output
{
    public class WebhookOutput : RuleOutput
    {
        public WebhookOutput()
            : base(OutputType.Webhook) { }

        public string Url { get; set; }
        public bool ForwardMessage { get; set; }

        public override async Task SendOutputMessage(object messageBody = null, HttpContext httpContext = null)
        {
            using var client = new HttpClient();

            if (!ForwardMessage)
            {
                await client.PostAsync(Url, new StringContent("", Encoding.UTF8, "application/json"));
                return;
            }

            //if (httpContext != null)
            //{
            //    foreach (var (key, value) in httpContext?.Request.Headers)
            //    {
            //        client.DefaultRequestHeaders.Add(key, value.ToString());
            //    }
            //}
            try
            {
                var body = JsonSerializer.Serialize(messageBody);
                await client.PostAsJsonAsync(Url, messageBody);
                return;
            }
            catch (Exception) { }
            
            await client.PostAsJsonAsync(Url, "{}");
        }
    }
}
