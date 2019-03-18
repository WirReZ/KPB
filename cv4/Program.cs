using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 -- One Time Pad");

                string method = "";
                method = Console.ReadLine();
                if (method == "1")
                {
                    Console.Write("Enter crypttext/plaintext ( hex separet by space) ex: fe fa : ");
                    String plain = Console.ReadLine();
                    Console.Write("Enter key (ex: ab without space): ");
                    String key = Console.ReadLine();
                    String crypted = "";

                    var arr = plain.Split(' ').ToArray();
                    if (arr.Length != key.Length)
                    {
                        Console.WriteLine("Klic musi byt stejne dlouhy");
                        continue;
                    }

                    int i = 0;
                    foreach (string val in arr)
                    {
                        int tmp = Convert.ToInt32(val, 16);
                        tmp ^= key[i];
                        crypted += tmp.ToString("X") + " ";
                        i++;
                    }

                    Console.WriteLine("Crypted text : {0}", crypted);
                    Console.WriteLine("");

                }
            }

        }
    }
}
