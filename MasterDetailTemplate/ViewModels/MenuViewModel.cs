using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.Models;
using MasterDetailTemplate.ViewModels.Base;
using Xamarin.Forms;

namespace MasterDetailTemplate.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MasterDetailMenuItem> _menuItems;
        private ISettingsService _settingsService;
        #endregion

        public MenuViewModel(INavigationService navigationService,
        IDialogService dialogService, ISettingsService settingsService) : base(navigationService, dialogService)
        {
            _settingsService = settingsService;
            MenuItems = new ObservableCollection<MasterDetailMenuItem>();
            LoadMenuItems();
        }

        #region Properties
        public ObservableCollection<MasterDetailMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public string UserName
        {
            get => $"{_settingsService.UserNameSetting}";
        }

        public string UserProfilePicture
        {
            get => "default_user.png";
        }
        #endregion

        #region Commands
        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public ICommand SignOutCommand => new Command(OnSignOut);
        #endregion

        #region Private Methods

        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MasterDetailMenuItem);
            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MasterDetailMenuItem
            {
                MenuItemTitle = "Item 1",
                ViewModelToLoad = typeof(FirstViewModel),
                MenuItemType = MenuItemType.FirstItem
            });

            MenuItems.Add(new MasterDetailMenuItem
            {
                MenuItemTitle = "Item 2",
                ViewModelToLoad = typeof(SecondViewModel),
                MenuItemType = MenuItemType.SecondItem
            });
        }

        private void OnSignOut(object obj)
        {
            _settingsService.UserTokenSetting = string.Empty;
            _settingsService.UserNameSetting = string.Empty;
            _navigationService.NavigateToAsync<SignInViewModel>();
        }

        #endregion
    }
}
