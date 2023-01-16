using OpenQA.Selenium;
using PlayStation.Elements;

namespace PlayStation.PageObjects
{
    public class ItemPage
    {
        private static MediaElement TrailerVideoItem =>
            new MediaElement(By.XPath("//div[@class='game-hero__gallery']//div[contains(@class,'videoblock')][@data-slide='7']"));
        private static Button PlayVideoButton =>
            new Button(By.XPath("//div[@id='movie_player']//button[contains(@class,'ytp-large-play-button')]"));
        private static TextBox BirthDayTextBox => new TextBox(By.XPath("//input[@id='age-gate-day']"));
        private static TextBox BirthMonthTextBox => new TextBox(By.XPath("//input[@id='age-gate-month']"));
        private static TextBox BirthYearTextBox => new TextBox(By.XPath("//input[@id='age-gate-year']"));
        private static Button ConfirmAgeButton => new Button(By.XPath("//div[contains(text(),'Potwierdź swój wiek')]"));
        private static MediaElement TrailerVideoOngoingItem =>
            new MediaElement(By.XPath("//div[contains(@class,'playing-mode')][@id='movie_player']"));

        public void OpenTrailerGameVideo()
        {
            TrailerVideoItem.ScrollAndClick();
        }

        public void RunTrailerGameVideo(string videoName)
        {
            PlayVideoButton.SwitchToPopupAndClick(new MediaElement(By.XPath($"//iframe[contains(@title,'{videoName}')]")).GetElement());
        }

        public void InputBirthInformation(string day,string month,string year)
        {
            BirthDayTextBox.SendKeys(day);
            BirthMonthTextBox.SendKeys(month);
            BirthYearTextBox.SendKeys(year);
            ConfirmAgeButton.Click();
        }

        public bool IsTheVideoOnGoing(string videoName) =>
            TrailerVideoOngoingItem.SwitchToPopupAndIsDisplayed(new MediaElement(By.XPath($"//iframe[contains(@title,'{videoName}')]"))
                .GetElement());
    }
}