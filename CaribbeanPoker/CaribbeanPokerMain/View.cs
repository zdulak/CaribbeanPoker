using System;
using System.Collections.Generic;
using System.IO;

namespace CaribbeanPokerMain
{
    public class View : IView
    {
        public void Clear() => Console.Clear();
        public void PrintMsg(string msg) => Console.WriteLine(msg);
        public void PrintStatus(int money, int jackpot)
        {
            Console.WriteLine($"Your money: {money}.  Current jackpot: {jackpot}.");
        }
        public void DisplayBoard(Card[] dealer, Card[] player, Card cardBack , string dealerCombination ="????",
            string playerCombination="????") 
        {
            Console.WriteLine(new String(' ', 16) + "===  CASINO ROYAL ===" + new String(' ', 16));
            Console.WriteLine("." + new String('=', 51) + ".");
            Console.WriteLine("|" + new String(' ', 51) + "|");
            Console.WriteLine("|" + new String(' ', 15) + "Caribbean Stud Poker!" 
                + new String(' ', 15) + "|");
            Console.WriteLine("|" + new String(' ', 51) + "|");
            var length = dealerCombination.Length;
            var spaceNumber1 = (35-length)/2;
            var spaceNumber2 = 35-length-spaceNumber1;
            Console.WriteLine("|" + new String(' ', spaceNumber1)  + "Dealer Hand --> " 
                + dealerCombination + new String(' ', spaceNumber2) + "|");
            DisplayHand(dealer, cardBack);
            Console.WriteLine(new String('-', 53));
            Console.WriteLine("|" + new String(' ', 51) + "|");
            length = playerCombination.Length;
            spaceNumber1 = (35-length)/2;
            spaceNumber2 = 35-length-spaceNumber1;
            Console.WriteLine("|" + new String(' ', spaceNumber1)  + "Player Hand --> " 
                + playerCombination + new String(' ', spaceNumber2) + "|");
            DisplayHand(player, cardBack);
            Console.WriteLine("." + new String('=', 51) + ".");
        }

        public void DisplayHand(Card[] cards, Card cardBack)
        {
            var picturesIterators = new IEnumerator<string>[cards.Length];
            for (int i = 0; i < cards.Length; ++i)
            {
                if (cards[i].FaceUp)
                {
                    picturesIterators[i] = new TextIterator(cards[i].Picture).WordIterator().GetEnumerator();
                }
                else
                {
                    picturesIterators[i] = new TextIterator(cardBack.Picture).WordIterator().GetEnumerator();
                }
            }
            bool iterate = true;
            while (iterate)
            {
                Console.Write("|   ");
                for (int i = 0; i < cards.Length; ++i)
                {
                    if (!picturesIterators[i].MoveNext()) 
                    {
                        iterate = false;
                        continue;
                    }
                    Console.Write(" " + picturesIterators[i].Current + " ");
                }
                if (!iterate) Console.Write(new String(' ', 45));
                Console.WriteLine("   |");
            }
        }
        // public static void DisplayCard(Card card)
        // {
        //     Console.WriteLine(card.Picture);
        //     Console.WriteLine();
        // }
        // public static void TestDisplayBoard(Card[] dealer, Card[] player, HandCombination dealerCombination,
        //     HandCombination playerCombination)
        // {
        //     //Console.Clear();
        //     Console.WriteLine("           ===  CASINO ROYAL ===");
        //     Console.Write("Dealer Hand: |");
        //     foreach (var card in dealer) Console.Write(card.ToString() + "| ");
        //     Console.WriteLine("-> " + dealerCombination.ToString());
        //     Console.Write("Player Hand: |");
        //     foreach (var card in player) Console.Write(card.ToString() + "| ");
        //     Console.WriteLine("-> " + playerCombination.ToString());
        // }
    }
}