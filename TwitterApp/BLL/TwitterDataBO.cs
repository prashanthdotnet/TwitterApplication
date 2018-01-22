using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace TwitterApp.BLL
{
    public class TwitterDataBO : ITwitterDataBO
    {
        /// <summary>
        /// Method to get tweet data;
        /// </summary>
        /// <returns></returns>
        public virtual string GetTwitterData()
        {

            string twitterCredentials = ConfigurationManager.AppSettings["TwitterCredentials"];
            string screenName = ConfigurationManager.AppSettings["ScreenName"];
            string tweetCount = ConfigurationManager.AppSettings["TweetCount"];

            //Getting access token
            string access_token = "";
            var post = WebRequest.Create("https://api.twitter.com/oauth2/token") as HttpWebRequest;
            post.Method = "POST";
            post.ContentType = "application/x-www-form-urlencoded";
            post.Headers[HttpRequestHeader.Authorization] = "Basic " + twitterCredentials;
            var reqbody = Encoding.UTF8.GetBytes("grant_type=client_credentials");
            post.ContentLength = reqbody.Length;
            using (var req = post.GetRequestStream())
            {
                req.Write(reqbody, 0, reqbody.Length);
            }
            try
            {
                string respbody = null;
                using (var resp = post.GetResponse().GetResponseStream())
                {
                    var respR = new StreamReader(resp);
                    respbody = respR.ReadToEnd();
                }

                access_token = respbody.Substring(respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length, respbody.IndexOf("\"}") - (respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length));
            }
            catch(Exception ex)
            {
                throw;
            }

            var gettimeline = WebRequest.Create(string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count={0}&screen_name={1}", tweetCount, screenName)) as HttpWebRequest;
            gettimeline.Method = "GET";
            gettimeline.Headers[HttpRequestHeader.Authorization] = "Bearer " + access_token;
            try
            {
                string respbody = null;
                using (var resp = gettimeline.GetResponse().GetResponseStream())//there request sends
                {
                    var respR = new StreamReader(resp);
                    respbody = respR.ReadToEnd();
                }
                var data = respbody;
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}