using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BA2C
{
    class BA2C
    {
        public static string ProfileProbable(string text, int k, decimal[,] matrix)
        {
            List<decimal> lista = new List<decimal>();
            for (int i = 0; i < text.Length - k + 1; i++)
            {
                string s = text.Substring(i, k);
                decimal suma = 1;
                for (int j = 0; j < s.Length; j++)
                {
                    if (s.Substring(j, 1) == "A")
                        suma *= matrix[0, j];
                    if (s.Substring(j, 1) == "C")
                        suma *= matrix[1, j];
                    if (s.Substring(j, 1) == "G")
                        suma *= matrix[2, j];
                    if (s.Substring(j, 1) == "T")
                        suma *= matrix[3, j];
                }
                lista.Add(suma);
            }
            decimal max = lista.Max();
            string r = "";
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == max)
                {
                    r = text.Substring(i, k);
                    break;
                }
            }
            return r;
        }
        static void Main(string[] args)
        {
            string r = "";
            int br = 0;
            int k = 0;
            List<List<decimal>> lista = new List<List<decimal>>();
            using (StreamReader sr = new StreamReader("rosalind_ba2c.txt"))
            {
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    if (br == 0)
                    {
                        r = linija;
                    }
                    else if (br == 1)
                    {
                        k = int.Parse(linija);
                    }
                    else
                    {
                        string[] niz = linija.Split(' ');
                        List<decimal> lista2 = new List<decimal>();
                        foreach (string l in niz)
                        {
                            lista2.Add(decimal.Parse(l));
                        }
                        lista.Add(lista2);
                    }
                    br++;
                }
            }
            decimal[,] matrix = new decimal[4, k];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    matrix[i, j] = lista[i][j];
                }
            }
            string s = ProfileProbable(r, k, matrix);
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}