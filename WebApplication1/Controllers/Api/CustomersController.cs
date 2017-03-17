using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DAL;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository _customers;
        private IMembershipTypeRepository _memberships;
        public CustomersController()
        {
            StudContext _context = new StudContext();
            CustomerRepository customers = new CustomerRepository(_context);//JsonCustomerRepository or CustomerRepository
            MembershipTypesRepository memberships = new MembershipTypesRepository(_context);
            _customers = customers;
            _memberships = memberships;
        }

        public IHttpActionResult GetCustomers()//GET Customers
        {
            var customers=_customers.GetAllCustomers();
            if (customers.Count == 0)
            {
                return NotFound();
            }
            return Ok(customers.Select(Mapper.Map<Customer, CustomerDto>));
        }

        public IHttpActionResult GetCustomer(int id)//GET Customers/1
        {
            var customer=_customers.GetById(id);
            if(customer==null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)//POST
        {
            if (!ModelState.IsValid)
            {
               return BadRequest();
            }
            var customer=Mapper.Map<CustomerDto, Customer>(customerDto);
            _customers.Add(customer);

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id), customerDto);
        }

        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)//PUT
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            try
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _customers.Update(customer);
                
            }
            catch
            {
                return NotFound();
            }
            return Ok(customerDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _customers.GetById(id);

            if (customerInDb == null)
            {
                return NotFound();
            }
            _customers.Delete(customerInDb);
            return Ok();
        }
    }
}
