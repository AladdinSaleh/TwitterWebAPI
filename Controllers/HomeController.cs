using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http; 
using TwitterWebAPI.Models;

namespace TwitterWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MongoDBHelper mongo = new MongoDBHelper();
            List<Tweet> tweetLst = mongo.GetTopFollowers();

            return View(tweetLst);
        }
        public ActionResult TopRetweets()
        {
            MongoDBHelper mongo = new MongoDBHelper();
            List<Tweet> tweetLst = mongo.GetTopRetweets();

            return View(tweetLst);
        }
        public ActionResult TopFavourited()
        {
            MongoDBHelper mongo = new MongoDBHelper();
            List<Tweet> tweetLst = mongo.GetTopFavourite();

            return View(tweetLst);
        }
    }
}
