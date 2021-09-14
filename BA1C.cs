using System;

namespace BA1C
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "CGTTAC";
            string sk = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (text.Substring(i, 1) == "A")
                {
                    sk += "T";
                }
                else if (text.Substring(i, 1) == "T")
                {
                    sk += "A";
                }
                else if (text.Substring(i, 1) == "G")
                {
                    sk += "C";
                }
                else
                {
                    sk += "G";
                }
            }
            Console.WriteLine(sk);
        }
    }
}