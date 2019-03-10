using System;
using Xamarin.Forms;

namespace MasterDetailTemplate.Models
{
    public enum MenuItemType
    {
        FirstItem,
        SecondItem
    }

    public class MasterDetailMenuItem : BindableObject
    {
        #region Attributes
        private string _menuText;
        private MenuItemType _menuItemType;
        private Type _viewModelToLoad;
        #endregion

        #region Properties
        public MenuItemType MenuItemType
        {
            get
            {
                return _menuItemType;
            }
            set
            {
                _menuItemType = value;
                OnPropertyChanged();
            }
        }

        public string MenuItemTitle
        {
            get
            {
                return _menuText;
            }
            set
            {
                _menuText = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelToLoad
        {
            get
            {
                return _viewModelToLoad;
            }
            set
            {
                _viewModelToLoad = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
