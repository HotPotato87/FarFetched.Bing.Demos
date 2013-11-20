using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FarFetched.Shared.Architecture;
using FarFetched.Shared.SearchService;

namespace FarFetched.Shared.ViewModels
{
    public class SearchPageViewModel : FarFetchedPopulatableViewModel
    {
        private string _query;
        private SearchResultViewModel _result;

        public string Query
        {
            get { return _query; }
            set
            {
                _query = value;
                RaisePropertyChanged(() => Query);
            }
        }

        public ICommand RunQueryCommand
        {
            get
            {
                return new MvxCommand(() => this.ViewModelPopulator.Populate(this));
            }
        }

        public SearchResultViewModel Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(() => Result);
            }
        }
    }
}
