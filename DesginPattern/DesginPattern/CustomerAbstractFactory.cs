using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class CustomerAbstractFactory
    {
       
        interface ICustomer
        {
            void GetSerevices();
        }
        class Customer : ICustomer
        {
            public void GetSerevices()
            {
                Console.WriteLine("Get your services");
            }

            
        }
        class Lunch : ICustomer
        {
            public void GetSerevices()
            {
                Console.WriteLine("Lunch for customer");
            }
        }
        class Dinner : ICustomer
        {
            public void GetSerevices()
            {
                Console.WriteLine("Dinner for customer");
            }
        }

        class Descount : ICustomer
        {
            public void GetSerevices()
            {
                Console.WriteLine("Descount for customer");
            }
        }
        interface IInvoice
        {
            void GetInvoice() { }
        }
        class Invoice : IInvoice
        {
            public void GetSerevices()
            {
                Console.WriteLine("Monthly Invoice is : 2000");
            }

            internal static string GetInvoice()
            {
                throw new NotImplementedException();
            }
        }
        class InvoiceCustomer
        {
            ICustomer Services;
            IInvoice Invoice;
        }
        public Customer(ICustomer customer)
        {
            
            customer.GetSerevices();
        }
        public string GetServcicesDetails()
        {
            return Customer.GetServcices();
        }

       public string GetInvoiceAmount()
        {
            return Invoice.GetInvoice();
        }
        class Program
        {
            static void main()
            {
                Customer customer = new Customer();
                Invoice invoice = new Invoice();

                Console.WriteLine("Customer.GetServcicesDetails()");
                Console.WriteLine("Invoice.GetInvoiceAmount()");
            }
        }
       
    }
}

