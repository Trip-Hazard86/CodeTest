using CodeTest.Database.Services;
using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest
{
    public class TestTwo
    {
        DBService service { get; set; }
        public TestTwo()
        {
            ConsoleLog.LogHeader("Test 2 Begin");

            service = new DBService();

            this.CreateCustomers();
            this.GetFirstCustomer();
            this.UpdateSecondCustomer();
            this.RemoveThirdCustomer();
            this.RemoveAllCustomers();

            ConsoleLog.LogHeader("Test 2 End");
        }

        private void CreateCustomers()
        {
            ConsoleLog.LogSub("Test 2: Create Customers");

            //TODO: Create and add 3 customers to the database, get the customers from the database then print each of their names.            

            List<Customer> customers = new List<Customer>()
            {
                new Customer { Id = 2, Name = "Max" },
                new Customer { Id = 3, Name = "Tod" },
                new Customer { Id = 4, Name = "Kathy" },
            };

            service.AddMultiple(customers);

            var allCustomers = service.GetEntries();

            foreach (Customer customer in allCustomers)
            {
                ConsoleLog.LogResult($"Customer from DB: {customer.Name}");
            }

            ConsoleLog.LogSub("Test 2: Create Customers");
        }

        private void GetFirstCustomer()
        {
            ConsoleLog.LogSub("Test 2: Get First Customer");

            // TODO: Get the first customer added from the database.

            var firstAdded = service.GetCustomer(2);

            if (firstAdded != null)
            { 
            ConsoleLog.LogResult($"Retrieved first: {firstAdded.Name}");
            }

            ConsoleLog.LogSub("Test 2 End: Get First Customer");
        }

        private void UpdateSecondCustomer()
        {
            ConsoleLog.LogSub("Test 2: Update Second Customer");

            // TODO: Get the second customer from the database, change their name, resave it to the database then pull it back from the database and print their new name.
            var second = service.GetCustomer(3);

            second.Name = "Maude";

            service.Update(second);

            var updatedEntry = service.GetCustomer(3);

            ConsoleLog.LogResult($"Updated name: {updatedEntry.Name}");

            ConsoleLog.LogSub("Test 2 End: Update Second Customer");
        }

        private void RemoveThirdCustomer()
        {
            ConsoleLog.LogSub("Test 2: Remove Third Customer");

            // TODO: Get the third customer from the database, print their name, delete the customer, then prove it no longer exists in the database.
            var thirdCustomer = service.GetCustomer(4);

            ConsoleLog.LogResult($"Third customer name: {thirdCustomer.Name}");

            service.Delete(4);

            //prove no longer exists

            var nullEntry = service.GetCustomer(4);

            if (nullEntry == null)
            {
                ConsoleLog.LogResult("Customer was deleted");
            }
            else
            {
                ConsoleLog.LogResult("Failed to delete customer");
            }

            ConsoleLog.LogSub("Test 2 End: Remove Third Customer");
        }

        private void RemoveAllCustomers()
        {
            ConsoleLog.LogSub("Test 2: Remove All Customers");

            // TODO: Remove all the customers from the database, get all customers from the database and print the count.
            var allCustomers = service.GetEntries();

            foreach (var customer in allCustomers)
            {
                int id = customer.Id;
                service.Delete(id);
            }

            var noEntries = service.GetEntries();

            ConsoleLog.LogResult($"Number of customers in DB: {noEntries.Count}");

            ConsoleLog.LogSub("Test 2 End: Remove All Customers");
        }
    }
}
