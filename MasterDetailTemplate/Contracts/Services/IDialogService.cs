using System;
using System.Threading.Tasks;

namespace MasterDetailTemplate.Contracts.Services
{
    public interface IDialogService
    {
        Task ShowDialog(string message, string title, string buttonLabel);

        void ShowToast(string message);

        Task ShowLoading<T>(string text, Func<Task<T>> function);
    }
}
