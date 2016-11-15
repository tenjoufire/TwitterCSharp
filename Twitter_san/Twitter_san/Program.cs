using CoreTweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_san
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Tokens.Create("{API key}"
                  , "{API secret}"
                  , "{Access token}"
                  , "{Access token secret}");

            var text = "status text";
            tokens.Statuses.Update(new { status = text });


        }
    }
}