using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class VehicleAccess
    {
        DriveItEntities1 db = new DriveItEntities1();
        public List<VehicleEntity> GetVehicleDetailsById(int vehicleId)
        {
            var data = (from item in db.VehicleTbs
                        where item.VehicleId == vehicleId
                        select new VehicleEntity()
                        {
                            VehicleId = item.VehicleId,
                            VehicleName = item.VehicleName,
                            VehicleType = item.VehicleType,
                            VehiclePrice = item.VehiclePrice,
                            VehicleAvailability = item.VehicleAvailability,
                            VehicleImage = item.VehicleImage
                            
                        }).ToList();
            return data;
        }

        public List<VehicleEntity> GetVehicleDetails()
        {
            var data = (from item in db.VehicleTbs
                        select new VehicleEntity()
                        {
                            VehicleId = item.VehicleId,
                            VehicleName = item.VehicleName,
                            VehicleType = item.VehicleType,
                            VehiclePrice = item.VehiclePrice,
                            VehicleAvailability = item.VehicleAvailability,
                            VehicleImage = item.VehicleImage
                        }).ToList();
            return data;
        }

        public bool InsertVehicle(VehicleEntity vehicle)
        {
            if (db.VehicleTbs.Find(vehicle.VehicleId) == null)
            {
                VehicleTb vehicleTb = new VehicleTb()
                {
                    VehicleId = vehicle.VehicleId,
                    VehicleName = vehicle.VehicleName,
                    VehicleType = vehicle.VehicleType,
                    VehiclePrice = vehicle.VehiclePrice,
                    VehicleAvailability = vehicle.VehicleAvailability,
                    VehicleImage = vehicle.VehicleImage
                };
                try
                {
                    db.VehicleTbs.Add(vehicleTb);
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

        public bool UpdateVehicle(int VehicleId, VehicleEntity vehicle)
        {
            if (db.VehicleTbs.Find(vehicle.VehicleId) != null)
            {
                VehicleTb vehicleTb = new VehicleTb()
                {
                    VehicleId = vehicle.VehicleId,
                    VehicleName = vehicle.VehicleName,
                    VehicleType = vehicle.VehicleType,
                    VehiclePrice = vehicle.VehiclePrice,
                    VehicleAvailability = vehicle.VehicleAvailability,
                    VehicleImage = vehicle.VehicleImage
                };
                try
                {
                    VehicleTb vehicleTbs = db.VehicleTbs.Find(VehicleId);
                    vehicleTbs.VehicleId = vehicle.VehicleId;

                    vehicleTbs.VehicleName = vehicle.VehicleName;
                    vehicleTbs.VehicleType = vehicle.VehicleType;
                    vehicleTbs.VehiclePrice = vehicle.VehiclePrice;
                    vehicleTbs.VehicleAvailability = vehicle.VehicleAvailability;
                    vehicleTbs.VehicleImage = vehicle.VehicleImage;
             
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

        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                VehicleTb vehicleTbs = db.VehicleTbs.Find(vehicleId);

                if (vehicleTbs != null)
                {
                    db.VehicleTbs.Remove(vehicleTbs);
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
