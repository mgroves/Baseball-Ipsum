namespace BaseballIpsum.Web.Models;

public class ParagraphService
{
    readonly ParagraphGenerator _paragraphGenerator;

    public ParagraphService()
    {
        var dict = new IpsumDictionary();
        var sent = new SentenceGenerator(dict);
        _paragraphGenerator = new ParagraphGenerator(sent);
    }

    public List<string>? GetParagraphs(int paras, bool startwithlorem)
    {
        var generatedParagraphs = new List<string>();
        for (int i = 0; i < paras; i++)
        {
            var paragraph = _paragraphGenerator.GetParagraph();
            if (startwithlorem && i == 0)
            {
                var tokens = paragraph.Split(' ');
                tokens[0] = "Baseball";
                tokens[1] = "ipsum";
                tokens[2] = "dolor";
                tokens[3] = "sit";
                tokens[4] = "amet";
                paragraph = string.Join(" ", tokens);
            }
            generatedParagraphs.Add(paragraph);
        }
        return generatedParagraphs;
    }
}