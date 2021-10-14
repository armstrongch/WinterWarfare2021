using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowballTournament
{
    static class ChildFactory
    {
        public static string[] ChildNames = {
            "Joey", "Matthew", "Kevin",
            "Sammy", "Thad", "Topher",
            "Amanda", "Anthony", "Ryan",
            "Chris", "James", "Evan",
            "Adams", "Noah", "Cooper",
            "Maxwell", "Burkle", "Marcus",
            "Conrad", "Benny", "Justin",
            "Earle", "Johnny", "Lee"
        };

        public enum Personality
        {
            OPPORTUNISTIC, BOLD, VENGEFUL, UNPREDICTABLE
        }

        public static Dictionary<Personality, string> PersonalityDescriptions = new Dictionary<Personality, string>()
        {
            { Personality.OPPORTUNISTIC, "Opportunistic: Attacks the enemy with the most injuries" },
            { Personality.BOLD, "Bold: Attacks the enemy who throws the hardest" },
            { Personality.VENGEFUL, "Vengeful: Retaliates against the most recent attacker" },
            { Personality.UNPREDICTABLE, "Unpredictable: Attacks a random enemy" },
        };
    }
}
