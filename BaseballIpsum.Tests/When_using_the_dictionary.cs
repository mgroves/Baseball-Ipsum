using Machine.Specifications;

namespace BaseballIpsum.Tests
{
    public class When_using_the_dictionary
    {
        static IpsumDictionary _ipsumDictionary;
        static string _word;

        Establish context = () =>
            {
                _ipsumDictionary = new IpsumDictionary();
            };
        
        Because of = () =>
            {
                _word = _ipsumDictionary.GetRandomWord();
            };
        
        It should_return_a_random_word = () =>
            _word.ShouldNotBeEmpty();
    }
}