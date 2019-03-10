namespace MasterDetailTemplate.Contracts.Services
{
    public interface ISettingsService
    {
        void AddItem(string key, string value);
        string GetItem(string key);

        string UserNameSetting { get; set; }
        string UserTokenSetting { get; set; }
    }
}