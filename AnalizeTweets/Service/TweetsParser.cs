using System.Text.RegularExpressions;
using AnalizeTweets.Data;
using System.Globalization;

namespace AnalizeTweets.Service;

public static class TweetsParser
{
    public static List<Tweets> ParseTweets(string fileName)
    {
        var tweets = new List<Tweets>();
        var readLine = new List<String>();
        using (var streamReader = new StreamReader(fileName))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                readLine.Add(line);
            }
        }
        
        foreach (var line in readLine)
        {
            var tweet = new Tweets(GetDateData(line), GetTweetsWords(GetTweetsText(line)), GetTweetsLocation(line));
            tweets.Add(tweet);
        }
        return tweets;
    }

    private static Location GetTweetsLocation(string line)
    {
        string pattern = @"-?\d+\.\d+";
        var _regex = new Regex(pattern);
        
        var tweetsLocation = _regex.Matches(line);
        double latitude = double.Parse(tweetsLocation[0].Value, CultureInfo.InvariantCulture);
        double longitude = double.Parse(tweetsLocation[1].Value, CultureInfo.InvariantCulture);
        
        return new Location(latitude, longitude);
    }

    private static DateTime GetDateData(string line)
    {
        string pattern = @"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}";
        var _regex = new Regex(pattern);
        
        var dateData = _regex.Match(line);
        DateTime date = DateTime.Parse(dateData.Value);
        
        return date;
    }

    private static Match GetTweetsText(string line)
    {
        string pattern = @"\t([^\t]+)$";
        var _regex = new Regex(pattern);
        
        return _regex.Match(line);
    }

    private static List<Words> GetTweetsWords(Match tweetText)
    {
        string pattern = @"[A-Za-z]+";
        var _regex = new Regex(pattern);
        
        var tweetWords = _regex.Matches(tweetText.Value);
        
        var words = new List<Words>();

        foreach (var word in tweetWords)
        {
            words.Add(new Words(word.ToString()));
        }
        
        return words;
    }
}