using CoreTweet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_san
{
    class Program
    {
        static void Main(string[] args)
        {
            // get strings from App.config
            string APIkey = ConfigurationManager.AppSettings["APIkey"];
            string APIsecret = ConfigurationManager.AppSettings["APIsecret"];
            string AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            string AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];

            //Console.WriteLine(APIkey + " " + APIsecret + " " + AccessToken + " " + AccessTokenSecret); //for debug

            //認証します
            var tokens = Tokens.Create(APIkey
                  , APIsecret
                  , AccessToken
                  , AccessTokenSecret);

            //get Home TL
            var home = tokens.Statuses.HomeTimeline(count => 30);

            //standerd output
            foreach(var tweet in home)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine(tweet.User.Name + " @" + tweet.User.ScreenName);
                Console.WriteLine(tweet.Text + "\n");
            }


            /*
             var text = "YSD";
            try
            {
                tokens.Statuses.Update(new { status = text });
            }
            catch (Exception e)
            {
                Debug.WriteLine("error : " + e.Message);
            }
            */



        }
    }
}