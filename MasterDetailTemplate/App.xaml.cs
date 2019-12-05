using System;
using MasterDetailTemplate.Bootstrap;
using MasterDetailTemplate.Contracts.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


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
            AppCenter.Start("ios=d8eeb6b8-837b-45d5-a4db-85042f380545;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes));
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
