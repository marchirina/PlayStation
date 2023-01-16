using OpenQA.Selenium;
using PlayStation.Elements;

namespace PlayStation.PageObjects
{
    public class SearchResultsPage
    {
        public void OpenItemPage(string itemName)
        {
            new TextElement(By.XPath($"//div[contains(@data-category,'games')]//p[contains(text(),'{itemName}')]")).ScrollAndClick();
        }
    }
}