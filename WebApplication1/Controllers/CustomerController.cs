using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customers;
        private IMembershipTypeRepository _memberships;
        public CustomerController()
        {
            StudContext _context = new StudContext();
            CustomerRepository customers = new CustomerRepository(_context);//JsonCustomerRepository or CustomerRepository
            MembershipTypesRepository memberships = new MembershipTypesRepository(_context);
            _customers = customers;
            _memberships = memberships;
        }

        private List<Customer> getCustomers()
        {
            List<Customer> model = (List<Customer>)_customers.GetAllCustomers();
            
            return model;
        }

        
        public ActionResult Customers()
        {
            if (User.IsInRole(UserRoles.God))
            {
                return View("CustomersList");
            }
            else 
            {
                return View("ReadOnlyCustomersList");
            }
            //var model = getCustomers();
            //return View(model);              
        }


        public ActionResult Details(int id)
        {
            
            Customer model = _customers.GetById(id);
            
            if (model != null)
            {
                return View(model);
            }
            else
            {
                //return RedirectToAction("NotFound", "Errors");
                return new HttpStatusCodeResult(404);
                //return HttpNotFound();
            }

        }

        [Authorize(Roles=UserRoles.God)]
        public ActionResult CustomerForm()
        {
            var membershipTypes = _memberships.GetAllMembershipTypes();
            var viewModel=new CustomerFormViewModel("Create new customer");
            viewModel.MembershipTypes = _memberships.GetAllMembershipTypes();                
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel("Create new customer", customer);
                viewModel.MembershipTypes = _memberships.GetAllMembershipTypes();

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _customers.Add(customer);
            }
            else
            {
                
                _customers.Update(customer);
            }

            return RedirectToAction("Customers", "Customer");
        }

        public ActionResult Edit(int id)
        {
            
            Customer customer = _customers.GetById(id);

            var viewModel = new CustomerFormViewModel("Edit customer", customer);
            viewModel.MembershipTypes = _memberships.GetAllMembershipTypes();

            return View("CustomerForm", viewModel);
        }
    }
}