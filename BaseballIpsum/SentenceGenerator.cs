using System;
using System.Text;

namespace BaseballIpsum
{
    public class SentenceGenerator
    {
        IpsumDictionary _dict;
        Random _rand;

        public SentenceGenerator(IpsumDictionary dict)
        {
            _dict = dict;
            _rand = new Random(DateTime.Now.Millisecond);
        }

        public string GetRandomSentence(bool withComma = false)
        {
            var sb = new StringBuilder();
            var sevenToTen = _rand.Next(7, 10);
            for (int i = 0; i < sevenToTen; i++)
            {
                sb.Append(_dict.GetRandomWord());
                if (withComma && (i == 4))
                    sb.Append(',');
                sb.Append(' ');
            }
            sb[0] = char.ToUpper(sb[0]);
            var result = sb.ToString().Trim() + ".";
            return result;
        }
    }
}