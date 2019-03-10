using System.Threading.Tasks;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.ViewModels.Base;

namespace MasterDetailTemplate.ViewModels
{
    public class MainMasterDetailViewModel : BaseViewModel
    {
        private MenuViewModel _menuViewModel;

        public MainMasterDetailViewModel(INavigationService navigationService, IDialogService dialogService, MenuViewModel menuViewModel) : base(navigationService, dialogService)
        {
            _menuViewModel = menuViewModel;
        }

        #region Properties
        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public override async Task InitializeAsync(object parameter)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(parameter),
                _navigationService.NavigateToAsync<FirstViewModel>()
            );
        }
    }
}
