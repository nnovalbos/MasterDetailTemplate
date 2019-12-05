using System;
using System.IO;
using System.Linq;
using MasterDetailTemplate.Views;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MasterDetailTemplateUiTest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        
        static readonly Func<AppQuery, AppQuery> EnterButton = c => c.Marked("enterButton");
        static readonly Func<AppQuery, AppQuery> UserEntry = c => c.Marked("newEntry");
        static readonly Func<AppQuery, AppQuery> PasswordEntry = c => c.Marked("passwordEntry");



        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void SignInViewTest()
        {
            AppResult[] result = app.Query(EnterButton);
            bool isEnabled = (bool)result?.FirstOrDefault()?.Enabled;
            Assert.IsFalse(isEnabled);

            app.EnterText(PasswordEntry, "548");
            app.EnterText(x => x.Marked("newEntry"), "gmailcom");
           
            result = app.Query(EnterButton);
            isEnabled = (bool)result?.FirstOrDefault()?.Enabled;

            Assert.IsTrue(isEnabled);
            app.DismissKeyboard();
            app.Screenshot("EnterButton Enabled");
            app.Tap(EnterButton);
            app.Screenshot("FirstView");

        }
    }
}
