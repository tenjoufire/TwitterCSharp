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

            var tokens = Tokens.Create(APIkey
                  , APIsecret
                  , AccessToken
                  , AccessTokenSecret);

            var text = "なにやってくれてるんだよ";
            try
            {
                tokens.Statuses.Update(new { status = text });
            }
            catch (Exception e)
            {
                Debug.WriteLine("error : " + e.Message);
            }
            


        }
    }
}