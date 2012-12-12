using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Twitterizer;

namespace TestApplication
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string consumerKey;
        public string ConsumerKey
        {
            get { return consumerKey; }
            set { 
                consumerKey = value;
                this.OnPropertyChanged(() => this.ConsumerKey);
            }
        }

        private string consumerSecret;
        public string ConsumerSecret
        {
            get { return consumerSecret; }
            set { 
                consumerSecret = value;
                this.OnPropertyChanged(() => this.ConsumerSecret);
            }
        }

        private string accessKey;
        public string AccessKey
        {
            get { return accessKey; }
            set { 
                accessKey = value;
                this.OnPropertyChanged(() => this.AccessKey);
            }
        }

        private string accessSecret;
        public string AccessSecret
        {
            get { return accessSecret; }
            set { 
                accessSecret = value;
                this.OnPropertyChanged(() => this.AccessSecret);
            }
        }

        private ObservableCollection<TabItem> tabItems;
        public ObservableCollection<TabItem> TabItems
        {
            get { return tabItems; }
            set { 
                tabItems = value;
                this.OnPropertyChanged(() => this.TabItems);
            }
        }

        private readonly RelayCommand verifyCommand;
        public RelayCommand VerifyCommand
        {
            get { return verifyCommand; }
        }

        private ObservableCollection<TwitterStatus> tweets;
        public ObservableCollection<TwitterStatus> Tweets
        {
            get { return tweets; }
            set { 
                tweets = value;
                this.OnPropertyChanged(() => this.Tweets);
            }
        }
        

        public MainWindowViewModel()
        {
            this.ConsumerKey = "c3Ea5h1dj9Kfeg95p4l4xA";
            this.ConsumerSecret = "PMbKKWbkPTeMCHsKU1JaXc1v1H0QrgDyALAnv4rZjQ";
            this.AccessKey = "14725805-lULH7i9IdPX9Fjuw4LszaBFYQecjNkKL0OYYWz2fB";
            this.AccessSecret = "hXV9ln0ZVrq81rHItNmw6mTY7qlzkhWN0DsaHJAv9U";

            this.verifyCommand = new RelayCommand(VerifyCredentials);
            
        }

        public async void VerifyCredentials()
        {
            var tokens = new OAuthTokens()
                       {
                           ConsumerKey = this.ConsumerKey,
                           ConsumerSecret = this.ConsumerSecret,
                           AccessToken = this.AccessKey,
                           AccessTokenSecret = this.AccessSecret
                       };

            var timelineResponse = await TwitterTimeline.HomeTimeline(tokens: tokens);

            this.Tweets = new ObservableCollection<TwitterStatus>();

            foreach (var item in timelineResponse.ResponseObject)
            {
                this.Tweets.Add(item);
            }
        }
    }
}
