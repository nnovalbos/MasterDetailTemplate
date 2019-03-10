using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.ViewModels.Base;
using Xamarin.Forms;

namespace MasterDetailTemplate.ViewModels
{
    public class ModalViewModel : BaseViewModel
    {
        public ModalViewModel(INavigationService navigationService,
           IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #region Commands
        public ICommand CloseModalViewCommand => new Command(async () => await OnCloseModalView());
        #endregion

        #region Private Methods
        private async Task OnCloseModalView()
        {
            await _navigationService.CloseModalView();
        }
        #endregion


    }
}
