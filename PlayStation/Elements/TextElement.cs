using OpenQA.Selenium;

namespace PlayStation.Elements
{
    public class TextElement : BaseElement
    {
        public TextElement(By locator) : base(locator)
        {
        }

        public TextElement(IWebElement element) : base(element)
        {
        }
    }
}