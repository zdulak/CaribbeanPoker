using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    class Hand : IComparable<HandCombination>, IEquatable<HandCombination>
    {
        public int CompareTo(HandCombination other)
        {
            return 1;
        }
        public bool Equals(HandCombination other)
        {
            return true;
        }
    }
}