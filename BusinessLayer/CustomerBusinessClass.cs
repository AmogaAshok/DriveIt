using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerBusinessClass
    {
        public List<CustomerEntity> GetCustomerDetailsById(int customerId)
        {
            CustomerAccess customer = new CustomerAccess();
            return customer.GetCustomerDetailsById(customerId);
        }

        public List<CustomerEntity> GetCustomerDetails()
        {
            CustomerAccess customer = new CustomerAccess();
            return customer.GetCustomerDetails();
        }

        public bool InsertCustomer(CustomerEntity customer1)
        {
            CustomerAccess customer = new CustomerAccess();
            return customer.InsertCustomer(customer1);
        }

        public bool UpdateCustomer(int customerId, CustomerEntity customer1)
        {
            CustomerAccess customer = new CustomerAccess();
            return customer.UpdateCustomer(customerId, customer1);
        }

        public bool DeleteCustomer(int customerId)
        {
            CustomerAccess customer = new CustomerAccess();
            return customer.DeleteCustomer(customerId);
        }
    }
}
