using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netronix.API.Data;
using Netronix.API.Models.Domains;
using Netronix.API.Models.DTOs;
using Netronix.API.Repositories;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;

        public TagsController(ITagRepository tagRepository,IMapper mapper)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags() {
            var tags = await tagRepository.GetTagsAsync();
            return Ok(mapper.Map<List<TagDto>>(tags));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagDto createTagDto)
        {
            var tag = await tagRepository.AddTagAsync(mapper.Map<Tag>(createTagDto));
            return Ok(mapper.Map<TagDto>(tag));
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTag([FromRoute] Guid id, [FromBody] UpdateTagDto updateTagDto)
        {
            var tag = await tagRepository.UpdateTagAsync(id,mapper.Map<Tag>(updateTagDto));
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TagDto>(tag));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTag([FromRoute] Guid id)
        {
            var tag = await tagRepository.DeleteTagAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TagDto>(tag));
        }

    }
}
