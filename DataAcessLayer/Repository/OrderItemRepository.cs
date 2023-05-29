using DataAcessLayer.Database;
using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
   public class OrderItemRepository : IRepository<OrderItem>
    {
        private readonly AppDbContext _dbContext;

        public OrderItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return _dbContext.OrderItems.ToList();
        }

        public OrderItem GetOrderItemById(int orderItemId)
        {
            return _dbContext.OrderItems
                .FirstOrDefault(oi => oi.OrderItemId == orderItemId);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);
            _dbContext.SaveChanges();
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Remove(orderItem);
            _dbContext.SaveChanges();
        }

        public IEnumerable<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
