using OpenQA.Selenium;

namespace PlayStation.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator) : base(locator)
        {
        }

        public void SendKeys(string text)
        {
            WaitForElementIsDisplayed();
            GetElement().SendKeys(text);
        }
    }
}