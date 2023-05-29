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
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            IEnumerable<Order> orders = _orderRepository.GetAll();
            return orders.Select(MapOrderToDTO);
        }

        public OrderDTO GetOrderById(int id)
        {
            Order order = _orderRepository.GetById(id);
            return MapOrderToDTO(order);
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            Order order = MapDTOToOrder(orderDTO);
            _orderRepository.Add(order);
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            Order existingOrder = _orderRepository.GetById(orderDTO.Id);
            if (existingOrder != null)
            {
               
                // Update other properties
                _orderRepository.Update(existingOrder);
            }
        }

        public void DeleteOrder(int id)
        {
            Order order = _orderRepository.GetById(id);
            if (order != null)
            {
                _orderRepository.Delete(order);
            }
        }

        private OrderDTO MapOrderToDTO(Order order)
        {
            if (order == null)
                return null;

            return new OrderDTO
            {
                Id = order.OrderId,
               
                // Map other properties
            };
        }

        private Order MapDTOToOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null)
                return null;

            return new Order
            {
                OrderId = orderDTO.Id,
                
                // Map other properties
            };
        }
    }
}
