using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ServiceAccess
    {
        DriveItEntities1 db = new DriveItEntities1();
        public List<ServiceEntity> GetServiceDetailsById(int serviceId)
        {


            var data = (from item in db.ServiceTbs
                        where item.ServiceId == serviceId
                        select new ServiceEntity()
                        {
                            ServiceId = item.ServiceId,

                            VehicleId = item.VehicleId,
                            CustomerId = item.CustomerId,
                            ServiceDate = (DateTime)item.ServiceDate,
                            Message = item.Message,

                        }).ToList();
            return data;
        }

        public List<ServiceEntity> GetServiceDetails()
        {
            var data = (from item in db.ServiceTbs
                        select new ServiceEntity()
                        {
                            ServiceId = item.ServiceId,

                            VehicleId = item.VehicleId,
                            CustomerId = item.CustomerId,
                            ServiceDate = (DateTime)item.ServiceDate,
                            Message = item.Message,
                        }).ToList();
            return data;
        }

        public bool InsertService(ServiceEntity service)
        {
            if (db.ServiceTbs.Find(service.ServiceId) == null)
            {

                ServiceTb service1 = new ServiceTb()
                {
                    ServiceId = service.ServiceId,


                    VehicleId = service.VehicleId,
                    CustomerId = service.CustomerId,
                    ServiceDate = service.ServiceDate,
                    Message = service.Message,

                };
                try
                {
                    db.ServiceTbs.Add(service1);
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

        public bool UpdateService(int serviceId, ServiceEntity service)
        {
            if (db.ServiceTbs.Find(service.ServiceId) != null)
            {
                ServiceTb service1 = new ServiceTb()
                {
                    ServiceId = service.ServiceId,


                    VehicleId = service.VehicleId,
                    CustomerId = service.CustomerId,
                    ServiceDate = service.ServiceDate,
                    Message = service.Message,
                };
                try
                {
                    ServiceTb service2 = db.ServiceTbs.Find(serviceId);
                    service2.ServiceId = service.ServiceId;

                    service2.VehicleId = service.VehicleId;
                    service2.CustomerId = service.CustomerId;
                    service2.ServiceDate = service.ServiceDate;
                    service2.Message = service.Message;

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

        public bool DeleteService(int serviceId)
        {
            try
            {
                ServiceTb service2 = db.ServiceTbs.Find(serviceId);

                if (service2 != null)
                {
                    db.ServiceTbs.Remove(service2);
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
