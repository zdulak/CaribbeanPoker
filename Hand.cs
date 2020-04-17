using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    class Hand : IComparable<HandCombination>, IEquatable<HandCombination>
    {
        HandCombination handCombination;
        public Hand(HandCombination hc) => handCombination = hc;
        public int CompareTo(HandCombination other)
        {
            if ((int)handCombination > (int)other)
            {
                return 1;
            }
            else if  ((int)handCombination < (int)other)
            {
                return -1;
            }
            else return 0;
            
        }
        public bool Equals(HandCombination other)
        {
            return Equals(handCombination == other);
        }
    }
}