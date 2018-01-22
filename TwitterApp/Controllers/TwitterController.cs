using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TwitterApp.BLL;
using TwitterApp.Models;

namespace TwitterApp.Controllers
{
    /// <summary>
    /// Web api method for async communication
    /// </summary>
    public class TwitterController : ApiController
    {
        public IHttpActionResult GetTweets()
        {
            return Ok(new { Tweets = new TwitterBO().GetTweets() });
        }

    }
}
