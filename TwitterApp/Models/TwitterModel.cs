using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterApp.Models
{
    public class TwitterModel
    {
        public string UserName { get; set; }
        public string UserScreenName { get; set; }
        public string UserProfileImage { get; set; }
        public string TweetContent { get; set; }
        public int RetweetCount { get; set; }
        public string TweetDate { get; set; }
    }
}