using System;

namespace BaseballIpsum
{
    public class IpsumDictionary
    {
        readonly string[] _words = new string[]
                              {
                                  "baseball",
                                  "mitt",
                                  "glove",
                                  "diamond",
                                  "home",
                                  "curve",
                                  "run",
                                  "steal",
                                  "reds",
                                  "yankees",
                                  "cubs",
                                  "red sox",
                                  "cardinals",
                                  "tigers",
                                  "dodgers",
                                  "foul",
                                  "ball",
                                  "slider",
                                  "catcher",
                                  "outfield",
                                  "outfielder",
                                  "grass",
                                  "astroturf",
                                  "league",
                                  "bat",
                                  "hitter",
                                  "shortstop",
                                  "out",
                                  "outs",
                                  "baseline",
                                  "umpire",
                                  "batter's box",
                                  "leather",
                                  "helmet",
                                  "practice",
                                  "strike zone",
                                  "outside",
                                  "stadium",
                                  "forkball",
                                  "fastball",
                                  "off-speed",
                                  "plate",
                                  "base",
                                  "tag",
                                  "flyout",
                                  "force",
                                  "double play",
                                  "lineup",
                                  "relief pitcher",
                                  "strikeout",
                                  "wins",
                                  "losses",
                                  "assist",
                                  "save",
                                  "hit by pitch",
                                  "sabremetrics"
                              };

        readonly Random _rand;
        int _numWords;

        public IpsumDictionary()
        {
            _rand = new Random(DateTime.Now.Millisecond);
            _numWords = _words.Length;
        }

        public string GetRandomWord()
        {
            return _words[_rand.Next(0, _numWords-1)];
        }
    }
}