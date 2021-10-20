using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerAccess
    {

        DriveItEntities1 db = new DriveItEntities1();
        public List<CustomerEntity> GetCustomerDetailsById(int customerId)
        {
            var data = (from item in db.CustomerDetails
                        where item.CustomerId == customerId
                        select new CustomerEntity()
                        {
                            CustomerId = item.CustomerId,

                            CustomerName = item.CustomerName,
                            PhoneNo = item.PhoneNo,
                            password = item.password,
                            Address = item.Address,
                            DOB = item.DOB,
                            Email = item.Email
                        }).ToList();
            return data;
        }

        public List<CustomerEntity> GetCustomerDetails()
        {
            var data = (from item in db.CustomerDetails
                        select new CustomerEntity()
                        {
                            CustomerId = item.CustomerId,

                            CustomerName = item.CustomerName,
                            PhoneNo = item.PhoneNo,
                            password = item.password,
                            Address = item.Address,
                            DOB = item.DOB,
                            Email = item.Email
                        }).ToList();
            return data;
        }

        public bool InsertCustomer(CustomerEntity customer)
        {
            if (db.CustomerDetails.Find(customer.CustomerId) == null)
            {
                CustomerDetail cust = new CustomerDetail()
                {
                    CustomerId = customer.CustomerId,

                    CustomerName = customer.CustomerName,
                    PhoneNo = customer.PhoneNo,
                    password = customer.password,
                    Address = customer.Address,
                    DOB = customer.DOB,
                    Email = customer.Email
                };
                try
                {
                    db.CustomerDetails.Add(cust);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool UpdateCustomer(int customerId, CustomerEntity customer)
        {
            if (db.CustomerDetails.Find(customer.CustomerId) != null)
            {
                CustomerDetail cust = new CustomerDetail()
                {
                    CustomerId = customer.CustomerId,

                    CustomerName = customer.CustomerName,
                    PhoneNo = customer.PhoneNo,
                    password = customer.password,
                    Address = customer.Address,
                    DOB = customer.DOB,
                    Email = customer.Email
                };
                try
                {
                    CustomerDetail custdata = db.CustomerDetails.Find(customerId);
                    custdata.CustomerId = customer.CustomerId;

                    custdata.CustomerName = customer.CustomerName;
                    custdata.PhoneNo = customer.PhoneNo;
                    custdata.password = customer.password;
                    custdata.Address = customer.Address;
                    custdata.DOB = customer.DOB;
                    custdata.Email = customer.Email;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                CustomerDetail custdata = db.CustomerDetails.Find(customerId);

                if (custdata != null)
                {
                    db.CustomerDetails.Remove(custdata);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}
