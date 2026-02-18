using AnalizeTweets.Service;

string tweetsFileName = "weekend_tweets2014.txt";
string sentimentsFileName = "sentiments.csv";
var parsedTweets = TweetsParser.ParseTweets(tweetsFileName, sentimentsFileName);

