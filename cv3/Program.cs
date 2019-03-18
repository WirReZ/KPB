using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv3
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1 -- Index koincidence");
                string method = "";
                method = Console.ReadLine();
            if (method == "1")
                {
                    Console.Write("Enter crypttext: ");
                    String crypted = Console.ReadLine();
                    crypted = crypted.ToLower();
                    int[] occured = new int[26];
                    Array.Clear(occured, 0, 26);

                    for (int i = 0; i < crypted.Length; i++)
                    {
                        char c = crypted[i];

                        occured[c - 'a']++;
                    }
                    double sum = 0;
                    for (int i = 0; i < occured.Length; i++)
                    {
                        sum += (occured[i] * (occured[i] - 1)) / 2;
                    }

                    double IK = sum / ((crypted.Length * (crypted.Length - 1)) / 2);
                    Console.WriteLine("Index koincidence: {0}", IK);
                }
            }

        }
    }
}
