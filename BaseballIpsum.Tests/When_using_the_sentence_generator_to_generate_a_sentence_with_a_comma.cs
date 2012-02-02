using System.Linq;
using Machine.Specifications;

namespace BaseballIpsum.Tests
{
    public class When_using_the_sentence_generator_to_generate_a_sentence_with_a_comma
    {
        static IpsumDictionary _dict;
        static SentenceGenerator _sentenceGen;
        static string _sentence;
        static int _numWords;

        Establish context = () =>
            {
                _dict = new IpsumDictionary();
                _sentenceGen = new SentenceGenerator(_dict);
            };

        Because of = () =>
            {
                _sentence = _sentenceGen.GetRandomSentence(true);
                _numWords = _sentence.Split(' ').Count();
            };

        It should_have_a_comma_in_it = () =>
            _sentence.ShouldContain(',');
        It should_have_a_comma_right_after_a_word = () =>
            _sentence.ShouldNotContain(" ,");
        It should_have_a_space_after_the_comma = () =>
            _sentence.ShouldContain(", ");
    }
}