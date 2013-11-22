using System.Linq;
using FarFetched.Shared.Architecture;
using FarFetched.Shared.Helpers;
using FarFetched.Shared.SearchService;
using FarFetched.Shared.Services;

namespace FarFetched.Shared.ViewModels
{
    public class SearchPageViewModelPopulator : ViewModelPopulatorBase<SearchPageViewModel>
    {
        public override void Populate(SearchPageViewModel viewmodel)
        {
            var client = new SearchService.SearchServiceClient();

            client.SearchCompleted += (sender, args) =>
            {
                if (args.Error != null) {  base.HandleError(args.Error); }

                if (args.Result.ResultSets.Any())
                {
                    var result = args.Result.ResultSets[0];
                    viewmodel.Result = new SearchResultViewModel(result);
                }
                else
                {
                    viewmodel.ShowMessage("No results found", "No results found for request " + viewmodel.Query);
                }
                this.Finished();
            };

            client.SearchAsync(new SearchRequest()
            {
                Credentials = ConnectionHelper.GetCredentials(),
                SearchOptions = new SearchOptions() { },
                StructuredQuery = new StructuredSearchQuery()
                {
                    Keyword  = viewmodel.Query,
                    Location = string.Format("{0},{1}", DeviceLocationInfoService.LocationInformation.Latitude, DeviceLocationInfoService.LocationInformation.Longitude)
                }
            });

            client.CloseAsync();
        }
    }
}