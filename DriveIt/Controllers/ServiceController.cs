using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DriveIt.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet]
        [Route("api/Service/{serviceId}")]
        public HttpResponseMessage GetEmployeeDetailsById(int serviceId)
        {
            ServiceBusiness serviceBusiness = new ServiceBusiness();
            var data = serviceBusiness.GetServiceDetailsById(serviceId);
            if (!data.Any())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Service Not Found.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
        }

        [HttpGet]
        [Route("api/Service")]
        public List<ServiceEntity> GetServiceDetails()
        {
            ServiceBusiness serviceBusiness = new ServiceBusiness();
            return serviceBusiness.GetCustomerDetails();
        }

        [HttpPost]
        [Route("api/Service")]
        public HttpResponseMessage InsertService(ServiceEntity service)
        {
            ServiceBusiness serviceBusiness = new ServiceBusiness();
            if (serviceBusiness.InsertService(service))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Inserted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Service Already Exists!");
            }
        }


        [HttpPut]
        [Route("api/Service/{serviceId}")]
        public HttpResponseMessage UpdateService(int serviceId, ServiceEntity service)
        {
            ServiceBusiness serviceBusiness = new ServiceBusiness();
            if (serviceBusiness.UpdateService(serviceId, service))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Service does not exist.!");
            }
        }

        [HttpDelete]
        [Route("api/Service/{serviceId}")]
        public HttpResponseMessage DeleteService(int serviceId)
        {
            ServiceBusiness serviceBusiness = new ServiceBusiness();
            if (serviceBusiness.DeleteService(serviceId))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Service Deleted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Service does not exists.!");
            }
        }
    }
}

