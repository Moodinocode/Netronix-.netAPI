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
       // [Route("list")]
        public async Task<IActionResult> list()
        {
            var productsDomainModel = await productRepository.GetAllAsync();
            return Ok(mapper.Map<List<ProductDto>>(productsDomainModel));
            
        }

        [HttpGet]
        [Route("bestSellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var productsDomainModel = await productRepository.GetBestSellersAsync();
                
            var productsdto = new List<ProductDto>();
            foreach (var product in productsDomainModel)
            {
                var productdto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    brand = product.brand,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrls = product.ImageUrls,
                    IsBestSeller = product.IsBestSeller,
                    Variants = product.Variants,
                    ProductTags = product.ProductTags,
                    DateCreated = product.DateCreated,
                    Inventory = product.Inventory
                };
                productsdto.Add(productdto);
            }
            return Ok(productsdto);
        }

        [HttpGet]
        [Route("featured")]
        public async Task<IActionResult> GetTags(int id) {
            return Ok(new { message = "Tags" });
        }

        [HttpGet]
        [Route("productsbytag")]
        public async Task<IActionResult> GetProductsbyTag(int id) {
            return Ok(new { message = "Products with given tag" });
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProductbyId([FromRoute] Guid id) {
            return Ok(new { message = "Product with given id" });
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
