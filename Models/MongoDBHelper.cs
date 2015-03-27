using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using TwitterWebAPI.Controllers;
using LinqToTwitter; 

namespace TwitterWebAPI.Models
{
    public class MongoDBHelper
    {
        MongoDatabase mongoDatabase;
        private void InitializeDB()
        {
            string connectionString = "Server=localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            mongoDatabase = server.GetDatabase("test");
        }

        public void InsertTweetByLinq(List<Status> AllTweets)
        {
            InitializeDB();

            mongoDatabase.GetCollection<BsonDocument>("statuses").RemoveAll(); //Removing all documents
            MongoCollection<BsonDocument> Tweets = mongoDatabase.GetCollection<BsonDocument>("statuses");

            foreach (Status item in AllTweets)
            {
                BsonDocument status = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(item.ToBson());
                Tweets.Insert(status);
            }
        }

        public List<Tweet> GetTopFollowers()
        {
            InitializeDB();

            var collection = mongoDatabase.GetCollection<Tweet>("statuses");
            List<Tweet> Top5 = (from tweet in collection.FindAll()
                                orderby tweet.User.FollowersCount descending
                                select tweet).Take(5).ToList();
            return Top5;
        }
        public List<Tweet> GetTopRetweets()
        {
            InitializeDB();

            var collection = mongoDatabase.GetCollection<Tweet>("statuses");
            List<Tweet> Top5 = (from tweet in collection.FindAll()
                                orderby tweet.RetweetCount descending
                                select tweet).Take(5).ToList(); 
            return Top5;
        }
        public List<Tweet> GetTopFavourite()
        {
            InitializeDB();

            var collection = mongoDatabase.GetCollection<Tweet>("statuses");
            List<Tweet> Top5 = (from tweet in collection.FindAll()
                                orderby tweet.FavoriteCount descending
                                select tweet).Take(5).ToList();
            return Top5;
        }   
    }
}