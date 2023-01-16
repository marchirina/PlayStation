using PlayStation.Configurations;

namespace PlayStation.TestCases
{
    public class BaseTest
    {
        [SetUp]
        public void SetUpTest()
        {
            Browser.InitializeBrowser();
            Browser.OpenFullScreen();
            Browser.OpenApplication(ConfigurationManager.AppSetting["URL"]);
            Browser.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }

        [TearDown]
        public void TearDownTest()
        {
            Browser.CloseDriver();
        }
    }
}