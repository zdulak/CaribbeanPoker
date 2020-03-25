using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    public class DisplayTable
    { 
        public static void DisplayBoard(List<Card> dealer, List<Card> player, byte a, byte c)
        {
            Console.Clear();
            Console.WriteLine("       ===  CASINO ROYAL ===");
            Console.WriteLine(".===================================.");
            for (int i = 0; i <10; i++)
            {
                Console.WriteLine("|                                   |");
            }
            Console.WriteLine("*===================================*");
            Console.SetCursorPosition(8,2);
            Console.Write("Caribbean Stud Poker");
            Console.SetCursorPosition(2,4);
            Console.Write("Dealer Hand: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealer[i].Icon);
            }
            Console.SetCursorPosition(2,5);
            Console.Write("------------------------------");
            Console.SetCursorPosition(2,6);
            Console.Write("Player Hand: ");
            Console.Write(player[1].Icon);
            for (int i = 0; i < 5; i++)
            {
                Console.Write(player[i].Icon);
            }
            Console.SetCursorPosition(2,8);
            Console.Write("ANTE: " + a.ToString() + "$       CALL: " + c.ToString() + "$");
            Console.SetCursorPosition(2,15);
        }
    }
}