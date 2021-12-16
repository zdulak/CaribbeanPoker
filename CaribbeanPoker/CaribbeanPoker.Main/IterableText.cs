using System;
using System.Collections.Generic;


namespace CaribbeanPoker.Main
{

    interface IterableText
    {
        // IEnumerable<string> CharIterator();
        IEnumerable<string> WordIterator();
    }
}