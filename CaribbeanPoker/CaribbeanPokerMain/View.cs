using System;

namespace CaribbeanPokerMain
{
    public static class View
    { 
        public static void PrintMsg(string msg) => Console.WriteLine(msg);
        public static void PrintStatus(int money, int jackpot)
        {
            Console.WriteLine($"Your money: {money}.  Current jackpot: {jackpot}.");
        }
        public static void DisplayBoard(Card[] dealer, Card[] player) 
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.WriteLine("           ===  CASINO ROYAL ===");
            Console.WriteLine(".===========================================.");
            for (int i = 0; i <10; i++)
            {
                Console.WriteLine("|                                           |");
            }
            Console.WriteLine("*===========================================*");
            Console.SetCursorPosition(11,2);
            Console.Write("Caribbean Stud Poker");
            Console.SetCursorPosition(2,4);
            Console.Write("Dealer Hand: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealer[i].Picture);
            }
            Console.SetCursorPosition(2,5);
            Console.Write("--------------------------------------");
            Console.SetCursorPosition(2,6);
            Console.Write("Player Hand: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(player[i].Picture);
            }
            Console.SetCursorPosition(0,12);
            Console.WriteLine();
        }
        public static void TestDisplayBoard(Card[] dealer, Card[] player, HandCombination dealerCombination,
            HandCombination playerCombination)
        {
            //Console.Clear();
            Console.WriteLine("           ===  CASINO ROYAL ===");
            Console.Write("Dealer Hand: |");
            foreach (var card in dealer) Console.Write(card.ToString() + "| ");
            Console.WriteLine("-> " + dealerCombination.ToString());
            Console.Write("Player Hand: |");
            foreach (var card in player) Console.Write(card.ToString() + "| ");
            Console.WriteLine("-> " + playerCombination.ToString());
        }
    }
}