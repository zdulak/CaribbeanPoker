using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    static class Analisis
    {
        public static HandCombination HandAnalizer(List<Card> hand)
        {
            // find combination with the same color: flush, poker, POKER
            hand.Sort(new CardComparer_Value());
            Card first = hand[0];
            int counter = 0;
            for (int i = 1; i < 5; i++)
            {
                if (first.Suit != hand[i].Suit) break;
                counter +=1;
            }
            if (counter == 4)  //ten sam kolor  
            {
                // sprawdzamy sekwencję
                if (hand[0].Rank == Ranks.King && hand[1].Rank == Ranks.Queen && hand[2].Rank == Ranks.Jack 
                && hand[3].Rank == Ranks.Ten && hand[4].Rank == Ranks.Ace ) return HandCombination.POKER;
                counter = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (hand[i].Rank != hand[i+1].Rank -1) break;
                    counter += 1;
                }
                if (counter == 4)
                {
                  return HandCombination.poker;  
                }
                else
                {
                    return HandCombination.flush;
                } 
            }
            else  //różne kolory
            {
                // sprawdzamy sekwencję 
                if (hand[0].Rank == Ranks.King && hand[1].Rank == Ranks.Queen && hand[2].Rank == Ranks.Jack 
                && hand[3].Rank == Ranks.Ten && hand[4].Rank == Ranks.Ace ) return HandCombination.straight;
                counter = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (hand[i].Rank != hand[i+1].Rank -1) break;
                }
                if (counter == 4) return HandCombination.straight;
                else
                {
                    // porównujemy te same wartości
                    Dictionary<Ranks,int> mydict = new Dictionary<Ranks,int>();
                    for (int i = 0; i < 5; i++)
                    {
                        if (!mydict.ContainsKey(hand[i].Rank))
                        {
                            mydict[hand[i].Rank] = 1;
                        }
                        else
                        {
                            mydict[hand[i].Rank] += 1;
                        }
                    }
                    var values = mydict.Values;
                    List<int> lvalues = new List<int>();
                    foreach (int item in values)
                    {
                        lvalues.Add(item);
                    }
                    if (lvalues.Contains(4)) return HandCombination.quads;
                    if (lvalues.Contains(3) && lvalues.Contains(2)) return HandCombination.full;
                    if (lvalues.Contains(3)) return HandCombination.triplets;
                    if (lvalues.Contains(2))
                    {
                        lvalues.Remove(2);
                        if (lvalues.Contains(2)) return HandCombination.pairs;
                        else return HandCombination.pair;
                    }
                } 
            }
            return HandCombination.nothing;
        }
    }
}