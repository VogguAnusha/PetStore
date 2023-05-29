using BusinessLayer.DTO;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace PetStoreMangement.Controllers
{
    [Route("api/orderitems")]
    [ApiController]
    public class OrderItemController : Controller
    {
        private readonly OrderItemService _orderItemService;

        public OrderItemController(OrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderItemDTO>> GetAllOrderItems()
        {
            IEnumerable<OrderItemDTO> orderItems = _orderItemService.GetAllOrderItems();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderItemDTO> GetOrderItemById(int id)
        {
            OrderItemDTO orderItem = _orderItemService.GetOrderItemById(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpPost]
        public ActionResult CreateOrderItem(OrderItemDTO orderItemDTO)
        {
            _orderItemService.AddOrderItem(orderItemDTO);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItemDTO.Id }, orderItemDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderItem(int id, OrderItemDTO orderItemDTO)
        {
            if (id != orderItemDTO.Id)
            {
                return BadRequest();
            }

            _orderItemService.UpdateOrderItem(orderItemDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderItem(int id)
        {
            _orderItemService.DeleteOrderItem(id);
            return NoContent();
        }



    }
}
