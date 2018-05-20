namespace ClassicalMusicShop.Website.Features.Home
{
    using System.Web.Mvc;
    using EPiServer.Web.Mvc;

    public class HomePageController : PageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return this.View(currentPage);
        }
    }
}