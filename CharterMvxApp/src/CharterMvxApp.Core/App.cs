using MvvmCross.IoC;
using MvvmCross.ViewModels;
using CharterMvxApp.Core.ViewModels.Main;

namespace CharterMvxApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
