namespace BaseballIpsum;

public class IpsumDictionary
{
    readonly string[] _words;
    readonly Random _rand;
    readonly int _numWords;

    public IpsumDictionary()
    {
        _rand = new Random(DateTime.Now.Millisecond);
        _words = LoadFromTxtFile();
        _numWords = _words.Length;
    }

    string[] LoadFromTxtFile()
    {
        var assembly = GetType().Assembly;
        using(var stream = assembly.GetManifestResourceStream("BaseballIpsum.words.txt"))
        {
            using(var reader = new StreamReader(stream))
            {
                var words = new List<string>();
                string line;
                while((line = reader.ReadLine()) != null)
                    words.Add(line.Trim());
                return words.ToArray();
            }
        }
    }

    public string GetRandomWord()
    {
        return _words[_rand.Next(0, _numWords-1)];
    }
}