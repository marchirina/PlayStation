using OpenQA.Selenium;
using PlayStation.Configurations;

namespace PlayStation.Elements
{
    public abstract class BaseElement
    {
        private readonly IWebElement _element;
        private readonly By _locator;
        public static TimeSpan Timeout = TimeSpan.FromSeconds(Convert.ToDouble(TestSettings.Timeout));
        private IWebElement Element => _element ?? Browser.Driver.FindElements(_locator).FirstOrDefault();

        protected BaseElement(By locator)
        {
            _locator = locator;
        }

        protected BaseElement(IWebElement element)
        {
            _element = element;
        }

        public void Click() => Browser
            .Wait(exceptionTypes: new[] { typeof(ElementNotInteractableException), typeof(ElementClickInterceptedException), typeof(StaleElementReferenceException) })
            .Until(waiting =>
            {
                Element.Click();

                return true;
            });

        public void ScrollAndClick()
        {
            ScrollToElement();
            Click();
        }
              
        public void WaitForElementIsDisplayed(int? timeout = null) =>
            Browser.Wait(timeout == null ? Timeout : TimeSpan.FromMilliseconds((int)timeout))
            .Until(drv => Element.Enabled && Element.Displayed);

        public bool IsDisplayed(int timeout = 3000)
        {
            try
            {
                WaitForElementIsDisplayed(timeout);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IWebElement GetElement()
        {
            WaitForElementIsDisplayed();

            return Element;
        }

        public void ScrollToElement() =>
            Browser.ExecuteJavaScript("arguments[0].scrollIntoView({block: 'center'});", Element);

        public void SwitchToPopupAndClick(IWebElement element)
        {
            Browser.Driver.SwitchTo().Frame(element);
            Click();
            Browser.Driver.SwitchTo().DefaultContent();
        }

        public bool SwitchToPopupAndIsDisplayed(IWebElement element)
        {
            try
            {
                Browser.Driver.SwitchTo().Frame(element);
                WaitForElementIsDisplayed();
                Browser.Driver.SwitchTo().DefaultContent();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}