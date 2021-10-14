using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowballTournament
{
    class Tournament
    {
        public List<Player> players { get; private set; }
        static string[] NeighborhoodNames = { "Mulberry", "Maple Valley", "Stonehenge", "Woodchuck", "Beckwith Hill", "Horse Pond", "Forsythe"};
        public bool NonPlayerInfo = true;
        Random rand;

        public Tournament(int numPlayers)
        {
            Console.WriteLine("After the first snowfall, each neighborhood in town " +
                "assembles a team of children to compete in a double elimination " +
                "snowball-fighting tournament.");
            players = new List<Player>();
            rand = new Random();

            for (int i = 1; i <= 8; i += 1)
            {
                string playerName = "";
                if (i <= numPlayers)
                {
                    Console.WriteLine("Player #" + i + ", what neighborhood us your team from?");
                    playerName = Utility.GetNameInput("Please enter the name of your neighborhood, player #" + i);
                }
                else
                {
                    playerName = NeighborhoodNames[i-2];
                }
                players.Add(new Player(playerName, i, i <= numPlayers));
            }
            Console.WriteLine("Would you like info about snowball fights between non-player neighborhoods? (Y or N)");
            NonPlayerInfo = Utility.GetYNInput("Y or N?");
        }

        public FightResult SimulateFight(string stakes, int seedA, int seedB)
        {
            return SimulateFight(stakes, getPlayer(seedA), getPlayer(seedB));
        }

        public FightResult SimulateFight(string stakes, Player PlayerA, Player PlayerB)
        {
            bool playByPlay = false;
            bool generalInfo = ((PlayerA.human) || (PlayerB.human) || (NonPlayerInfo));
            if (generalInfo)
            {
                Console.WriteLine("*******************************************************");
                Console.WriteLine(stakes + PlayerA.FullName() + " vs. " + PlayerB.FullName());
                Console.WriteLine("Do you want the play-by-play? (Y or N)");
                playByPlay = Utility.GetYNInput("Y or N?");
            }
            if (playByPlay)
            {
                //to-do: simulate the fight
                Console.WriteLine("Insert play-by-play here");
            }
            if (rand.NextDouble() >= 0.5)
            {
                PlayerA.wins += 1;
                PlayerB.losses += 1;
                Console.WriteLine(PlayerA.FullName() + " defeats " + PlayerB.FullName());
                return new FightResult() { winner = PlayerA, loser = PlayerB };
            }
            else
            {
                PlayerA.losses += 1;
                PlayerB.wins += 1;
                Console.WriteLine(PlayerB.FullName() + " defeats " + PlayerA.FullName());
                return new FightResult() { winner = PlayerB, loser = PlayerA };
}
        }

        public void Prelim()
        {
            Console.WriteLine("Before the tournament can begin, each neighborhood must face each other " +
                "neighborhood in a preliminary fight. The results of these pre-tournament matches will " +
                "be used for seeding.");
            for (int i = 1; i < 8; i += 1)
            {
                for (int j = i+1; j <= 8; j += 1)
                {
                    SimulateFight("", players.Find(t => t.id == i), players.Find(t => t.id == j));
                }
            }
            Console.WriteLine("Seeding:");
            players = players.OrderBy(t => t.losses).ToList();
            for (int i = 0; i < 8; i += 1)
            {
                players[i].seed = i + 1;
                Console.WriteLine("Seed #" + players[i].seed + ": " + players[i].FullName());
            }
        }

        private Player getPlayer(int seed)
        {
            return players.Find(t => t.seed == seed);
        }

        public void Bracket()
        {
            FightResult Fight1 = SimulateFight("Tournament Round 1: ", 8, 1);
            FightResult Fight2 = SimulateFight("Tournament Round 1: ", 4, 5);
            FightResult Fight3 = SimulateFight("Tournament Round 1: ", 3, 6);
            FightResult Fight4 = SimulateFight("Tournament Round 1: ", 2, 7);

            FightResult Fight5 = SimulateFight("Losers' Bracket Round 1: ", Fight1.loser, Fight2.loser);
            Console.WriteLine(Fight5.loser.FullName() + " has been eliminated from the tournament.");
            FightResult Fight6 = SimulateFight("Losers' Bracket Round 1: ", Fight3.loser, Fight4.loser);
            Console.WriteLine(Fight6.loser.FullName() + " has been eliminated from the tournament.");

            FightResult Fight7 = SimulateFight("Tournament Quarter Final: ", Fight1.winner, Fight2.winner);
            FightResult Fight8 = SimulateFight("Tournament Quarter Final ", Fight3.winner, Fight4.winner);

            FightResult Fight9 = SimulateFight("Losers' Bracket Round 2:", Fight5.winner, Fight8.loser);
            Console.WriteLine(Fight9.loser.FullName() + " has been eliminated from the tournament.");
            FightResult Fight10 = SimulateFight("Losers' Bracket Round 2:", Fight6.winner, Fight7.loser);
            Console.WriteLine(Fight10.loser.FullName() + " has been eliminated from the tournament.");

            FightResult Fight11 = SimulateFight("Tournament Semifinal: ", Fight7.winner, Fight8.winner);

            FightResult Fight12 = SimulateFight("Losers' Bracket Semifinal: ", Fight9.winner, Fight10.winner);
            Console.WriteLine(Fight12.loser.FullName() + " has been eliminated from the tournament.");

            FightResult Fight13 = SimulateFight("Losers' Bracket Final (the winner will move on to the tournament final): ",
                Fight12.winner, Fight11.loser);
            Console.WriteLine(Fight13.loser.FullName() + " has been eliminated from the tournament.");

            Console.WriteLine(Fight13.winner.FullName() + " is the winner of the Loser's Bracket. If "
                + Fight11.winner.name + " wins the next two snowball fights, they will be crowned the overall champion.");
            Console.WriteLine(Fight11.winner.FullName() + " is undefeated thus far. If "
                + Fight11.winner.name + " defeats " + Fight13.winner.name + ", in either of the two upcoming snowball "
                + "fights, they will be crowned the overall champion.");

            FightResult Fight14 = SimulateFight("Tournament Final: ", Fight13.winner, Fight11.winner);
            Player winner;
            if (Fight14.winner.id == Fight11.winner.id)
            {
                winner = Fight14.winner;
                Console.WriteLine(Fight14.loser.FullName() + " has been eliminated from the tournament.");
            }
            else
            {
                FightResult Fight15 = SimulateFight("Tournament Final: ", Fight14.winner, Fight14.loser);
                winner = Fight15.winner;
                Console.WriteLine(Fight15.loser.FullName() + " has been eliminated from the tournament.");
            }

            Console.WriteLine(winner.FullName() + " has won the 2021 Winter Warfare Tournament!");
        }
    }
}
