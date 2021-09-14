using System;
using System.Collections.Generic;

namespace BA1N
{
    class BA1N
    {
        public static int Hammingdistance(string p, string q)
        {
            if (p.Length != q.Length)
                return -1;
            int i = 0;
            int count = 0;
            while (i < p.Length)
            {
                if (p.Substring(i, 1) != q.Substring(i, 1))
                    count++;
                i++;
            }
            return count;
        }

        public static List<string> Neighbours(string pattern, int d)
        {
            List<string> nucletoide = new List<string>();
            nucletoide.Add("C");
            nucletoide.Add("G");
            nucletoide.Add("A");
            nucletoide.Add("T");
            List<string> neighborhood = new List<string>();
            if (d == 0)
            {
                neighborhood.Add(pattern);
                return neighborhood;
            }
            if (pattern.Length == 1)
            {
                neighborhood.Add("C");
                neighborhood.Add("G");
                neighborhood.Add("A");
                neighborhood.Add("T");
                return neighborhood;
            }
            List<string> suffixneighbors = Neighbours(pattern.Substring(1), d);
            foreach (string text in suffixneighbors)
            {
                if (Hammingdistance(pattern.Substring(1), text) < d)
                {
                    foreach (string x in nucletoide)
                    {
                        string s = "";
                        s = x + text;
                        neighborhood.Add(s);
                    }
                }
                else
                {
                    string o = "";
                    o = pattern.Substring(0, 1) + text;
                    neighborhood.Add(o);
                }
            }
            return neighborhood;
        }
        static void Main(string[] args)
        {
            List<string> lista = Neighbours("TATGACTCA", 2);
            foreach (string s in lista)
                Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}