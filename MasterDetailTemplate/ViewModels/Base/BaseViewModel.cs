using System;
using System.Threading.Tasks;
using MasterDetailTemplate.Contracts.Services;
using Xamarin.Forms;

namespace MasterDetailTemplate.ViewModels.Base
{
    public class BaseViewModel : BindableObject
    {

        protected readonly INavigationService _navigationService;
        protected readonly IDialogService _dialogService;
        private bool _isBusy;

        public BaseViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }


        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
    }
}
