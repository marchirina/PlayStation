using PlayStation.PageObjects;

namespace PlayStation.TestCases.Support
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
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