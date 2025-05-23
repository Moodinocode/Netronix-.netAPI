using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netronix.API.Data;
using Netronix.API.Models.Domains;
using Netronix.API.Models.DTOs;
using Netronix.API.Repositories;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly NetronixDbContext dbContext;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public productController(NetronixDbContext dbContext, IProductRepository productRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsDomainModel = await productRepository.GetAllAsync();
            return Ok(mapper.Map<List<ProductDto>>(productsDomainModel));
            
        }

        [HttpGet]
        [Route("bestSellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var productsDomainModel = await productRepository.GetBestSellersAsync();
            return Ok(mapper.Map<List<ProductDto>>(productsDomainModel));
        }

        [HttpGet]
        [Route("tags")]
        public async Task<IActionResult> GetTags() {
            var tags = await productRepository.GetTagsAsync();
            return Ok(mapper.Map<List<TagDtocs>>(tags));
        }

        [HttpGet]
        [Route("tags/{id:Guid}")]
        public async Task<IActionResult> GetProductsbyTag([FromRoute] Guid id) {
            var productsDomainModel = await productRepository.GetProductsByTagAsync(id);
            return Ok(mapper.Map<List<ProductDto>>(productsDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProductbyId([FromRoute] Guid id) {
            var productDomainModel = await productRepository.GetByIdAsync(id);
            if (productDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ProductDto>(productDomainModel));
        }

        [HttpPost] 
        [Route("addproduct")]
        public async Task<IActionResult> AddProduct() {
            return Ok(new { message = "Product Added" });
        }

        [HttpDelete]
            [Route("deleteproduct")]
        public async Task<IActionResult> DeleteProduct(int id) {
            return Ok(new { message = "Product Deleted" });
        }

        [HttpPut]
        [Route("updateproduct")]
        public async Task<IActionResult> UpdateProduct(int id) {
        return Ok(new { message = "Best Sellers" });}




    }
}
