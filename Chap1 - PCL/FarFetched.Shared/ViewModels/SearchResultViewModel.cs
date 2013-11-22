using System.Collections.ObjectModel;
using System.Linq;
using FarFetched.Shared.Architecture;
using FarFetched.Shared.SearchService;

namespace FarFetched.Shared.ViewModels
{
    public class SearchResultViewModel : FarFetchedViewModelBase
    {
        private SearchResultSet _resultSet;
        private ObservableCollection<SearchResultRowViewModel> _resultRows;

        public SearchResultSet ResultSet
        {
            get { return _resultSet; }
            set
            {
                _resultSet = value;
                RaisePropertyChanged(() => ResultSet);
            }
        }

        public ObservableCollection<SearchResultRowViewModel> ResultRows
        {
            get { return _resultRows; }
            set
            {
                _resultRows = value;
                RaisePropertyChanged(() => ResultRows);
            }
        }

        public SearchResultViewModel()
        {
            this.SetActionBinding(() => ResultSet, () =>
            {
                var rows = ResultSet.Results.Select(x => new SearchResultRowViewModel(x));
                ResultRows = new ObservableCollection<SearchResultRowViewModel>(rows);
            });
        }

        public SearchResultViewModel(SearchResultSet resultSet) : this()
        {
            ResultSet = resultSet;
        }
    }
}