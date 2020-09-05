using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CaribbeanPokerMain
{
    public static class Ante
    {
        public static ReadOnlyCollection<int> PossibleValues { get; } = (new List<int> {10, 20, 50, 100}).AsReadOnly();
    }
}