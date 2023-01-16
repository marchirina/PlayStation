using PlayStation.PageObjects;

namespace PlayStation.TestCases.News
{
    public class ReadPSBlog : BaseTest
    {
        [Test]
        public void ReadLatestPS5News()
        {
            Pages.Main.OpenPSBlogPage();
            Pages.PSBlog.OpenPS5NewsPage();
            Pages.PSBlog.OpenArticlePage("Share of the Year 2022");
            Assert.IsTrue(Pages.PSBlog.IsArticleDisplayed("Share of the Year 2022"));
        }
    }
}