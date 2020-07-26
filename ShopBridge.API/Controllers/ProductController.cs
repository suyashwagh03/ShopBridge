using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Data.Interfaces;
using ShopBridge.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _productRepository.GetAsync(id);

            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Product entity)
        {
            var result = await _productRepository.AddAsync(entity);

            return Created(result.ToString(), result);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync (int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
