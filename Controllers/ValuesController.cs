using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwitterWebAPI.Models;
using LinqToTwitter;

namespace TwitterWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Status> Get()
        {
            TwitterSearcher srch = new TwitterSearcher();
            MongoDBHelper mongo = new MongoDBHelper();

            List<Status> AllTweets = srch.GetTop100Tweets();
            mongo.InsertTweetByLinq(AllTweets);

            return AllTweets;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}