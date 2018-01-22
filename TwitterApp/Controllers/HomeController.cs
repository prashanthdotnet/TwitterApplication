using System.Web.Mvc;
using TwitterApp.BLL;

namespace TwitterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITwitterBO _twitterBo;

        public HomeController()
        {
            _twitterBo = new TwitterBO();
        }

        public HomeController(ITwitterBO twitterBo)
        {
            _twitterBo = twitterBo;
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetTweets(string q = null)
        {
            var tweets = _twitterBo.GetTweets();
            tweets = _twitterBo.SearchTweet(q, tweets);

            return PartialView(tweets);
        }
    }
}