using System;
using System.Collections.Generic;
using System.IO;

namespace BA3E
{
    class BA3E
    {
        public static string Prefix(string s)
        {
            return s.Substring(0, s.Length - 1);
        }
        public static string Sufix(string s)
        {
            return s.Substring(1, s.Length - 1);
        }
        public static SortedDictionary<string, List<string>> deBruijn(List<string> lista)
        {
            SortedDictionary<string, List<string>> sor = new SortedDictionary<string, List<string>>();
            int pat = lista.Count;
            for (int i = 0; i < pat; i++)
            {
                if (sor.ContainsKey(Prefix(lista[i])))
                    sor[Prefix(lista[i])].Add(Sufix(lista[i]));
                else
                {
                    List<string> l1 = new List<string>();
                    l1.Add(Sufix(lista[i]));
                    sor.Add(Prefix(lista[i]), l1);
                }
            }
            return sor;
        }
        static void Main(string[] args)
        {
            List<string> l = new List<string>();
            using (StreamReader sr = new StreamReader("rosalind_ba3e.txt"))
            {
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    l.Add(linija);
                }
            }
            SortedDictionary<string, List<string>> d = deBruijn(l);
            foreach (string key in d.Keys)
                d[key].Sort();
            foreach (string key in d.Keys)
            {
                string p = key + " " + "->" + " ";
                if (d[key].Count == 1)
                    p += d[key][0];
                else
                {
                    for (int i = 0; i < d[key].Count - 1; i++)
                    {
                        p += d[key][i] + ",";
                    }
                    p += d[key][d[key].Count - 1];
                }
                Console.WriteLine(p);
            }
            Console.ReadLine();
        }
    }
}