using System;
using Autofac;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.Services;
using MasterDetailTemplate.ViewModels;

namespace MasterDetailTemplate.Bootstrap
{
    public static class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SignInViewModel>();
            builder.RegisterType<MainMasterDetailViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<FirstViewModel>();
            builder.RegisterType<SecondViewModel>();
            builder.RegisterType<NavigationDetailViewModel>();
            builder.RegisterType<ModalViewModel>();

            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<SettingsService>().As<ISettingsService>();

            _container = builder.Build();

        }

        public static object Resolve(Type typename)
        {
            return _container.Resolve(typename);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}