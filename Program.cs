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
                Console.WriteLine("How many human players? (1-8)");
                int numPlayers = Utility.GetIntegerInputInRange(8, 1, "How many human players? (1-8)");
                Tournament tournament = new Tournament(numPlayers);
                tournament.Prelim();
                tournament.Bracket();

                Console.WriteLine("Do you want to play again? (Y or N)");
                playAgain = Utility.GetYNInput("Y or N?");
            } while (playAgain);
        }
    }
}
