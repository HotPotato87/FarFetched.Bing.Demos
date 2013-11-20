using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FarFetched.Shared.Architecture
{
    public interface IViewModelPopulator
    {
        void Populate(FarFetchedPopulatableViewModel viewModel);
        event Action OnFinished;
    }

    public interface IViewModelPopulator<in T> : IViewModelPopulator
        where T : FarFetchedPopulatableViewModel
    {
        void Populate(T viewmodel);
    }
}
