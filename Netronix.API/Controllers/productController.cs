using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            // This is a placeholder for the actual implementation
            return Ok(new { message = "List of products" });
        }

       [HttpGet]
       [Route("bestSellers")]
       public IActionResult GetBestSellers(int id) 
        {
            return Ok(new { message = "Best Sellers" });
        }

       [HttpGet]
       [Route("featured")]
        public IActionResult GetTags(int id) {
            return Ok(new { message = "Tags" });
        }

        [HttpGet]
        [Route("productsbytag")]
        public IActionResult GetProductsbyTag(int id) {
            return Ok(new { message = "Products with given tag" });
        }

        [HttpGet]
        [Route("productbyid")]
        public IActionResult GetProductbyId(int id) {
            return Ok(new { message = "Product with given id" });
        }

        [HttpPost] 
        [Route("addproduct")]
        public IActionResult AddProduct() {
            return Ok(new { message = "Product Added" });
        }

        [HttpDelete]
            [Route("deleteproduct")]
        public IActionResult DeleteProduct(int id) {
            return Ok(new { message = "Product Deleted" });
        }

        [HttpPut]
        [Route("updateproduct")]
        public IActionResult UpdateProduct(int id) {
        return Ok(new { message = "Best Sellers" });}




    }
}
