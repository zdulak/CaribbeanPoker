using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    public interface IDeckDAO
    {
        public IEnumerable<string> GetCardNames();
        public void Shuffle();
        public void removeCard(Card removedCard);
        public void addCard(Card addedCard);
    }
}