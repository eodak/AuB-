using System;
using System.Collections.Generic;

namespace BA1K
{
    class BA1K
    {
        //A solution to a ROSALIND bioinformatics problem.
        //Problem Title: Generate the Frequency Array of a String
        //Rosalind ID: BA1K
        //URL: http://rosalind.info/problems/ba1k
        static void Main(string[] args)
        {

            string kmer(string text, int i, int k)
            {
                //substring of text from i-th position for the next k letters
                return text.Substring(i, k);
            }
            int[] ComputingFrequencies(string text, int k)
            {
                int[] frequencyArray = new int[(int)Math.Pow(4, k)];
                for (int i = 0; i < text.Length - k + 1; i++)
                {
                    string pattern = kmer(text, i, k);
                    int j = PatternToNumber(pattern);
                    frequencyArray[j] = frequencyArray[j] + 1;
                }
                return frequencyArray;
            }

            int PatternToNumber(string pattern)
            {
                List<string> allkmers(int k)
                {
                    string[] nucleotides = new string[4] { "A", "C", "G", "T" };
                    List<string> kmers = new List<string>();
                    if (k == 0)
                    {
                        return kmers;
                    }
                    if (k == 1)
                    {
                        foreach (string n in nucleotides)
                        {
                            kmers.Add(n);
                        }
                        return kmers;
                    }
                    foreach (string x in allkmers(k - 1))
                    {
                        foreach (string n in nucleotides)
                        {
                            kmers.Add(n + x);
                        }
                    }
                    return kmers;
                }
                List<string> all = allkmers(pattern.Length);
                all.Sort();
                return (all.IndexOf(pattern));
            }

            string x = "ACGCGGCTCTGAAA\n2";
            string[] inlines = x.Split();
            string text = inlines[0];
            int k = int.Parse(inlines[1]);
            int[] res = ComputingFrequencies(text, k);
            foreach (int s in res)
            {
                Console.WriteLine(s);
            }
        }
    }
}