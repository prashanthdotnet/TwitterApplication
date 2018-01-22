using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TwitterApp.Models;

namespace TwitterApp.BLL
{
    public class TwitterBO : ITwitterBO
    {
        private readonly ITwitterDataBO objTwitterDataBO;
        public TwitterBO()
        {
            objTwitterDataBO = new TwitterDataBO();
        }
        public TwitterBO(TwitterDataBO obj)
        {
            objTwitterDataBO = obj;
        }

        /// <summary>
        /// Method to get tweets
        /// </summary>
        /// <returns></returns>
        public List<TwitterModel> GetTweets()
        {
            var tweets = new List<TwitterModel>();
            var jsonData = objTwitterDataBO.GetTwitterData();

            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                dynamic dataList = JsonConvert.DeserializeObject(jsonData);
                foreach (var item in dataList)
                {
                    tweets.Add(new TwitterModel
                    {
                        UserName = item.user?.name,
                        UserScreenName = item.user?.screen_name,
                        TweetDate = item.created_at,
                        TweetContent = item.text,
                        UserProfileImage = item.user?.profile_image_url,
                        RetweetCount = Convert.ToInt32(item.retweet_count ?? 0)
                    });
                }
            }
            return tweets;
        }

        public List<TwitterModel> SearchTweet(string q, List<TwitterModel> tweets)
        {
            if (!string.IsNullOrWhiteSpace(q))
            {
                //Searching for content
                tweets = tweets.Where(x => x.TweetContent.ToLower().Contains(q)).ToList();
            }

            return tweets;
        }
    }
}