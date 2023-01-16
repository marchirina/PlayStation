using System.Collections.Concurrent;
using PlayStation.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace PlayStation
{
    public static class Browser
    {
        private static ConcurrentDictionary<string, IWebDriver> Drivers = new ConcurrentDictionary<string, IWebDriver>();
        public static TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(TestSettings.PollingInterval);
        public static TimeSpan Timeout = TimeSpan.FromSeconds(TestSettings.Timeout);

        public static IWebDriver Driver
        {
            get
            {
                return Drivers.First(pair => pair.Key == TestContext.CurrentContext.Test.ClassName).Value;
            }
            set => Drivers.TryAdd(TestContext.CurrentContext.Test.ClassName, value);
        }

        public static void InitializeBrowser()
        {
            switch (TestSettings.Browser)
            {
                case "Firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (Boolean.Parse(TestSettings.IsHeadlessMode))
                    {
                        firefoxOptions.AddArgument("--headless");
                    }
                    var firefoxDriver = new FirefoxDriver(firefoxOptions);
                    Driver = firefoxDriver;
                    break;

                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    if (Boolean.Parse(TestSettings.IsHeadlessMode))
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    var chromeDriver = new ChromeDriver(chromeOptions);
                    Driver = chromeDriver;
                    break;

                default:
                    throw new ArgumentException("Browser is not initialized!");
            }
        }

        public static void OpenApplication(string url)
        {
            Driver.Url = url;
        }

        public static void OpenFullScreen()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void GoBackToPage()
        {
            Driver.Navigate().Back();
        }

        public static object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        public static WebDriverWait Wait(TimeSpan timeout = default, TimeSpan pollingInterval = default, Type[] exceptionTypes = null)
        {
            timeout = timeout.Ticks == 0 ? Timeout : timeout;
            pollingInterval = pollingInterval.Ticks == 0 ? DefaultPollingInterval : pollingInterval;

            var wait = new WebDriverWait(Driver, timeout)
            {
                PollingInterval = pollingInterval
            };

            wait.IgnoreExceptionTypes(exceptionTypes ?? new[] { typeof(StaleElementReferenceException) });

            return wait;
        }

        public static void CloseDriver()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}