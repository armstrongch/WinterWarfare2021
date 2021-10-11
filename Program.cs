using System;

namespace SnowballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Winter Warfare 2021!");
            bool playAgain = false;
            do
            {
                int numPlayers = -1;
                do
                {
                    Console.WriteLine("How many teams? (1-8)");
                    try
                    {
                        numPlayers = Int32.Parse(Console.ReadLine());
                    }
                    catch { }
                } while ((numPlayers < 1) || (numPlayers > 8));

                Tournament tournament = new Tournament(numPlayers);
                tournament.Prelim();
                tournament.Bracket();

                Console.WriteLine("Do you want to play again? (Y or N)");
                playAgain = Utility.GetYNInput("Y or N?");
            } while (playAgain);
        }
    }
}
