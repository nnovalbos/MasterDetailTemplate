using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.ViewModels.Base;
using Xamarin.Forms;

namespace MasterDetailTemplate.ViewModels
{
    public class SecondViewModel: BaseViewModel
    {
        public SecondViewModel(INavigationService navigationService,
            IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #region Commands
        public ICommand ShowDetailCommand => new Command(async() => await OnShowDetail());
        public ICommand ShowModalCommand => new Command(async () => await OnShowModal());
        #endregion

        #region Private Methods
        private async Task OnShowDetail()
        {
            await _navigationService.NavigateToAsync<NavigationDetailViewModel>();
        }

        private async Task OnShowModal()
        {
            await _navigationService.NavigateToAsync<ModalViewModel>();
        }
        #endregion
    }
}
