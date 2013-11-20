using Cirrious.CrossCore.IoC;
using FarFetched.Shared.ViewModels;

namespace FarFetched.Shared
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<SearchPageViewModel>();
        }
    }
}