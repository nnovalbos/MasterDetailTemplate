using System;
using MasterDetailTemplate.Contracts.Services;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MasterDetailTemplate.Services
{
    public class SettingsService : ISettingsService
    {
        #region Properties
        private readonly ISettings _settings;
        private const string Username = "Username";
        private const string UserToken = "UserId";
        #endregion

        public SettingsService()
        {
            _settings = CrossSettings.Current;
        }

        #region Properties

        public void AddItem(string key, string value)
        {
            _settings.AddOrUpdateValue(key, value);
        }

        public string GetItem(string key)
        {
            return _settings.GetValueOrDefault(key, string.Empty);
        }

        public string UserNameSetting
        {
            get => GetItem(Username);
            set => AddItem(Username, value);
        }


        public string UserTokenSetting
        {
            get => GetItem(UserToken);
            set => AddItem(UserToken, value);
        }

        #endregion

    }
}
