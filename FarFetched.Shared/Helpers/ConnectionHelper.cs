using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarFetched.Shared.SearchService;
using FarFetched.Shared.Settings;

namespace FarFetched.Shared.Helpers
{
    public static class ConnectionHelper
    {
        public static Credentials GetCredentials()
        {
            return new Credentials()
            {
                ApplicationId = SharedCoreSettings.BingMapsKey
            };
        }
    }
}
