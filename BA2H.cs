using System;
using System.Collections.Generic;
using System.IO;

namespace BA2H
{
    class BA2H
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

        public static int Distancebetweenpatternandstrings(string pattern, List<string> dna)
        {
            int k = pattern.Length;
            int distance = 0;
            foreach (string text in dna)
            {
                int hammingdistance = int.MaxValue;
                for (int i = 0; i < text.Length - k + 1; i++)
                {
                    string s = text.Substring(i, k);
                    if (hammingdistance > Hammingdistance(pattern, s))
                        hammingdistance = Hammingdistance(pattern, s);
                }
                distance += hammingdistance;
            }
            return distance;
        }
        static void Main(string[] args)
        {
            List<string> z = new List<string>();
            string pattern = "";
            int br = 0;
            using (StreamReader sr = new StreamReader("rosalind_ba2h.txt"))
            {
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    if (br == 0)
                    {
                        pattern = linija;
                    }
                    else
                    {
                        string[] niz = linija.Split(' ');
                        foreach (string b in niz)
                            z.Add(b);
                    }
                    br++;
                }
            }
            int g = Distancebetweenpatternandstrings(pattern, z);

            Console.WriteLine(g);
            Console.ReadLine();
        }
    }
}