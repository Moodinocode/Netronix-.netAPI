using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        [HttpPost]
        [Route("create-order")]
        public IActionResult CreateOrder()
        {
            // This is a placeholder for the actual implementation
            return Ok(new { message = "Order created" });
        }
       [HttpPost]
       [Route("create-order-guest")]
        public IActionResult CreateOrderGuest()//might keep it same and make it based on the dto
        {
            // This is a placeholder for the actual implementation
            return Ok(new { message = "Order created" });
        }
        [HttpGet]
        [Route("get-order-status")]
        public IActionResult GetAllOrders() {
            return Ok(new { message = "All Orders" });
        }
        [HttpGet]
        [Route("get-order-status/{id}")]
        public IActionResult GetOrderById(int id) {
            return Ok(new { message = "Order by ID" });
        }
        [HttpGet]
        [Route("get-order-status-by-user/{id}")]
        public IActionResult GetOrdersByUserId(int id) {
            return Ok(new { message = "Order by user ID" });
        }

        [HttpPost]
        [Route("update-order-status/{id}")]
        public IActionResult UpdateOrderStatus(int id) {
            return Ok(new { message = "Updated Order Status" });
        }
    }
}
