namespace FarFetched.Shared.Architecture
{
    public class FarFetchedPopulatableViewModel : FarFetchedViewModelBase
    {
        private bool _isPopulated = false;
        public bool IsPopulated
        {
            get { return _isPopulated; }
            set
            {
                _isPopulated = value;
                RaisePropertyChanged(() => IsPopulated);
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public IViewModelPopulator ViewModelPopulator { get; set; }
    }
}