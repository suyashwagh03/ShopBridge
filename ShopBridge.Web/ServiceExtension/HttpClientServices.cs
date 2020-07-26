using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Web.ServiceExtension
{
    public static class HttpClientServices
    {
        public static IServiceCollection AddHttpClientApplicationServices (this IServiceCollection services, 
            Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddHttpClient<ProductService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:54616/api/");
            });

            return services;
        }
    }
}
