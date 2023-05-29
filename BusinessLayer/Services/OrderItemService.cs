using BusinessLayer.DTO;
using DataAcessLayer.Models;
using DataAcessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrderItemService
    {
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderItemService(IRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public IEnumerable<OrderItemDTO> GetAllOrderItems()
        {
            IEnumerable<OrderItem> orderItems = _orderItemRepository.GetAll();
            return orderItems.Select(MapOrderItemToDTO);
        }

        public OrderItemDTO GetOrderItemById(int id)
        {
            OrderItem orderItem = _orderItemRepository.GetById(id);
            return MapOrderItemToDTO(orderItem);
        }

        public void AddOrderItem(OrderItemDTO orderItemDTO)
        {
            OrderItem orderItem = MapDTOToOrderItem(orderItemDTO);
            _orderItemRepository.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItemDTO orderItemDTO)
        {
            OrderItem existingOrderItem = _orderItemRepository.GetById(orderItemDTO.Id);
            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity = orderItemDTO.Quantity;
                // Update other properties
                _orderItemRepository.Update(existingOrderItem);
            }
        }

        public void DeleteOrderItem(int id)
        {
            OrderItem orderItem = _orderItemRepository.GetById(id);
            if (orderItem != null)
            {
                _orderItemRepository.Delete(orderItem);
            }
        }

        private OrderItemDTO MapOrderItemToDTO(OrderItem orderItem)
        {
            if (orderItem == null)
                return null;

            return new OrderItemDTO
            {
                Id = orderItem.OrderItemId,
                Quantity = orderItem.Quantity,
                // Map other properties
            };
        }

        private OrderItem MapDTOToOrderItem(OrderItemDTO orderItemDTO)
        {
            if (orderItemDTO == null)
                return null;

            return new OrderItem
            {
                OrderItemId = orderItemDTO.Id,
                Quantity = orderItemDTO.Quantity,
                // Map other properties
            };
        }
    }
}
