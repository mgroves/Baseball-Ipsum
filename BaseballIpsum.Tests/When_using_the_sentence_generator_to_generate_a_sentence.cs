using System.Linq;
using Machine.Specifications;

namespace BaseballIpsum.Tests
{
    public class When_using_the_sentence_generator_to_generate_a_sentence
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
                _sentence = _sentenceGen.GetRandomSentence();
                _numWords = _sentence.Split(' ').Count();
            };

        It should_start_with_a_capital_letter = () =>
            _sentence[0].ToString().ShouldEqual(_sentence[0].ToString().ToUpper());
        It should_end_with_a_period = () =>
            _sentence.Last().ShouldEqual('.');
        It should_have_a_period_right_after_the_last_word = () =>
            _sentence.EndsWith(" .").ShouldBeFalse();
        It should_return_at_least_7_words = () =>
            _numWords.ShouldBeGreaterThanOrEqualTo(7);
    }
}