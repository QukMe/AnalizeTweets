namespace AnalizeTweets.Data;

public class State
{
    public string Code { get; set; }
    public List<Polygon> Polygons { get; set; } = new List<Polygon>();

    public Location Centroid
    {
        get
        {
            var centroid = new Location();
            foreach (Polygon polygon in Polygons)
            {
                var points = polygon.Points;
                foreach (Location point in points)
                {
                    centroid.Latitude += point.Latitude;
                    centroid.Longitude += point.Longitude;
                }
            }
            return centroid;
        }
    }

    public State()
    {
        
    }
}