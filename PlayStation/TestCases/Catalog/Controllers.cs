using PlayStation.PageObjects;

namespace PlayStation.TestCases.Catalog
{
    public class Controllers : BaseTest
    {
        [Test]
        public void ChangeControllerColorToCosmicRed()
        {
            Pages.Main.OpenEquipmentPage();
            Pages.PS5Equipment.OpenPS5AccessoriusList();
            Pages.PS5Equipment.OpenDualSenceInfo();
            Pages.PS5Equipment.SelectControllerColor();
            Assert.IsTrue(Pages.PS5Equipment.IsCosmicRedControllerDisplayed());
        }
    }
}