using System;
using MasterDetailTemplate.Bootstrap;
using MasterDetailTemplate.Contracts.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MasterDetailTemplate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.RegisterDependencies();

            var navigationService = AppContainer.Resolve<INavigationService>();
            navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
