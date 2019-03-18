using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv1
{
    class Program
    {
        private static String Decrypt(int key, string cypher)
        {
            return Encrypt(26 - key, cypher);
        }
        private static String Encrypt(int key, string plaintext)
        {
            String cypher = "";
            foreach (char c in plaintext)
            {
                if (c == ' ')
                {
                    cypher += " ";
                }
                else
                    cypher += (char)(((c - 'A' + key) % 26) + 'A');
            }
            return cypher;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 -- Encrypt Caesar");
                Console.WriteLine("2 -- Decrypt Caesar");
                Console.WriteLine("3 -- Bruteforce Caesar");
                Console.WriteLine("4 -- Substitution");
                Console.WriteLine("5 -- Inverse substitution");
                string method = "";
                method = Console.ReadLine();
                if (method == "1")
                {
                    Console.Write("Key: ");
                    string strKey = Console.ReadLine();
                    int key = Int32.Parse(strKey);
                    String plaintext = Console.ReadLine();
                    plaintext = plaintext.ToUpper();
                    Console.WriteLine("Plaintext: {0}", plaintext);
                    Console.WriteLine("Cyphertext: {0}, key:{1}", Encrypt(key, plaintext), key);
                }
                else if (method == "2")
                {
                    Console.Write("Key: ");
                    string strKey = Console.ReadLine();
                    int key = Int32.Parse(strKey);
                    Console.Write("Cypher: ");
                    string cyphertext = Console.ReadLine();
                    cyphertext = cyphertext.ToUpper();
                    Console.WriteLine("Cyphertext: {0}, key:{1}", cyphertext, key);
                    Console.WriteLine("Plaintext: {0}", Decrypt(key, cyphertext));

                }
                else if (method == "3")
                {
                    Console.WriteLine("Enter cypher!");
                    string cypher = Console.ReadLine();
                    for (int i = 1; i < 26; i++)
                    {
                        Console.WriteLine("========================================");
                        Console.WriteLine("Key: {0}", i);
                        Console.WriteLine("Text: {0}", Decrypt(i, cypher));
                        Console.WriteLine("========================================");
                    }
                }
                else if (method == "4")
                {
                    Console.WriteLine("Generate Cypheralphabet");
                    Console.Write("Plain: ");
                    List<char> allowed = new List<char>();
                    List<char> plain = new List<char>();
                    List<char> cypher = new List<char>();
                    for (int i = 0; i < 26; i++)
                    {
                        Console.Write((char)(i + 'A'));
                        Console.Write(" ");
                        allowed.Add((char)(i + 'A'));
                        plain.Add((char)(i + 'A'));
                    }
                    Console.WriteLine();
                    Console.Write("Cypher: ");
                    Random rand = new Random();
                    while (allowed.Count != 0)
                    {
                        char c = allowed[rand.Next(allowed.Count)];
                        allowed.Remove(c);
                        cypher.Add(c);
                        Console.Write(c);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("==================");
                    Console.WriteLine("Enter Text:");
                    String plaintext = Console.ReadLine();
                    string cryph = "";
                    foreach (char c in plaintext)
                    {
                        if (c != ' ')
                        {
                            int n = plain.IndexOf(c);
                            cryph += cypher[n];
                        }
                        else cryph += ' ';
                    }
                    Console.WriteLine("CypherText: {0}", cryph);

                }
                else if (method == "5")
                {
                    List<char> plain = new List<char>();
                    List<char> cypher = new List<char>();
                    for (int i = 0; i < 26; i++)
                    {
                        plain.Add((char)(i + 'A'));
                    }
                    Console.WriteLine("Enter key: ");
                    string crypth = Console.ReadLine();
                    foreach (char c in crypth)
                    {
                        if (c != ' ')
                        {
                            cypher.Add(c);
                        }
                    }
                    Console.WriteLine("Cyphertext: ");
                    String cyphertext = Console.ReadLine();
                    String plaintext = "";
                    foreach (char c in cyphertext)
                    {
                        if (c != ' ')
                        {
                            int n = cypher.IndexOf(c);
                            plaintext += plain[n];
                        }
                        else plaintext += ' ';
                    }
                    Console.WriteLine("Plaintext: {0}", plaintext);

                }
            }
        }
    }
}
