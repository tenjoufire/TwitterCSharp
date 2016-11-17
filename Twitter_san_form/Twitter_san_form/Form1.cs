using CoreTweet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitter_san_form
{
    public partial class Form1 : Form
    {
        private TextBox tweet;
        private Button refresh, send;
        private Label timeLine;
        private Panel timeLinePanel;
        private string APIkey, APIsecret, AccessToken, AccessTokenSecret;
        private Tokens tokens;


        public Form1()
        {


            InitializeComponent();
            this.Text = "エセTwitter";
            this.Width = 512;
            this.Height = 700;

            refresh = new Button();
            refresh.Parent = this;
            refresh.Text = "reflesh";
            refresh.Location = new Point(100, 0);
            refresh.Click += new EventHandler(RefreshClick);

            send = new Button();
            send.Parent = this;
            send.Text = "send tweet";
            send.Location = new Point(300, 0);
            send.Click += new EventHandler(TweetClick);

            tweet = new TextBox();
            tweet.Multiline = true;
            tweet.Size = new Size(200, 150);
            tweet.Location = new Point(280, 30);
            tweet.BackColor = Color.Azure;
            tweet.MaxLength = 140;

            timeLinePanel = new Panel();
            timeLinePanel.AutoScroll = true;
            timeLinePanel.Location = new Point(10, 30);
            timeLinePanel.Size = new Size(270, 600);
            timeLinePanel.AutoScrollPosition = new Point(timeLinePanel.Width + 50, 30);

            timeLine = new Label();
            timeLine.Text = "";
            timeLine.Parent = timeLinePanel;
            timeLine.AutoSize = false;
            timeLine.Location = new Point(0, 0);
            timeLine.Size = new Size(250, 2300);


            Controls.Add(tweet);
            Controls.Add(refresh);
            Controls.Add(timeLinePanel);
            Controls.Add(send);

            Auth();

        }

        private void Auth()
        {
            // get strings from App.config
            APIkey = ConfigurationManager.AppSettings["APIkey"];
            APIsecret = ConfigurationManager.AppSettings["APIsecret"];
            AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
            //認証します
            tokens = Tokens.Create(APIkey
                  , APIsecret
                  , AccessToken
                  , AccessTokenSecret);
            LoadTweets();

        }

        private void LoadTweets()
        {
            //get Home TL
            var home = tokens.Statuses.HomeTimeline(count => 20);
            foreach (var tweet in home)
            {
                timeLine.Text += tweet.User.Name + " @" + tweet.User.ScreenName + "\n\n";
                timeLine.Text += tweet.Text + "\n";
                timeLine.Text += "\n========================\n\n";
            }


        }

        private void PostTweet(string text)
        {
            tokens.Statuses.Update(new { status = text });
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            timeLine.Text = "";
            try
            {
                LoadTweets();
            }
            catch (Exception ex)
            {
                timeLine.Text = ex.Message + "\n 読み込み失敗！！！";
            }
        }

        private void TweetClick(object sender, EventArgs e)
        {
            try
            {
                PostTweet(tweet.Text);
                tweet.Text = "";
            }
            catch(Exception ex)
            {

            }
        }
    }
}
