using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netronix.API.Models.DTOs;
using Netronix.API.Repositories;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;

        public orderController(IMapper mapper, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }
        [HttpPost]
        [Route("user/{Userid:Guid}")]
        public async Task<IActionResult> CreateOrder([FromRoute] Guid Userid)
        {
            // This is a placeholder for the actual implementation
            return Ok(new { message = "Order created" });
        }
       [HttpPost]
        public async Task<IActionResult> CreateOrderGuest()//might keep it same and make it based on the dto
        {
            // This is a placeholder for the actual implementation
            return Ok(new { message = "Order created" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders() {
            return Ok(await orderRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id) {
            return Ok(await orderRepository.GetByIdAsync(id));
        }
        [HttpGet]
        [Route("user/{Userid:Guid}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] Guid Userid) {
            return Ok(new { message = "Order by user ID" });
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid id) {
            return Ok(new { message = "Updated Order Status" });
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            var deletedOrder = await orderRepository.DeleteAsync(id);
            if (deletedOrder == null) return NotFound();
            return Ok(mapper.Map<OrderDto>(deletedOrder));
        }
    }
}
