using FarFetched.Shared.Architecture;
using FarFetched.Shared.SearchService;

namespace FarFetched.Shared.ViewModels
{
    public class SearchResultRowViewModel : FarFetchedViewModelBase
    {
        private SearchResultBase _item;
        public SearchResultBase Item
        {
            get { return _item; }
            set
            {
                _item = value;
                RaisePropertyChanged(() => Item);
            }
        }

        public SearchResultRowViewModel(SearchResultBase searchResultBase)
        {
            Item = searchResultBase;
        }

        public SearchResultRowViewModel()
        {
            
        }
    }
}