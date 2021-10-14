using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowballTournament
{
    public class Player
    {
        public string name;
        public int id;
        public bool human;

        public int wins = 0;
        public int losses = 0;
        public int seed;

        List<Child> Children;
        public Player(string name, int id, bool human)
        {
            this.name = name;
            this.id = id;
            this.human = human;
            Children = new List<Child>();
        }
        public string FullName()
        {
            return name + " (neighborhood #" + id + ", " + wins + "-" + losses +")";
        }
    }
}
