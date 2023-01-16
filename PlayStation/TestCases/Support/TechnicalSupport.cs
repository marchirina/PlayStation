using PlayStation.PageObjects;

namespace PlayStation.TestCases.Support
{
    public class TechnicalSupport : BaseTest
    {
        [Test]
        public void FindAnswerHowToReturnTheOrder()
        {
            Pages.Main.OpenTechnicalSupportPage();
            Pages.TechSupport.OpenPSStoreAndMoneyBackPage();
            Pages.TechSupport.OpenRetrurnsInfo();
            Assert.IsTrue(Pages.TechSupport.IsAnswerDisplayed());
        }
    }
}