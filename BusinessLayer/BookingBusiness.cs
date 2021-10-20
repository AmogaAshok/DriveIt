using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookingBusiness
    {
        public List<BookingEntity> GetBookingDetailsById(int BookingId)
        {
            BookingAccess booking = new BookingAccess();
            return booking.GetBookingDetailsById(BookingId);
        }

        public List<BookingEntity> GetBookingDetails()
        {
            BookingAccess booking = new BookingAccess();
            return booking.GetBookingDetails();
        }

        public bool InsertBooking(BookingEntity booking1)
        {
            BookingAccess booking = new BookingAccess();
            return booking.InsertBooking(booking1);
        }

        public bool UpdateBooking(int BookingId, BookingEntity booking1)
        {
            BookingAccess booking = new BookingAccess();
            return booking.UpdateBooking(BookingId, booking1);
        }

        public bool DeleteBooking(int BookingId)
        {
            BookingAccess booking = new BookingAccess();
            return booking.DeleteBooking(BookingId);
        }
    }
}

