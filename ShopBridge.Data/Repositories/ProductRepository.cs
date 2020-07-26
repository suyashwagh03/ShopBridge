using ShopBridge.Data.Interfaces;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(int id)
        {
            var result = _context.Products.FirstOrDefault(x => x.Id == id);

            return await Task.Run(() => result);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = _context.Products.ToList();

            return await Task.Run(() => result);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return _context.Entry(entity).Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = _context.Products.Find(id);

            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
