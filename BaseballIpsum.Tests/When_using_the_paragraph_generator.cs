using System.Linq;
using Machine.Specifications;

namespace BaseballIpsum.Tests
{
    public class When_using_the_paragraph_generator
    {
        static IpsumDictionary _dict;
        static SentenceGenerator _sent;
        static ParagraphGenerator _paragraphGen;
        static string _paragraph;
        static int _numSentences;

        Establish context = () =>
            {
                _dict = new IpsumDictionary();
                _sent = new SentenceGenerator(_dict);
                _paragraphGen = new ParagraphGenerator(_sent);
            };

        Because of = () =>
            {
                _paragraph = _paragraphGen.GetParagraph();
                _numSentences = _paragraph.Count(c => c == '.');
            };

        It should_have_6_or_7_sentences = () =>
            (_numSentences == 6 || _numSentences == 7).ShouldBeTrue();
        It should_have_at_least_one_sentence_with_a_comma = () =>
            _paragraph.ShouldContain(',');
        It should_not_have_any_trailing_spaces = () =>
            _paragraph.EndsWith(" ").ShouldBeFalse();
    }
}