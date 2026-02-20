namespace AnalizeTweets.Data;

public class Polygon
{
    public List<Location> Points { get; set; }

    public Polygon(List<Location> points)
    {
        Points = points;
    }
}