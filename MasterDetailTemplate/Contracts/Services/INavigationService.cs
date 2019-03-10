using System;
using System.Threading.Tasks;
using MasterDetailTemplate.ViewModels.Base;

namespace MasterDetailTemplate.Contracts.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);

       // Task NavigateToAsync(Type viewModelType, object parameter);

        Task CloseModalView();
    }
}
