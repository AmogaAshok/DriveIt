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
    [RoutePrefix("api/Vehicle")]
    public class VehicleController : ApiController
    {
        [HttpGet]
        [Route("getVehicleById/{VehicleId}")]
        public HttpResponseMessage GetVehicleDetailsById(int VehicleId)
        {
            VehicleBusiness vehicleBusiness = new VehicleBusiness();
            var data = vehicleBusiness.GetVehicleDetailsById(VehicleId);
            if (!data.Any())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Vehicle Not Found.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
        }

        [HttpGet]
        [Route("getAllVehicles")]
        public List<VehicleEntity> GetVehicleDetails()
        {
            VehicleBusiness vehicleBusiness = new VehicleBusiness();
            return vehicleBusiness.GetVehicleDetails();
        }

        [HttpPost]
        [Route("insertVehicles")]
        public HttpResponseMessage InsertVehicle(VehicleEntity Vehicle)
        {
            VehicleBusiness vehicleBusiness = new VehicleBusiness();
            if (vehicleBusiness.InsertVehicle(Vehicle))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Inserted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Vehicle Already Exists!");
            }
        }


        [HttpPut]
        [Route("updateVehicles/{VehicleId}")]
        public HttpResponseMessage UpdateVehicle(int VehicleId, VehicleEntity Vehicle)
        {
            VehicleBusiness vehicleBusiness = new VehicleBusiness();
            if (vehicleBusiness.UpdateVehicle(VehicleId, Vehicle))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Vehicle does not exist.!");
            }
        }

        [HttpDelete]
        [Route("deleteVehicles/{VehicleId}")]
        public HttpResponseMessage DeleteVehicle(int vehicleId)
        {
            VehicleBusiness vehicleBusiness = new VehicleBusiness();
            if (vehicleBusiness.DeleteVehicle(vehicleId))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Vehicle Deleted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Vehicle does not exists.!");
            }
        }
    }
}

