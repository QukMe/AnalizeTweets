namespace AnalizeTweets.Data;

public class Words
{
    public string Word { get; set; }
    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if(value >= -1 && value <= 1)
            {
                _weight = value;
            }
        }
    }

    public Words()
    {
        
    }

    public Words(string word)
    {
        Word = word;
    }

    public Words(string word, double weight)
    {
        Word = word;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{Word}";
    }

    public override bool Equals(object? obj)
    {
        if (this.GetType() != obj.GetType())
        {
            return false;
        }
        
        Words word = (Words)obj;
        return this.Word == word.Word && this.Weight == word.Weight;
    }
}