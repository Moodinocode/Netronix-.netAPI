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
            var productId = Guid.NewGuid();
            product.Id = productId;
            product.DateCreated = DateTime.UtcNow;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProductAsync(Guid id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return null;
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetBestSellersAsync()
        {
            return await dbContext.Products.Where(x => x.IsBestSeller == true).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var product = await  dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return null;
            return product;
        }

        public async Task<List<Product>> GetProductsByTagAsync(Guid id)
        {
           return await dbContext.Products
                .Where(p => p.ProductTags.Any(pt => pt.TagId == id))
                .ToListAsync();
        }


        public async Task<Product?> UpdateProductAsync(Guid id,Product product)
        {
            var existing = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existing == null) return null;
            existing.Name = product.Name;
            existing.brand = product.brand;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.ImageUrls = product.ImageUrls;
            existing.IsBestSeller = product.IsBestSeller;
            existing.Variants = product.Variants;
            existing.ProductTags = product.ProductTags;
            existing.Inventory = product.Inventory;
            await dbContext.SaveChangesAsync();
            return existing;


        }
    }
}
