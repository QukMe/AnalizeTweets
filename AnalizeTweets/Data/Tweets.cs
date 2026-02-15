namespace AnalizeTweets.Data;

public class Tweets
{
    public DateTime DateData { get; set; }
    public List<Words>  Words { get; set; }
    public Location Location { get; set; }
    public double TweetWeight { get; set; }

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