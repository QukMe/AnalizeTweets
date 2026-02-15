namespace AnalizeTweets.Data;

public class Location
{
    private double _latitude;
    private double _longitude;

    public double Latitude
    {
        get => _latitude;
        set
        {
            if (value >= -90.0 && value <= 90.0)
            {
                _latitude = value;
            }
        }
    }
    public double Longitude
    {
        get => _longitude;
        set
        {
            if (value >= -180.0 && value <= 180.0)
            {
                _longitude = value;
            }
        }
    }

    public Location()
    {
      
    }

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}