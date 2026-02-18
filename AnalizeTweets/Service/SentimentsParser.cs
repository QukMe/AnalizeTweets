using AnalizeTweets.Data;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace AnalizeTweets.Service;

public static class SentimentsParser
{
    public static Dictionary<string, double> ParseSentiments(string fileName)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
        };
        
        using (var reader = new StreamReader(fileName))
        using (var csv = new CsvReader(reader, config))
        {
            var sentiments = csv.GetRecords<Words>();
            var sentimentsDictionary = new Dictionary<string, double>();
            foreach (var sr in sentiments)
            {
                sentimentsDictionary.Add(sr.Word, sr.Weight);
            }
            return sentimentsDictionary;
        }
    }
}