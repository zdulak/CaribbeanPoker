using System;
using System.Collections.Generic;
using System.Linq;

namespace CaribbeanPokerMain
{

    interface IterableText
    {
        IEnumerable<string> CharIterator();
        IEnumerable<string> WordIterator();
    }

    class TextIterator: IterableText
    {
        public string Text {get; }
        public TextIterator (string text) => Text = text;      
        public IEnumerable<string> CharIterator()
        {
            var textChars = Text.Where(x => Char.IsLetterOrDigit(x));
            foreach (var textChar in textChars) yield return textChar.ToString();
        } 
        public IEnumerable<string> WordIterator() 
        {
            var words = Text.Split('\n');
            foreach (var word in words) yield return word;
        }
    }
}