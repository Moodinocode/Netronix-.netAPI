using Microsoft.EntityFrameworkCore;
using Netronix.API.Data;
using Netronix.API.Models.Domains;

namespace Netronix.API.Repositories
{
    public class SQLTagRepository : ITagRepository
    {
        private readonly NetronixDbContext dbContext;

        public SQLTagRepository(NetronixDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            tag.Id = Guid.NewGuid();
            await dbContext.Tags.AddAsync(tag);
            await dbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteTagAsync(Guid id)
        {
            var existing = await dbContext.Tags.FirstOrDefaultAsync(p => p.Id == id);
            if (existing == null) return null;
            dbContext.Tags.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await dbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> UpdateTagAsync(Guid id, Tag tag)
        {
            var existing = await dbContext.Tags.FirstOrDefaultAsync(p => p.Id == id);
            if (existing == null) return null;
            existing.Name = tag.Name;
            existing.ProductTags = tag.ProductTags;
            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
