using System;
using System.Collections.Generic;
using System.Linq;

namespace BA4H
{
    class BA4H
    {
        public static List<int> Convolution(List<int> spectrum)
        {
            spectrum.Sort();
            List<int> conv = new List<int>();
            for (int i = 0; i < spectrum.Count() - 1; i++)
            {
                for (int j = i; j < spectrum.Count(); j++)
                {
                    if (spectrum[j] - spectrum[i] != 0)
                        conv.Add(spectrum[j] - spectrum[i]);
                }
            }
            Dictionary<int, int> freq_dict = new Dictionary<int, int>();
            foreach (int mass in conv.Distinct())
                freq_dict[mass] = conv.Count((element) => element == mass);

            List<int> rj = new List<int>();


            foreach (KeyValuePair<int, int> vrij in freq_dict.OrderByDescending(key => key.Value))
            {
                for (int k = 0; k < vrij.Value; k++)
                    rj.Add(vrij.Key);
            }
            return rj;
        }
        static void Main(string[] args)
        {
            string s = "1093 1916 2047 1895 598 543 1617 1417 2160 1275 695 656 1336 524 513 905 927 1069 824 430 624 1650 87 396 1950 1764 825 215 1040 1403 808 429 2059 1462 1765 1449 1223 1294 1577 2089 1010 953 1255 1876 622 2063 512 1022 1018 1749 712 1761 1253 284 271 1660 412 129 661 357 97 486 281 1762 1549 128 641 922 510 855 2023 1335 2032 1207 1352 555 314 1013 614 1974 451 1362 1536 1879 1421 2045 1034 496 527 1093 1846 1761 1858 1709 1067 2073 611 400 963 210 1875 610 727 753 548 186 302 1320 1745 751 115 1138 500 1633 952 1537 113 583 1520 1546 1632 411 738 1499 695 1141 1137 1933 210 1266 1918 470 71 1255 1836 1449 907 1351 628 1334 1465 809 528 1780 1190 1518 743 1150 427 712 1532 97 1633 1132 1832 1522 243 711 2089 1385 711 1126 312 970 698 1303 640 1448 168 1352 1803 1666 1519 623 1305 2032 328 1504 1204 1518 0 826 1110 399 242 1233 1433 543 440 227 128 642 638 137 1091 2063 395 1950 115 1961 1238 1674 1381 2047 1334 265 199 1138 1138 1120 2032 642 1605 824 1919 184 241 2045 876 737 1917 1577 495 895 380 156 1448 527 1844 1208 1022 742 1917 599 339 1550 314 1538 324 1690 114 2004 1028 1067 1407 1992 1022 1562 1284 583 1636 1945 425 1423 415 2047 399 381 1418 937 147 1665 857 1976 757 128 1779 775 1336 1821 1050 285 1561 1848 1647 1735 1972 2013 1760 244 1720 312 1832 1238 1877 1368 1664 1265 1422 188 1846 215 894 1748 1730 1206 243 956 1648 798 1612 494 71 1197 1651 866 1261 113 1023 1945 808 509 905 885 779 1733 1731 1142 1023 826 1848 2031 739 101 398 1409 792 113 1465 316 1019 1221 1137 283 1617 899 2046 1889 954 922 840 328 939 1147";
            List<int> spectrum = new List<int>();
            foreach (string m in s.Split(' '))
            {
                spectrum.Add(int.Parse(m));
            }
            List<int> rj = Convolution(spectrum);
            for (int i = 0; i <= rj.Count() - 1; i++)
                Console.Write(rj[i] + " ");
            Console.ReadLine();
        }
    }
}