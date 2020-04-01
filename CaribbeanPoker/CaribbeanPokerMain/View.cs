using System;

namespace CaribbeanPokerMain
{
    public static class View
    { 
        public static void PrintStatus(int money, int jackpot)
        {
            Console.WriteLine($"Your money: {money}.  Current jackpot: {jackpot}.");
        }
        public static void DisplayBoard(Card[] dealer, Card[] player) 
        {
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
            Console.WriteLine();
        }
    }
}