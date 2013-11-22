using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FarFetched.Shared.Architecture
{
    public abstract class ViewModelPopulatorBase<T> : IViewModelPopulator<T> where T : FarFetchedPopulatableViewModel
    {
        private T _viewModel;

        public abstract void Populate(T viewmodel);
        public event Action OnFinished;

        public void Populate(FarFetchedPopulatableViewModel viewModel)
        {
            var typedViewModel = (T)viewModel;
            _viewModel = typedViewModel;

            viewModel.IsLoading = true;
            this.Populate(typedViewModel);
        }

        protected void HandleError(Exception error)
        {
            Debug.WriteLine("ViewModelPopulatorBase : Error occured {0} \r\n Stacktrace : {1}", error, error.StackTrace);
            _viewModel.ShowMessage("Error occured", "There was a problem with this request, please check the application logs and/or debug output");
        }

        protected void Finished()
        {
            _viewModel.IsPopulated = true;
            _viewModel.IsLoading = false;

            if (OnFinished != null)
            {
                OnFinished();
            }
        }
    }
}
