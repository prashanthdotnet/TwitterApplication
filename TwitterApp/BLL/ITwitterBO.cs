using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterApp.Models;

namespace TwitterApp.BLL
{
    public interface ITwitterBO
    {
        /// <summary>
        /// Method to get tweets
        /// </summary>
        /// <returns></returns>
        List<TwitterModel> GetTweets();

        List<TwitterModel> SearchTweet(string q, List<TwitterModel> tweets);
    }
}