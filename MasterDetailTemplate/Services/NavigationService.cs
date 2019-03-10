using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.ViewModels;
using MasterDetailTemplate.ViewModels.Base;
using MasterDetailTemplate.Views;
using Xamarin.Forms;

namespace MasterDetailTemplate.Services
{
    public class NavigationService : INavigationService
    {
        private Dictionary<Type, Type> _mappingViewModelToView;
        private ISettingsService _settingsService;

        public NavigationService(ISettingsService settingsService)
        {
            _mappingViewModelToView = new Dictionary<Type, Type>();
            _settingsService = settingsService;
            CreateMappings();
        }


        #region INavigationService Methods

        public async Task InitializeAsync()
        {
            if (string.IsNullOrEmpty(_settingsService.UserTokenSetting))
            {
                await NavigateToAsync<SignInViewModel>();
            }
            else
            {
                await NavigateToAsync<MainMasterDetailViewModel>();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return CustomNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return CustomNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {

            return CustomNavigateToAsync(viewModelType, null);
        }

        public async Task CloseModalView()
        {
            var currentPage = Application.Current.MainPage;
            await currentPage.Navigation.PopModalAsync(true);

        }

        #endregion

        #region Protected Methods

        protected async Task CustomNavigateToAsync(Type viewModelType, object parameter)
        {

            var page = CreatePage(viewModelType, parameter);

            if (page is SignInView)
            {
                var nv = new NavigationView(page);
                Application.Current.MainPage = nv;

            }
            else if (page is MainMasterDetailView)
            {
                Application.Current.MainPage = page;

            }
            else if (page is ModalView)
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(page);
            }
            else if (Application.Current.MainPage is MainMasterDetailView)
            {
                var mainPage = Application.Current.MainPage as MainMasterDetailView;

                if (mainPage.Detail is NavigationView navigationPage && !(page is FirstView || page is SecondView))
                {
                    var currentPage = navigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                       await navigationPage.PushAsync(page);
                    }
                }
                else
                {
                    navigationPage = new NavigationView(page);
                    mainPage.Detail = navigationPage;
                }

                mainPage.IsPresented = false;
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        #endregion

        #region Private Methods

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = _mappingViewModelToView[viewModelType];
            if (pageType == null) throw new Exception($"No page for view model:{viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }


        private void CreateMappings()
        {
            _mappingViewModelToView.Add(typeof(SignInViewModel), typeof(SignInView));
            _mappingViewModelToView.Add(typeof(MainMasterDetailViewModel), typeof(MainMasterDetailView));
            _mappingViewModelToView.Add(typeof(MenuViewModel), typeof(MenuView));
            _mappingViewModelToView.Add(typeof(FirstViewModel), typeof(FirstView));
            _mappingViewModelToView.Add(typeof(SecondViewModel), typeof(SecondView));
            _mappingViewModelToView.Add(typeof(NavigationDetailViewModel), typeof(NavigationDetailView));
            _mappingViewModelToView.Add(typeof(ModalViewModel), typeof(ModalView));

        }

        #endregion
    }
}
