using System;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.ViewModels.Base;

namespace MasterDetailTemplate.ViewModels
{
    public class NavigationDetailViewModel : BaseViewModel
    {
        public NavigationDetailViewModel(INavigationService navigationService,
           IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
