using OpenQA.Selenium;
using PlayStation.Elements;

namespace PlayStation.PageObjects
{
    public class PSBlogPage
    {
        private static Button PS5Tab => new Button(By.XPath("//div[@class='primary-menu-container']//a[contains(text(),'PS5')]"));
       
        public void OpenPS5NewsPage()
        {
            PS5Tab.Click();
        }

        public void OpenArticlePage(string articleName)
        {
            new TextElement(By.XPath($"//h2[@class='post-card__title']/a[contains(text(),'{articleName}')]")).ScrollAndClick();
        }

        public bool IsArticleDisplayed(string articleName) =>
            new TextElement(By.XPath($"//h1[contains(text(),'{articleName}')]")).IsDisplayed();
    }
}