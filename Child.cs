using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnowballTournament.ChildFactory;

namespace SnowballTournament
{
    class Child
    {
        
        public string name;
        public int id;

        public int currentHealth;
        public int maxHealth;
        public Personality personality;

        public Child(int id, bool humanPlayer)
        {
            this.id = id;
            if (humanPlayer)
            {
                Console.WriteLine("What is this child's name?");
                this.name = Utility.GetNameInput("Please enter a name for this child");

                PromptForPersonality();
            }
            else
            {
                this.name = ChildNames[id];
            }
        }

        public void PromptForPersonality()
        {

        }
    }
}
