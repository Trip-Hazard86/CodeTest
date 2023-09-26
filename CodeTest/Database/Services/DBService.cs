using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Database.Services
{
    public class DBService : Database
    {
        //Go-between w/code and db
        //Methods for CRUD operations
        //Consider mem. management
        public DBService() { }

        public void AddSingle(Customer customer)
        {
            using (Database context = new Database())
            {
                context.Customers.Add(customer);
                //write operation req. saving changes
                context.SaveChanges();
            }
        }

        public void AddMultiple(List<Customer> customers)
        {
            using (Database context = new Database())
            {
                foreach (Customer customer in customers)
                {
                    context.Customers.Add(customer);
                }
                context.SaveChanges();
            }
        }

        public List<Customer> GetEntries()
        {
            using (Database context = new Database())
            {
                return context.Customers.ToList();
            }
        }

        public Customer GetCustomer(int id)
        {
            using (Database context = new Database())
            {
                return context.Customers.FirstOrDefault(c => c.Id == id);
            }
        }

        //Update customer
        public void Update(Customer customer)
        {
            using (Database context = new Database())
            {
                Customer existingCustomer = context.Customers.FirstOrDefault(
                    c => c.Id == customer.Id);

                //assuming record was found
                if (customer != null)
                {
                    existingCustomer.Id = customer.Id;
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.PhoneNumber = customer.PhoneNumber;
                    existingCustomer.Postcode = customer.Postcode;

                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {            
            using (Database context = new Database())
            {
                //retrieve & store record which matches id
                Customer customer = context.Customers.FirstOrDefault(
                    entry => entry.Id == id);

                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        }
    }
}
