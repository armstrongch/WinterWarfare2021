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

        public static string GetNameInput(string repeatQuestion)
        {
            string name = "";
            do
            {
                try { name = Console.ReadLine(); }
                catch { }
                if (name.Length == 0)
                {
                    name = "";
                    Console.WriteLine(repeatQuestion);
                }
                else
                {
                    name = char.ToUpper(name[0]) + name.Substring(1);

                }
            } while (name.Length == 0);
            return name;
        }

        public static int GetIntegerInput(string repeatQuestion)
        {
            int? nullableInt = null;
            do
            {
                try
                {
                    nullableInt = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(repeatQuestion);
                }
            } while (nullableInt == null);

            return nullableInt.Value;
        }

        public static int GetIntegerInputInRange(int inclusiveUpperBound, int inclusiveLowerBound, string repeatQuestion)
        {
            int returnInt = inclusiveLowerBound - 1;
            do
            {
                returnInt = GetIntegerInput(repeatQuestion);
                if ((returnInt > inclusiveUpperBound) || (returnInt < inclusiveLowerBound))
                {
                    returnInt = inclusiveLowerBound - 1;
                    Console.WriteLine(repeatQuestion);
                }
            } while (returnInt < inclusiveLowerBound);
            return returnInt;
        }
    }
}
