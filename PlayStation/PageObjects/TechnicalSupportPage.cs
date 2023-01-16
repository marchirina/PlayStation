using OpenQA.Selenium;
using PlayStation.Elements;

namespace PlayStation.PageObjects
{
    public class TechnicalSupportPage
    {
        private static Button PSStoreAndMoneyBackIcon => new Button(By.XPath("//div[@class='tile__btn']/span[contains(text(),'PS Store i zwrot pieniędzy')]"));
        private static Button ReturnsIcon => new Button(By.XPath("//div[@class='tile__btn ']/span[contains(text(),'Zwroty')]"));
        private static TextElement AnswerHeader => new TextElement(By.XPath("//h4[contains(text(),'Anulowanie zakupów i zarządzanie nimi')]"));

        public void OpenPSStoreAndMoneyBackPage()
        {
            PSStoreAndMoneyBackIcon.ScrollToElement();
            PSStoreAndMoneyBackIcon.Click();
        }

        public void OpenRetrurnsInfo()
        {
            ReturnsIcon.ScrollToElement();
            ReturnsIcon.Click();
        }

        public bool IsAnswerDisplayed() => AnswerHeader.IsDisplayed();
    }
}