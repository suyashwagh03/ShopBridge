using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using ShopBridge.API;
using ShopBridge.Model;
using ShopBridge.Service.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge.Integration.Tests
{
    public class ProductTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly ProductService _productService; 
        public ProductTests(WebApplicationFactory<Startup> factory)
        {
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            client.BaseAddress = new Uri("http://localhost:54616/api/");
            _productService = new ProductService(client);
        }

        [Fact]
        public async Task Should_Add_Product_Async()
        {
            //Arrange
            Product product = new Product()
            {
                Name = "Test Name",
                Description = "Test Name Description",
                Price = 100
            };

            //Act
            var result = await _productService.AddAsync(product);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Get_Product_Async()
        {
            //Arrange
            Product product = new Product()
            {
                Name = "Test Name 1",
                Description = "Test Name 1 Description",
                Price = 100
            };

            //Act
            var addProduct = await _productService.AddAsync(product);

            var result = await _productService.GetAsync(addProduct.Id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Get_All_Products_Async()
        {
            //Arrange
            Product product = new Product()
            {
                Name = "Test Name 2",
                Description = "Test Name 2 Description",
                Price = 100
            };

            await _productService.AddAsync(product);

            //Act
            var result = await _productService.GetAllAsync();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Delete_Products_Async()
        {
            //Arrange
            Product product = new Product()
            {
                Name = "Test Name 3",
                Description = "Test Name 3 Description",
                Price = 100
            };
            var addProduct = await _productService.AddAsync(product);

            //Act
            await _productService.DeleteAsync(addProduct.Id);

            var result = await _productService.GetAsync(addProduct.Id);

            //Assert
            Assert.Null(result);
        }
    }
}
