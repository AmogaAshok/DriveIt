using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DriveIt.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    { 
            
            [HttpGet]
            [Route("GetCustomerById/{CustomerId}")]
            //[ResponseType(typeof(CustomerEntity))]
        public HttpResponseMessage GetCustomerDetailsById(int CustomerId)
            {
                CustomerBusinessClass customerBusiness = new CustomerBusinessClass();
                var data = customerBusiness.GetCustomerDetailsById(CustomerId);
                if (!data.Any())
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Customer Not Found.!");
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
                }
            }

            [HttpGet]
            [Route("GetAllCustomer")]
            public List<CustomerEntity> GetCustomerDetails()
            {
                CustomerBusinessClass customerBusiness = new CustomerBusinessClass();
                return customerBusiness.GetCustomerDetails();
            }

            [HttpPost]
            [Route("AddCustomer")]
            public HttpResponseMessage InsertCustomer(CustomerEntity Customer)
            {
                CustomerBusinessClass customerBusiness = new CustomerBusinessClass();
                if (customerBusiness.InsertCustomer(Customer))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Inserted Successfully.!");
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Customer Already Exists!");
                }
            }


            [HttpPut]
            [Route("updateCustomer/{CustomerId}")]
            public HttpResponseMessage UpdateCustomer(int CustomerId, CustomerEntity Customer)
            {
                CustomerBusinessClass customerBusiness = new CustomerBusinessClass();
                if (customerBusiness.UpdateCustomer(CustomerId, Customer))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully.!");
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Customer does not exist.!");
                }
            }

            [HttpDelete]
            [Route("deletecustomer/{CustomerId}")]
            public HttpResponseMessage DeleteCustomer(int CustomerId)
            {
                CustomerBusinessClass customerBusiness = new CustomerBusinessClass();
                if (customerBusiness.DeleteCustomer(CustomerId))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Customer Deleted Successfully.!");
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Customer does not exists.!");
                }
            }
        }
    }

