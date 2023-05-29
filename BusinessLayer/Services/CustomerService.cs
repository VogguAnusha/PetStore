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
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            IEnumerable<Customer> customers = _customerRepository.GetAll();
            return MapCustomersToDTOs(customers);
        }

        public CustomerDTO GetCustomerById(int id)
        {
            Customer customer = _customerRepository.GetById(id);
            return MapCustomerToDTO(customer);
        }

        public void AddCustomer(CustomerDTO customerDTO)
        {
            Customer customer = MapDTOToCustomer(customerDTO);
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(CustomerDTO customerDTO)
        {
            Customer existingCustomer = _customerRepository.GetById(customerDTO.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customerDTO.Name;
                existingCustomer.Email = customerDTO.Email;
                // Update other properties
                _customerRepository.Update(existingCustomer);
            }
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = _customerRepository.GetById(id);
            if (customer != null)
            {
                _customerRepository.Delete(customer);
            }
        }

        private CustomerDTO MapCustomerToDTO(Customer customer)
        {
            if (customer == null)
                return null;

            return new CustomerDTO
            {
                Id = customer.CustomerId,
                Name = customer.FirstName,
                Email = customer.Email,
                // Map other properties
            };
        }

        private IEnumerable<CustomerDTO> MapCustomersToDTOs(IEnumerable<Customer> customers)
        {
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

            if (customers != null)
            {
                foreach (Customer customer in customers)
                {
                    customerDTOs.Add(MapCustomerToDTO(customer));
                }
            }

            return customerDTOs;
        }

        private Customer MapDTOToCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
                return null;

            return new Customer
            {
                CustomerId = customerDTO.Id,
                FirstName = customerDTO.Name,
                Email = customerDTO.Email,
                // Map other properties
            };
        }
    }
}

