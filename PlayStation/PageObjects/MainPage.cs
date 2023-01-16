using OpenQA.Selenium;
using PlayStation.Elements;

namespace PlayStation.PageObjects
{
    public class MainPage
    {
        private static Button TechnicalSupportTab => new Button(By.XPath("//button[@id='menu-button-primary--msg-support']"));
        private static Button TechnicalSupportButton => new Button(By.XPath("//a[@id='link-secondary--msg-support']"));
        private static Button SearchButton => new Button(By.XPath("//button[@data-qa='shared-nav-search-button']"));
        private static TextBox SearchTextBox => new TextBox(By.XPath("//input[@data-qa='search-text-box']"));
        private static Button NewsTab => new Button(By.XPath("//button[@id='menu-button-primary--msg-news']"));
        private static Button PSBlogButton => new Button(By.XPath("//a[@id='link-secondary--msg-ps-blog']"));
        private static Button HardwareTab => new Button(By.XPath("//button[@id='menu-button-primary--msg-hardware']"));
        private static Button PS5EquipmentButton =>
            new Button(By.XPath("//div[contains(@class,'shared-nav__secondary-parent--msg_hardware')]//a[@id='link-secondary--msg-ps5']"));
        
        public void OpenTechnicalSupportPage()
        {
            TechnicalSupportTab.Click();
            TechnicalSupportButton.Click();
        }

        public void SearchForItem(string itemName)
        {
            SearchButton.Click();
            SearchTextBox.SendKeys(itemName);
            SearchTextBox.SendKeys(Keys.Enter);
        }

        public void OpenPSBlogPage()
        {
            NewsTab.Click();
            PSBlogButton.Click();
        }

        public void OpenEquipmentPage()
        {
            HardwareTab.Click();
            PS5EquipmentButton.Click();
        }
    }
}