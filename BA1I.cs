using System;
using System.Collections.Generic;

namespace BA1I
{
    class BA1I
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
        public static List<string> Neighbors(string pattern, int d)
        {
            List<string> nucleotide = new List<string>();
            nucleotide.Add("C");
            nucleotide.Add("G");
            nucleotide.Add("A");
            nucleotide.Add("T");
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
            List<string> suffiexneighbors = Neighbors(pattern.Substring(1), d);
            foreach (string text in suffiexneighbors)
            {
                if (Hammingdistance(pattern.Substring(1), text) < d)
                {
                    foreach (string x in nucleotide)
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

        public static int Approximatepatterncount(string text, string pattern, int d)
        {
            int count = 0;
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                string pattern1 = text.Substring(i, pattern.Length);
                if (Hammingdistance(pattern, pattern1) <= d)
                    count += 1;


            }
            return count;
        }
        public static int Patterntonumber(string pattern)
        {
            int res = 0;
            int k = 0;
            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                if (pattern.Substring(i, 1) == "C")
                    res = (int)(res + 1 * Math.Pow(4, k));
                if (pattern.Substring(i, 1) == "G")
                    res = (int)(res + 2 * Math.Pow(4, k));
                if (pattern.Substring(i, 1) == "T")
                    res = (int)(res + 3 * Math.Pow(4, k));
                k += 1;
            }
            return res;
        }
        public static string Numbertopattern(int index, int k)
        {
            string s = "";
            List<string> d = new List<string>();
            d.Add("A");
            d.Add("C");
            d.Add("G");
            d.Add("T");
            int q = index;
            for (int i = 0; i < k; i++)
            {
                int r = q % 4;
                q = q / 4;
                s += d[r];
            }
            string str = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                str += s.Substring(i, 1);
            }
            return str;
        }
        public static List<string> Frequentwordswithmismatches(string text, int k, int d)
        {
            List<string> frequentpatterns = new List<string>();
            List<int> close = new List<int>();
            List<int> frequencyarray = new List<int>();
            for (int i = 0; i <= ((int)Math.Pow(4, k)) - 1; i++)
            {
                close.Add(0);
                frequencyarray.Add(0);
            }
            for (int i = 0; i <= text.Length - k; i++)
            {
                List<string> neighborhood = Neighbors(text.Substring(i, k), d);
                foreach (string pattern in neighborhood)
                {
                    int index = Patterntonumber(pattern);
                    close[index] = 1;
                }
            }
            for (int i = 0; i <= ((int)Math.Pow(4, k)) - 1; i++)
            {
                if (close[i] == 1)
                {
                    string pattern = Numbertopattern(i, k);
                    frequencyarray[i] = Approximatepatterncount(text, pattern, d);
                }
            }
            int maxcount = 0;
            foreach (int n in frequencyarray)
            {
                if (n > maxcount)
                    maxcount = n;
            }
            for (int i = 0; i <= ((int)Math.Pow(4, k)) - 1; i++)
            {
                if (frequencyarray[i] == maxcount)
                {
                    string p = Numbertopattern(i, k);
                    frequentpatterns.Add(p);
                }
            }
            return frequentpatterns;

        }
        static void Main(string[] args)
        {
            string sequence = "TGTGTATTCTGTGTATTCTGTGTATTCCCAATCCCCAATCCCCAATCCCGCGCGTAAGGTCAATGTGTATTCGCGCGGTTGTGTATTCGCGCGGTCCAATCCAGGTCAAAGGTCAATGTGTATTCCGCGCGTAGCGCGGTCGCGCGTATGTGTATTCCCAATCCGCGCGGTGCGCGGTCCAATCCAGGTCAAAGGTCAAGCGCGGTGCGCGGTGCGCGGTTGTGTATTCGCGCGGTCCAATCCAGGTCAAAGGTCAACCAATCCAGGTCAACGCGCGTATGTGTATTCCCAATCCGCGCGGTTGTGTATTCCGCGCGTAGCGCGGTGCGCGGTCGCGCGTACGCGCGTATGTGTATTCAGGTCAACCAATCCAGGTCAACGCGCGTAAGGTCAATGTGTATTCCCAATCCCCAATCCTGTGTATTCCCAATCCTGTGTATTCGCGCGGTCGCGCGTACGCGCGTAGCGCGGTCCAATCCGCGCGGTCGCGCGTAAGGTCAAAGGTCAAAGGTCAAAGGTCAACCAATCCAGGTCAAAGGTCAACGCGCGTACGCGCGTAAGGTCAAGCGCGGTCGCGCGTACCAATCCCCAATCCCGCGCGTACGCGCGTATGTGTATTCAGGTCAACCAATCCTGTGTATTCCGCGCGTACGCGCGTATGTGTATTCGCGCGGTCCAATCCCGCGCGTACGCGCGTACCAATCCTGTGTATTCAGGTCAACGCGCGTACCAATCCAGGTCAAGCGCGGTTGTGTATTCCGCGCGTACGCGCGTACGCGCGTACCAATCCGCGCGGTCCAATCCTGTGTATTCCCAATCCCGCGCGTAAGGTCAAGCGCGGTGCGCGGT";

            int k = 5;

            int d = 2;
            List<string> rj = Frequentwordswithmismatches(sequence, k, d);
            foreach (string j in rj)
                Console.Write(j + " ");
            Console.ReadLine();
        }
    }
}