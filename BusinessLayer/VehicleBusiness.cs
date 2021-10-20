using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VehicleBusiness
    {
        public List<VehicleEntity> GetVehicleDetailsById(int VehicleId)
        {
            VehicleAccess Vehicle = new VehicleAccess();
            return Vehicle.GetVehicleDetailsById(VehicleId);
        }

        public List<VehicleEntity> GetVehicleDetails()
        {
            VehicleAccess Vehicle = new VehicleAccess();
            return Vehicle.GetVehicleDetails();
        }

        public bool InsertVehicle(VehicleEntity vehicle)
        {
            VehicleAccess Vehicle = new VehicleAccess();
            return Vehicle.InsertVehicle(vehicle);
        }

        public bool UpdateVehicle(int VehicleId, VehicleEntity vehicle)
        {
            VehicleAccess Vehicle = new VehicleAccess();
            return Vehicle.UpdateVehicle(VehicleId, vehicle);
        }

        public bool DeleteVehicle(int VehicleId)
        {
            VehicleAccess Vehicle = new VehicleAccess();
            return Vehicle.DeleteVehicle(VehicleId);
        }
    }
}

