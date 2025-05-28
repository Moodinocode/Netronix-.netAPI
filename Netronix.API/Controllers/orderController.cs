using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netronix.API.Models.Domains;
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
        private readonly IProductRepository productRepository;

        public orderController(IMapper mapper, IOrderRepository orderRepository,IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromQuery] Guid? Userid, CreateOrderDto createOrderDto)
        {
            var items = new List<OrderItem>();
            foreach (var item in createOrderDto.items)
            {
                var newItem =new OrderItem
                {
                    product = await productRepository.GetByIdAsync(item.productID),
                    Quantity = item.Quantity
                };
                if (newItem.product == null) return BadRequest();
                items[createOrderDto.items.IndexOf(item)] = newItem;
            }

            var order = mapper.Map<Order>(createOrderDto);
            order.items = items;
            if (Userid.HasValue)
            {
                order.CustomerId = Userid.Value;
                order.IsGuestOrder = false;
            }
            else
            {
                order.IsGuestOrder = true;
            }
            return Ok(await orderRepository.CreateAsync(order));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllOrders() {
            return Ok(await orderRepository.GetAllAsync());
        }
        
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id) {
            var result = await orderRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        [HttpGet]
        [Route("user/{Userid:Guid}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] Guid Userid) {
            return Ok(new { message = "Order by user ID" });
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid id,UpdateOrderRequestDto updateOrderRequestDto) {
            var items = new List<OrderItem>();
            foreach (var item in updateOrderRequestDto.items)
            {
                var newItem = new OrderItem
                {
                    product = await productRepository.GetByIdAsync(item.productID),
                    Quantity = item.Quantity
                };
                if (newItem.product == null) return BadRequest();
                items[updateOrderRequestDto.items.IndexOf(item)] = newItem;
            }

            var order = mapper.Map<Order>(updateOrderRequestDto);
            order.items = items;

            var result = await orderRepository.UpdateAsync(id, order);
            if (result == null) return NotFound();


            return Ok(result);
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
