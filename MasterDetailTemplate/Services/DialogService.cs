using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MasterDetailTemplate.Contracts.Services;

namespace MasterDetailTemplate.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowDialog(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public async Task ShowLoading<T>(string text, Func<Task<T>> function)
        {
            using (UserDialogs.Instance.Loading(text, null, null, true, MaskType.Black))
            {
                await function();
            }
        }

        public void ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
    }
}
