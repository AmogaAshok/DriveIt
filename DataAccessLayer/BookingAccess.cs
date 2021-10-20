using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
namespace DataAccessLayer
{
    public class BookingAccess
    {
        DriveItEntities1 db = new DriveItEntities1();
        public List<BookingEntity> GetBookingDetailsById(int BookingId)
        {
            var data = (from item in db.BookingTbs
                        where item.BookingId == BookingId
                        select new BookingEntity()
                        {
                            BookingId = item.BookingId,

                            CustomerId = item.CustomerId,
                            BookingDate = item.BookingDate,
                            VehicleId = item.VehicleId,
                        }).ToList();
            return data;
        }

        public List<BookingEntity> GetBookingDetails()
        {
            var data = (from item in db.BookingTbs
                        select new BookingEntity()
                        {

                            BookingId = item.BookingId,

                            CustomerId = item.CustomerId,
                            BookingDate = item.BookingDate,
                            VehicleId = item.VehicleId,
                        }).ToList();
            return data;
        }

        public bool InsertBooking(BookingEntity booking)
        {
            if (db.BookingTbs.Find(booking.BookingId) == null)
            {
                BookingTb book = new BookingTb()
                {
                    BookingId = booking.BookingId,

                    CustomerId = booking.CustomerId,
                    BookingDate = booking.BookingDate,
                    VehicleId = booking.VehicleId,
                };
                try
                {
                    db.BookingTbs.Add(book);
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

        public bool UpdateBooking(int BookingId, BookingEntity Booking)
        {
            if (db.BookingTbs.Find(Booking.BookingId) != null)
            {
                BookingTb book = new BookingTb()
                {
                    BookingId = Booking.BookingId,

                    CustomerId = Booking.CustomerId,
                    BookingDate = Booking.BookingDate,
                    VehicleId = Booking.VehicleId,
                };
                try
                {
                    BookingTb bookdata = db.BookingTbs.Find(BookingId);
                    //CustomerDetail custdata = db.CustomerDetails.Find(customerId);
                    bookdata.BookingId = Booking.BookingId;

                    bookdata.CustomerId = Booking.CustomerId;
                    bookdata.BookingDate = Booking.BookingDate;
                    bookdata.VehicleId = Booking.VehicleId;
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

        public bool DeleteBooking(int BookingId)
        {
            try
            {
                BookingTb bookdata = db.BookingTbs.Find(BookingId);

                if (bookdata != null)
                {
                    db.BookingTbs.Remove(bookdata);
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
    
