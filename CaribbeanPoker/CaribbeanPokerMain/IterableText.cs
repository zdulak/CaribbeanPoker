using System;
using System.Collections.Generic;


namespace CaribbeanPokerMain
{

    interface IterableText
    {
        // IEnumerable<string> CharIterator();
        IEnumerable<string> WordIterator();
    }
}