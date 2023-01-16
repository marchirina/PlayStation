using OpenQA.Selenium;

namespace PlayStation.Elements
{
    public class MediaElement: BaseElement
    {
        public MediaElement(By locator) : base(locator)
        {
        }

        public MediaElement(IWebElement element) : base(element)
        {
        }
    }
}