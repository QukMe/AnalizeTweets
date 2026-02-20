using System.Drawing;
using System.Text.Json;
using System.Text.Json.Nodes;
using AnalizeTweets.Data;

namespace AnalizeTweets.Service;

public static class StatesParser
{
    public static List<State> ParseStates(string fileName)
    {
        var parsedJson = JsonNode.Parse(File.ReadAllText(fileName)).AsObject();
        
        var states = new List<State>();

        foreach (var keyState in parsedJson)
        {
            var state = new State();
            state.Code = keyState.Key;
            
            var value = keyState.Value.AsArray();
            

            if (value [0]![0]![0]! is JsonArray)
            {
                foreach (var poly in value)
                {
                    JsonArray array = poly[0].AsArray();
                    state.Polygons.Add(InitPolygon(array));
                }
            }
            else
            {
                JsonArray array = value[0].AsArray();
                state.Polygons.Add(InitPolygon(array));
            }
            states.Add(state);
        }
        return states;
    }

    private static Polygon InitPolygon(JsonArray array)
    {
        var polygonPoints = new List<Location>();
        foreach (var point in array)
        {
            polygonPoints.Add(new Location((double)point[1], (double)point[0]));
        }
        return new Polygon(polygonPoints);
    }
}