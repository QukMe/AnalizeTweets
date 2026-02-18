namespace AnalizeTweets.Data;

public class Tweets
{
    public DateTime DateData { get; set; }
    public List<Words>  Words { get; set; }
    public Location Location { get; set; }
    public double? TweetWeight
    {
        get
        {
            double? _totalTweetWeight = null;
            int count = 0;
            
            foreach (var word in Words)
            {
                if (word.Weight != null)
                {
                    if (_totalTweetWeight == null)
                    {
                        _totalTweetWeight = word.Weight.Value;
                        count++;
                        continue;
                    }
                    _totalTweetWeight += word.Weight.Value;
                    count++;
                }
            }
            return _totalTweetWeight == 0  ? 0 : (_totalTweetWeight == null ? _totalTweetWeight : _totalTweetWeight / count);
        }
    }

    public Tweets()
    {
        
    }

    public Tweets(DateTime dateData, List<Words> words, Location location)
    {
        DateData = dateData;
        Words = words;
        Location = location;
    }

    public Tweets(List<Words> words, Location location)
    {
        Words = words;
        Location = location;
    }

    public Tweets(Location location)
    {
        Location = location;
    }
}