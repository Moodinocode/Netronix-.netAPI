using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
 
        public productController(IProductRepository productRepository,IMapper mapper)
        {
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
        [Route("tag/{Tagid:Guid}")]
        public async Task<IActionResult> GetProductsbyTag([FromRoute] Guid Tagid) {
           var productsDomainModel = await productRepository.GetProductsByTagAsync(Tagid);
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
        [Authorize(Roles = "Admin,Ops")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequestDto addProductRequestDto) {
            var product = await productRepository.AddProductAsync(mapper.Map<Product>(addProductRequestDto));
            return Ok(mapper.Map<ProductDto>(product));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,Ops")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id) {
            var product = await productRepository.DeleteProductAsync(id);
            if (product == null) {
                return NotFound();
            }
            return Ok(mapper.Map<ProductDto>(product));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,Ops")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductRequestDto productRequestDto) {
            var product = mapper.Map<Product>(productRequestDto);
            product = await productRepository.UpdateProductAsync(id,product);
            if (product == null) {
                return NotFound();
            }
            return Ok(mapper.Map<ProductDto>(product)); 
        }




    }
}
