using System.Text.RegularExpressions;
using AnalizeTweets.Data;
using System.Globalization;

namespace AnalizeTweets.Service;

public static class TweetsParser
{
    public static List<Tweets> ParseTweets(string tweetsFileName, string sentimentsFileName)
    {
        var tweets = new List<Tweets>();
        var sentiments = SentimentsParser.ParseSentiments(sentimentsFileName);

        var regexTweetsLocation = new Regex(@"-?\d+\.\d+");
        var regexDateData = new Regex(@"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}");
        var regexTweetsText = new Regex(@"\t([^\t]+)$");
        var regexTweetsWords = new Regex(@"[A-Za-z]+");
        
        using (var streamReader = new StreamReader(tweetsFileName))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var tweet = new Tweets(
                    GetDateData(line, regexDateData), 
                    GetTweetsWords(GetTweetsText(line, regexTweetsText), sentiments, regexTweetsWords), 
                    GetTweetsLocation(line, regexTweetsLocation)
                    );
                tweets.Add(tweet);
            }
        }
        return tweets;
    }

    private static Location GetTweetsLocation(string line, Regex regex)
    {
        var tweetsLocation = regex.Matches(line);
        double latitude = double.Parse(tweetsLocation[0].Value, CultureInfo.InvariantCulture);
        double longitude = double.Parse(tweetsLocation[1].Value, CultureInfo.InvariantCulture);
        
        return new Location(latitude, longitude);
    }

    private static DateTime GetDateData(string line, Regex regex)
    {
        var dateData = regex.Match(line);
        DateTime date = DateTime.Parse(dateData.Value);
        
        return date;
    }

    private static Match GetTweetsText(string line, Regex regex)
    {
        return regex.Match(line);
    }

    private static List<Words> GetTweetsWords(Match tweetText, Dictionary<string, double> sentiments, Regex regex)
    {
        var tweetWords = regex.Matches(tweetText.Value);
        
        var words = new List<Words>();

        foreach (Match word  in tweetWords)
        {
            string wordText = word.Value;
            double weight = 0;
            if (sentiments.TryGetValue(wordText.ToLower(), out double wordWeight))
            {
                weight += wordWeight;
            }
            words.Add(new Words(wordText, weight));
        }
        
        return words;
    }
}