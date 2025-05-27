using Netronix.API.Models.Domains;

namespace Netronix.API.Repositories
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTagsAsync();
        Task<Tag> AddTagAsync(Tag tag);
        Task<Tag?> UpdateTagAsync(Guid id, Tag tag);
        Task<Tag?> DeleteTagAsync(Guid id);
    }
}
