using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using EntityLayer;

namespace DriveIt.Controllers
{  [RoutePrefix("api/Booking")]  
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("getCustomer/{BookingId}")]
        public HttpResponseMessage GetBookingDetailsById(int BookingId)
        {
            BookingBusiness BookingBusiness = new BookingBusiness();
            var data = BookingBusiness.GetBookingDetailsById(BookingId);
            if (!data.Any())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, " Not Found.!");
            }
            else
            {

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, data);
            }
        }

        [HttpGet]
        [Route("getAllBookings")]
        public List<BookingEntity> GetBookingDetails()
        {
            BookingBusiness bookingBusiness = new BookingBusiness();
            return bookingBusiness.GetBookingDetails();
        }

        [HttpPost]
        [Route("insertBooking")]
        public HttpResponseMessage InsertBooking(BookingEntity booking)
        {
            BookingBusiness bookingBusiness = new BookingBusiness();
            if (bookingBusiness.InsertBooking(booking))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Inserted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Booking Already Exists!");
            }
        }


        [HttpPut]
        [Route("updateBooking/{BookingId}")]
        public HttpResponseMessage UpdateBooking(int BookingId, BookingEntity booking)
        {
            BookingBusiness BookingBusiness = new BookingBusiness();
            if (BookingBusiness.UpdateBooking(BookingId, booking))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Employee does not exist.!");
            }
        }

        [HttpDelete]
        [Route("deleteBooking/{BookingId}")]
        public HttpResponseMessage DeleteBooking(int BookingId)
        {
            BookingBusiness bookingBusiness = new BookingBusiness();
            if (bookingBusiness.DeleteBooking(BookingId))
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Booking Deleted Successfully.!");
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Booking does not exists.!");
            }
        }
    }
}
