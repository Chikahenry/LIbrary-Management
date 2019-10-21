using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IBookRepository _bookRepository;

        public IActionResult Index()
        {
            return View();
        }
        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            var customers = _customerRepository.GetAll();
            var viewmodel = new List<CustomerViewModel>();

            if(customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var customer in customers)
            { 
                viewmodel.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepository.Count(a => a.BorrowerId == customer.CustomerId)
                });
            }

            return View(viewmodel);
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Delete(customer);
            return RedirectToAction("List");

        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);
            return RedirectToAction("List");
        }
    }
}