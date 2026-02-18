namespace AnalizeTweets.Data;

public class Tweets
{
    public DateTime DateData { get; set; }
    public List<Words>  Words { get; set; }
    public Location Location { get; set; }
    public double TweetWeight
    {
        get
        {
            double _totalTweetWeight = 0;
            
            foreach (var word in Words)
            {
                _totalTweetWeight += word.Weight;
            }
            return _totalTweetWeight / Words.Count != 0 ? _totalTweetWeight / Words.Count : 0;
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