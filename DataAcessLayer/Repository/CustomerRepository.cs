using DataAcessLayer.Database;
using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
