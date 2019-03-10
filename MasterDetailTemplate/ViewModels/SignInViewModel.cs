using System;
using System.Threading.Tasks;
using MasterDetailTemplate.Contracts.Services;
using MasterDetailTemplate.ViewModels.Base;
using Xamarin.Forms;

namespace MasterDetailTemplate.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        #region Attributes
        private string _userName;
        private string _userPassword;

        private IAuthenticationService _authenticationService;
        private ISettingsService _settingsService;
        #endregion

        public SignInViewModel(INavigationService navigationService, IDialogService dialogService,
         IAuthenticationService authenticationService, ISettingsService settingsService) : base(navigationService, dialogService)
        {
            _settingsService = settingsService;
            _authenticationService = authenticationService;

            SigInCommand = new Command(async(obj) => await OnSignInCommand(obj), HasDataChange);
        }

        #region Properties
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
                OnCanExecuteCommad();
            }
        }

        public string UserPassword
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
                OnPropertyChanged();
                OnCanExecuteCommad();
            }
        }

        #endregion

        #region Commands

        public Command SigInCommand { get; }

        #endregion

        #region Private Methods
        private void OnCanExecuteCommad()
        {
            SigInCommand.ChangeCanExecute();
        }


        private bool HasDataChange(object arg)
        {
            return !( string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_userPassword));
        }

        private async Task OnSignInCommand(object obj)
        {
            try
            {
                IsBusy = true;

                var userToken = await _authenticationService.Authenticate(UserName, UserPassword);
                if (userToken != null)
                {
                    _settingsService.UserTokenSetting = userToken;
                    _settingsService.UserNameSetting = UserName;
                    await _navigationService.NavigateToAsync<MainMasterDetailViewModel>();
                    IsBusy = false;
                }
                else
                {
                    IsBusy = false;
                    await _dialogService.ShowDialog("An error occurred during authentication", "Authentication Error", "OK");
                }
            }
            catch (Exception e)
            {
                IsBusy = false;
                await _dialogService.ShowDialog(e.Message, "Authentication Error", "OK");
            }
        }

        #endregion
    }
}
