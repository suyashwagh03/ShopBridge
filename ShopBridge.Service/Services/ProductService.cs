using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ShopBridge.Model;
using ShopBridge.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopBridge.Service.Services
{
    public class ProductService : IProductService
    {
        public HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Product> GetAsync(int id)
        {
            try
            {
                var url = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", "Product", id);

                var response = await _client.GetAsync(url);

                if (response.StatusCode == (HttpStatusCode)404)
                {
                    return null;
                }
                else
                {
                    var responseContetnt = await response.Content.ReadAsStringAsync();

                    return await Task.Run(() => JsonConvert.DeserializeObject<Product>(responseContetnt, new IsoDateTimeConverter { Culture = new CultureInfo("en-GB") }));
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var url = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", "Product", "all");

                var response = await _client.GetAsync(url);

                var responseContetnt = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Product>>(responseContetnt, new IsoDateTimeConverter { Culture = new CultureInfo("en-GB") }));
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<Product> AddAsync(Product entity)
        {
            try
            {

                var url = string.Format(CultureInfo.InvariantCulture, "{0}", "Product");

                var content = JsonConvert.SerializeObject(entity);

                var response = await _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));

                var responseContetnt = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<Product>(responseContetnt, new IsoDateTimeConverter { Culture = new CultureInfo("en-GB") }));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var url = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", "Product", id);

                await _client.DeleteAsync(url);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
