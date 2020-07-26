using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<Product> AddAsync(Product entity);
        Task<IEnumerable<Product>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
