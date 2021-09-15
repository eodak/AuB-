using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace BA4C
{
    class BA4C
    {
        public static Dictionary<string, int> masa()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict["G"] = 57;
            dict["A"] = 71;
            dict["S"] = 87;
            dict["P"] = 97;
            dict["V"] = 99;
            dict["T"] = 101;
            dict["C"] = 103;
            dict["I"] = 113;
            dict["L"] = 113;
            dict["N"] = 114;
            dict["D"] = 115;
            dict["K"] = 128;
            dict["Q"] = 128;
            dict["E"] = 129;
            dict["M"] = 131;
            dict["H"] = 137;
            dict["F"] = 147;
            dict["R"] = 156;
            dict["Y"] = 163;
            dict["W"] = 186;
            return dict;

        }
        public static int cijelamasa(string peptid)
        {
            int br = 0;
            Dictionary<string, int> dict = masa();
            for (int i = 0; i < peptid.Length; i++)
            {
                br = br + dict[peptid.Substring(i, 1)];
            }
            return br;
        }
        public static List<int> ciklicki(string peptid)
        {
            List<int> spektar = new List<int>();
            spektar.Add(cijelamasa(peptid));
            spektar.Add(0);
            string peptid2 = peptid + peptid;
            for (int i = 1; i < peptid.Length; i++)
            {
                for (int j = 0; j < peptid.Length; j++)
                {
                    string subpeptid = peptid2.Substring(j, i);
                    spektar.Add(cijelamasa(subpeptid));
                }
            }
            spektar.Sort();
            return spektar;
        }
        static void Main(string[] args)
        {
            List<int> c = ciklicki("ITYNVSSGKIEI");
            foreach (int p in c)
                Console.Write(p + " ");
            Console.ReadLine();
        }

    }
}
