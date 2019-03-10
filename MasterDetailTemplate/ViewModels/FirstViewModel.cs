using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.ViewModels.Base;

namespace MasterDetailTemplate.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public FirstViewModel(INavigationService navigationService,
            IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
