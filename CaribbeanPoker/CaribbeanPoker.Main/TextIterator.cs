using System;
using System.Collections.Generic;
using System.Linq;

namespace CaribbeanPoker.Main
{
    class TextIterator: IterableText
    {
        public string Text {get; }
        public TextIterator (string text) => Text = text;      
        public IEnumerable<string> WordIterator() 
        {
            var words = Text.Split('\n');
            foreach (var word in words) yield return word;
        }
        // public IEnumerable<string> CharIterator()
        // {
        //     var textChars = Text.Where(x => Char.IsLetterOrDigit(x));
        //     foreach (var textChar in textChars) yield return textChar.ToString();
        // } 
    }
}