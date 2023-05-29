using DataAcessLayer.Database;
using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderId == orderId);
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
