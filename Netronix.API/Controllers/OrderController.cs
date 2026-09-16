using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netronix.API.Models.Domains;
using Netronix.API.Models.DTOs;
using Netronix.API.Repositories;
using System.Text.Json;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderController(IMapper mapper, IOrderRepository orderRepository,IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromQuery] Guid? Userid, CreateOrderDto createOrderDto)
        {
            var Createditems = new List<OrderItem>();
            foreach(var item in createOrderDto.items)
            {

                var product = await productRepository.GetByIdAsync(item.productId);
                if (product == null) return BadRequest("Product not found");


                var newItem = mapper.Map<OrderItem>(item);
                newItem.product = product;
                newItem.ProductName = product.Name;

                var newSelectedOptions = new List<SelectedVariantOption>();
                newItem.Id = Guid.NewGuid(); 
                
                for (int i = 0; i < item.SelectedOptions.Count; i++) 
                {
                    SelectedVariantsDto? option = item.SelectedOptions[i];
                    var newoption = new SelectedVariantOption
                  {
                      Id = Guid.NewGuid(),
                      ProductVariantId = option.ProductVariantId,
                      VariantOptionID = option.VariantOptionID,
                      VariantName = product.Variants
                          .FirstOrDefault(v => v.Id == option.ProductVariantId)?.Name,
                      OptionValue = product.Variants
                          .FirstOrDefault(v => v.Id == option.ProductVariantId)?
                             .Options.FirstOrDefault(o => o.Id == option.VariantOptionID)?.Value,
                      PriceAdjustment = product.Variants
                        .FirstOrDefault(v => v.Id == option.ProductVariantId)?
                            .Options.FirstOrDefault(o => o.Id == option.VariantOptionID)?.PriceAdjustment ?? 0
                  };
                    newSelectedOptions.Add(newoption);
                }
                newItem.SelectedOptions = newSelectedOptions;
                newItem.UnitPrice = product.BasePrice + newSelectedOptions.Sum(x => x.PriceAdjustment);
                Createditems.Add(newItem);
                
            }

            var order = new Order
            {
                DeliveryFee = createOrderDto.DeliveryFee,
                ShippingAddress = mapper.Map<Adress>(createOrderDto.ShippingAddress),
                PaymentMethod = createOrderDto.PaymentMethod,
                items = Createditems
                
            };
            if (Userid.HasValue)
            {
                order.CustomerId = Userid.Value;
                order.IsGuestOrder = false;
            }
            else
            {
                order.IsGuestOrder = true;
            }
            var result = await orderRepository.CreateAsync(order);
            return Ok(mapper.Map<OrderDto>(result));
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin,Ops")]
        public async Task<IActionResult> GetAllOrders() {
            var orders = await orderRepository.GetAllAsync();
            return Ok(mapper.Map<List<OrderDto>>(orders));
        }
        
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id) {
            var result = await orderRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(mapper.Map<OrderDto>(result));
        }
        
        [HttpGet]
        [Route("user/{Userid:Guid}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] Guid Userid) {
            var orders = await orderRepository.GetOrdersByUserIdAsync(Userid);
            return Ok(mapper.Map<List<OrderDto>>(orders));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,Ops")]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid id,UpdateOrderRequestDto updateOrderRequestDto) {
            //var items = new List<OrderItem>();
            //foreach (var item in updateOrderRequestDto.items)
            //{
            //    var newItem = new OrderItem
            //    {
            //        product = await productRepository.GetByIdAsync(item.productID),
            //        Quantity = item.Quantity
            //    };
            //    if (newItem.product == null) return BadRequest();
            //    items[updateOrderRequestDto.items.IndexOf(item)] = newItem;
            //}

            var order = mapper.Map<Order>(updateOrderRequestDto);
            //order.items = items;

            var result = await orderRepository.UpdateAsync(id, order);
            if (result == null) return NotFound();

            return Ok(mapper.Map<OrderDto>(result));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,Ops")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            var deletedOrder = await orderRepository.DeleteAsync(id);
            if (deletedOrder == null) return NotFound();
            return Ok(mapper.Map<OrderDto>(deletedOrder));
        }
    }
}
