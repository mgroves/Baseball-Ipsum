using System.Text;

namespace BaseballIpsum;

public class ParagraphGenerator
{
    SentenceGenerator _sent;
    Random _rand;

    public ParagraphGenerator(SentenceGenerator sent)
    {
        _sent = sent;
        _rand = new Random(DateTime.Now.Millisecond);
    }

    public string GetParagraph()
    {
        var numSentences = _rand.Next(6, 7);
        var sb = new StringBuilder();
        var comma = _rand.Next(0, numSentences);
        for (int i = 0; i < numSentences; i++)
        {
            if (i == comma)
                sb.Append(_sent.GetRandomSentence(true));
            else
                sb.Append(_sent.GetRandomSentence());
            sb.Append(' ');
        }
        return sb.ToString().Trim();
    }
}