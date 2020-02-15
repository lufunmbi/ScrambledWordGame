using ScrammbledWordGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrammbledWordGame.Workers
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach(var word in wordList)
                {
                    if(scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if(sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }
            }
            return matchedWords;
        }
        //Helper Class is created so that we dont have to write all this code in the add method above. Just keeping the code simple and sweet
        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedword = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };


            //MatchedWord matchedword = new MatchedWord();
            //matchedword.ScrambledWord = scrambledWord;
            //matchedword.Word = word;

            return matchedword;
        }
    }
}
;
