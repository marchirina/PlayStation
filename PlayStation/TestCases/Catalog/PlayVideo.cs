using PlayStation.PageObjects;

namespace PlayStation.TestCases.Catalog
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class PlayVideo : BaseTest
    {
        [Test]
        public void PlayGameTrailer()
        {
            Pages.Main.SearchForItem("God of War Ragnarök");
            Pages.Search.OpenItemPage("God of War Ragnarök");
            Pages.Item.OpenTrailerGameVideo();
            Pages.Item.InputBirthInformation("21", "12", "1996");
            Pages.Item.RunTrailerGameVideo("God of War Ragnarök - Launch Trailer");
            Assert.IsTrue(Pages.Item.IsTheVideoOnGoing("God of War Ragnarök - Launch Trailer"));
        }
    }
}