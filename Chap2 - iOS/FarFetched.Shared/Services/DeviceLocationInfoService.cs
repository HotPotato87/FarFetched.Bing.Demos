using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarFetched.Shared.Services
{
    public static class DeviceLocationInfoService
    {
        private static IProvidesDeviceLocationInfo _serviceInfo;
        public static IProvidesDeviceLocationInfo LocationInformation
        {
            get
            {
                if (_serviceInfo != null)
                {
                    return _serviceInfo;
                }
                else
                {
                    throw new Exception("Device must register IProvidesDeviceLocationInfo with DeviceLocationInfoService to complete this operation");
                }
            }
        }

        public static void RegisterDeviceLocationInfo(IProvidesDeviceLocationInfo serviceInfo)
        {
            _serviceInfo = serviceInfo;
        }
    }

    public interface IProvidesDeviceLocationInfo
    {
        double Longitude { get; set; }
        double Latitude { get; set; }
    }
}
