using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ServiceBusiness
    {
        public List<ServiceEntity> GetServiceDetailsById(int serviceId)
        {
            ServiceAccess serviceData = new ServiceAccess();

            return serviceData.GetServiceDetailsById(serviceId);
        }

        public List<ServiceEntity> GetCustomerDetails()
        {
            ServiceAccess serviceData = new ServiceAccess();
            return serviceData.GetServiceDetails();
        }

        public bool InsertService(ServiceEntity service)
        {
            ServiceAccess serviceData = new ServiceAccess();
            return serviceData.InsertService(service);
        }

        public bool UpdateService(int serviceId, ServiceEntity service)
        {
            ServiceAccess serviceData = new ServiceAccess();
            return serviceData.UpdateService(serviceId, service);
        }

        public bool DeleteService(int serviceId)
        {
            ServiceAccess serviceData = new ServiceAccess();
            return serviceData.DeleteService(serviceId);
        }
    }
}
