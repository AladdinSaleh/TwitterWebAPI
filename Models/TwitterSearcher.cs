using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using LinqToTwitter;   

namespace TwitterWebAPI.Models
{
    public class TwitterSearcher
    {
        private SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {
            Credentials = new SingleUserInMemoryCredentials
            {
                ConsumerKey =
                "ConsumerKey",
                ConsumerSecret =
                "ConsumerSecret",
                TwitterAccessToken =
                "TwitterAccessToken",
                TwitterAccessTokenSecret =
                "TwitterAccessToken",

                //You should fill the values with your keys
            }
        };
        public List<Status> GetTop100Tweets()
        {
            var twitterContext = new TwitterContext(authorizer);
            List<Status> statusList = new List<Status>();

            List<Search> searchList = (from srch in twitterContext.Search
                                       where srch.Type == SearchType.Search &&
                                       srch.Query == "Microsoft" && 
                                       srch.Count == 100                                       
                                       select srch).ToList();

            if (searchList.Count > 0) 
                statusList = searchList[0].Statuses;  

            return statusList;
        }
    }
}