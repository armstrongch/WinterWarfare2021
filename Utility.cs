using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowballTournament
{
    static class Utility
    {
        public static bool GetYNInput(string repeatQuestion)
        {
            string YN = "";
            do
            {
                try { YN = Console.ReadLine().ToUpper(); }
                catch { }
                if ((YN != "Y") && (YN != "N"))
                {
                    YN = "";
                    Console.WriteLine(repeatQuestion);
                }
            } while (YN.Length == 0);
           
            return (YN == "Y");
        }
    }
}
