using OpenQA.Selenium;
using PlayStation.Elements;

namespace PlayStation.PageObjects
{
    public class PS5EquipmentPage
    {
        private static Button AccessoriusTab => new Button(By.XPath("//ul[@id='tertiary-menu-toggle']//a[contains(text(),'Akcesoria')]"));
        private static Button DualSenseControllerTab =>
            new Button(By.XPath("//ul[@id='tertiary-menu-toggle']//a[contains(text(),'Kontroler bezprzewodowy DualSense')]"));
        private static Button CosmicRedColorButton =>
            new Button(By.XPath("//div[contains(@class,'slider__controls--swatches')]//div[contains(@style,'#a91d4e')]"));
        private static MediaElement CosmicRedControllerImage =>
            new MediaElement(By.XPath("//div[@class='media-carousel__content']//picture[contains(@data-alt,'Cosmic Red')]"));

        public void OpenPS5AccessoriusList()
        {
            AccessoriusTab.Click();
        }

        public void OpenDualSenceInfo()
        {
            DualSenseControllerTab.Click();
        }

        public void SelectControllerColor()
        {
            CosmicRedColorButton.ScrollAndClick();
        }

        public bool IsCosmicRedControllerDisplayed() => CosmicRedControllerImage.IsDisplayed();
    }
}