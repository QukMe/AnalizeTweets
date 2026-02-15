using AnalizeTweets.Service;

string fileName = "weekend_tweets2014.txt";
var parsedTweets = TweetsParser.ParseTweets(fileName);

Console.WriteLine();