using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarFetched.Shared.SearchService;
using FarFetched.Shared.Services;
using FarFetched.Shared.Settings;
using FarFetched.Shared.ViewModels;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace FarFetched.SharedCore.Test
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public async Task Web_Service_Returns_Results_()
        {
            //Arrange
            var client = new SearchServiceClient();
            bool completed = false;
            client.SearchCompleted += (sender, args) =>
            {
                //Assert async
                Assert.IsTrue(args.Result.ResultSets.Any() && args.Result.ResultSets.First().Results.Any());
                completed = true;
            };

            //Act
            client.SearchAsync(new SearchRequest()
            {
                Credentials = new Credentials() { ApplicationId = SharedCoreSettings.BingMapsKey },
                StructuredQuery = new StructuredSearchQuery() { Keyword = "Wine", Location = "London"},
                SearchOptions = new SearchOptions() {  ListingType = ListingType.Business}
            });

            while (!completed)
            {
                await Task.Delay(500);
            }
        }

        [TestMethod]
        public async Task Web_Service_Returns_Results_For_Birmingham()
        {
            //Arrange
            var completed = false;
            DeviceLocationInfoService.RegisterDeviceLocationInfo(new MockRegisterDeviceLocationInfo(-1.906, 52.475));
            var searchPageViewModel = new SearchPageViewModel();
            searchPageViewModel.ViewModelPopulator = new SearchPageViewModelPopulator();
            searchPageViewModel.Query = "Wine";

            //Assert async
            searchPageViewModel.ViewModelPopulator.OnFinished += () =>
            {
                Assert.IsTrue(searchPageViewModel.Result.ResultRows.Any());
                completed = true;
            };

            //Act
            searchPageViewModel.RunQueryCommand.Execute(null);

            while (!completed)
            {
                await Task.Delay(500);
            }
        }
    }

    public class MockRegisterDeviceLocationInfo : IProvidesDeviceLocationInfo
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public MockRegisterDeviceLocationInfo(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
