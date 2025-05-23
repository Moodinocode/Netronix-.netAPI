using Microsoft.EntityFrameworkCore;
using Netronix.API.Data;
using Netronix.API.Models.Domains;

namespace Netronix.API.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly NetronixDbContext dbContext;

        public SQLProductRepository(NetronixDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetBestSellersAsync()
        {
            return await dbContext.Products.Where(x => x.IsBestSeller == true).ToListAsync();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
