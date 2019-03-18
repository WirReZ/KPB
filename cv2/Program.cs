using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv2
{
    class Program
    {
        public static string getKeyFromText(string sKey,int method)
        {
            StringBuilder key = new StringBuilder(sKey);
            if(method == 1)
            {
                int inx = 1;
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < sKey.Length; j++)
                    {
                        if (sKey[j] == (i + 'A'))
                        {
                            key[j] = Convert.ToString(inx).ToCharArray()[0];
                            inx++;
                        }
                    }
                }
            }else if(method == 2)
            {
                StringBuilder tmp = new StringBuilder(sKey);
                int inx = 1;
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < sKey.Length; j++)
                    {
                        if (sKey[j] == (i + 'A'))
                        {
                            tmp[j] = Convert.ToString(inx).ToCharArray()[0];
                            inx++;
                        }
                    }
                }
                for(int i=0;i<tmp.Length;i++)
                {
                    key[int.Parse(tmp[i].ToString())-1] = Convert.ToString(i+1).ToCharArray()[0];
                }

            }
            Console.WriteLine("Key: {0}", key.ToString());
            return key.ToString();
        }
        static void Main(string[] args)
        {
            Dictionary<char, List<char>> viegenerTable = new Dictionary<char, List<char>>();
            for (int i = 0; i < 26; i++)
            {
                List<char> arr = new List<char>();
                for (int j = i; j < 26 + i; j++)
                {
                    arr.Add((char)('A' + j % 26));
                }
                viegenerTable.Add((char)(i + 'A'), arr);
            }

            while (true)
            {
                Console.WriteLine("1 -- Encrypt Viegener");
                Console.WriteLine("2 -- Decrypt Viegener");
                Console.WriteLine("3 -- Encrypt Columnar");
                Console.WriteLine("4 -- Decrypt Columnar");
                Console.WriteLine("5 -- Encrypt Row transposition");
                Console.WriteLine("6 -- Decrypt Row transposition");
                string method = "";
                method = Console.ReadLine();
                if (method == "1")
                {
                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();
                    Console.Write("Enter text: ");
                    String plain = Console.ReadLine();
                    string crypted = "";
                    for (int i = 0; i < plain.Length; i++)
                    {
                        if (plain[i] == ' ') continue;
                        char kVal = key[i % key.Length];
                        int origVal = viegenerTable['A'].IndexOf(plain[i]);
                        char cryptVal = viegenerTable[kVal][origVal];

                        crypted += cryptVal;
                    }
                    Console.WriteLine();
                    Console.WriteLine(crypted);
                }
                else if (method == "2")
                {
                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();
                    Console.Write("Enter crypttext: ");
                    String crypted = Console.ReadLine();
                    string plain = "";
                    for (int i = 0; i < crypted.Length; i++)
                    {
                        if (crypted[i] == ' ') continue;
                        char kVal = key[i % key.Length];
                        int origVal = viegenerTable[kVal].IndexOf(crypted[i]);
                        char plainVal = viegenerTable['A'][origVal];

                        plain += plainVal;

                    }
                    Console.WriteLine();
                    Console.WriteLine(plain);
                }
                else if (method == "3")
                {
                    Console.Write("Enter key: ");
                    string sKey = Console.ReadLine();
                    sKey = sKey.ToUpper();
                    string key = getKeyFromText(sKey, 1);

                    Console.Write("Enter plain: ");
                    String plain = Console.ReadLine();

                    //plain = "RUSKYPREZIDENTVLADIMIRPUTINPRONESLVECTVRTEKTRADICNIPROJEVOSTAVUFEDERACEVENOVALSETOMUZERUSKOMUSIPOKRACOVATVTRANSFORMACIANEMUZESESPOKOJITSESOUCASNYMSTAVEMZMINILSTOUPAJICIPOCETCHUDYCHIZAOSTALOUINFRASTRUKTURUNUTNOUPODPORUDUCHODCUMIMLADYMRODINYMABYSEZVRYTILNEPRIZNIVYDEMOGRAFICKYVYVOJ";
                    string crypted = "";
                    List<List<char>> arr = new List<List<char>>();
                    List<char> line = new List<char>();
                    for (int i = 0; i < plain.Length; i++)
                    {
                        line.Add(plain[i]);
                        if (i > 0 && (i + 1) % key.Length == 0)
                        {
                            arr.Add(line);
                            line = new List<char>();
                        }
                    }
                    if (line.Count != 0)
                    {
                        int fill = key.Length - line.Count;
                        for (int i = 0; i < fill; i++)
                            line.Add('X');

                        arr.Add(line);
                    }

                    /* matice
                    for(int i=0;i<arr.Count;i++)
                    {
                        for (int j = 0; j < arr[i].Count; j++)
                        {
                            Console.Write(arr[i][j]);
                        }
                        Console.WriteLine();
                    }
                    */

                    for (int i = 0; i < key.Length; i++)
                    {
                        int pos = Int32.Parse(key[i].ToString()) -1 ;
                        for (int j = 0; j < arr.Count; j++)
                        {
                            crypted += arr[j][pos];
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine(crypted);
                }

                else if (method == "4")
                {

                    Console.Write("Enter key: ");
                    string sKey = Console.ReadLine();
                    string key = getKeyFromText(sKey, 2);

                    Console.Write("Enter crypttext: ");
                    String crypted = Console.ReadLine();
                    //crypted = "KILRPLRAPOFCVOUSAVFIZOSATMTIEYOUSUNPCMYNSTRYRYXYDAPRVTDRSEEAMSICTOAEKESAIOCTCSITROOHIMYEIIDAVXSZVINSVRIVUAOTRURTSCUPTCSZSJCDAOATTDUUDIYYPVGKJUETMIETTNEVRNEEMKANAMSIUMMLAOUZLRKUODCADBREIOCORRNITNCKCJAEESZOOVAMEEJOYEIPPHIAFUNPUDLOAVNNMIVPEDUOEEIOTDVLUKPORRNSOSNVNUICHTNRUUROMRMZLZEFYX";

                    string plain = "";
                    List<List<char>> arr = new List<List<char>>();
                    List<char> line = new List<char>();

                    for (int i = 0; i < crypted.Length; i++)
                    {
                        line.Add(crypted[i]);
                        if (i > 0 && (i+1) % ((crypted.Length / key.Length)) == 0)
                        {
                            arr.Add(line);
                            line = new List<char>();
                        }
                    }
                    if(line.Count != 0) arr.Add(line);

                  /*  for(int i=0;i<arr.Count;i++)
                    {
                        for(int j=0;j<arr[i].Count;j++)
                        {
                            Console.Write(arr[i][j]);
                        }
                        Console.WriteLine();
                    }*/
                    for (int i = 0; i < crypted.Length/key.Length; i++)
                    {
                        for (int j = 0; j < arr.Count; j++)
                        {
                            int pos = Int32.Parse(key[j].ToString()) - 1;
                            plain += arr[pos][i];
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine(plain);
                }
                else if (method == "5")
                {
                    Console.Write("Enter key: ");
                    string sKey = Console.ReadLine();
                    Console.Write("Enter plain: ");
                    String plain = Console.ReadLine();
                    string crypted = "";
                    //plain = "RUSKYPREZIDENTVLADIMIRPUTINPRONESLVECTVRTEKTRADICNIPROJEVOSTAVUFEDERACEVENOVALSETOMUZERUSKOMUSIPOKRACOVATVTRANSFORMACIANEMUZESESPOKOJITSESOUCASNYMSTAVEMZMINILSTOUPAJICIPOCETCHUDYCHIZAOSTALOUINFRASTRUKTURUNUTNOUPODPORUDUCHODCUMIMLADYMRODINYMABYSEZVRYTILNEPRIZNIVYDEMOGRAFICKYVYVOJ";
                    List<List<char>> arr = new List<List<char>>();
                    List<char> line = new List<char>();
                    string key = getKeyFromText(sKey, 1);
                    for (int i = 0; i < plain.Length; i++)
                    {
                        line.Add(plain[i]);
                        if (i > 0 && (i + 1) % key.Length == 0)
                        {
                            arr.Add(line);
                            line = new List<char>();
                        }
                    }
                    if (line.Count != 0)
                    {
                        int fill = key.Length - line.Count;
                        for (int i = 0; i < fill; i++)
                            line.Add('X');

                        arr.Add(line);
                    }

                    for (int i = 0; i < arr.Count; i++)
                    {

                        for (int j = 0; j < key.Length; j++)
                        {
                            int pos = Int32.Parse(key[j].ToString()) - 1;
                            crypted += arr[i][pos];
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine(crypted);
                }
                else if (method == "6")
                {
                    Console.Write("Enter key: ");
                    string sKey = Console.ReadLine();
                    string key = getKeyFromText(sKey, 2);
                    Console.Write("Enter crypttext: ");
                    String crypted = Console.ReadLine();
                    //crypted = "KYSURPIDZERELAVTNDRPIMIUPRNITOLVSENERTVTCEADRTKIPRINCOOSVEJTFEUVADCEAREVVAONELOMTESUUSREZKSIUMOPACRKOOVTTAVRFOSNARIACAMNZEUMESOKPSEOSETIJSASCUONTASMYVMIZMENTOSLIUICJAPIETCOPCYCDUHHOSAZITUIOLANSTARFRURTKUUNOTUNUPODOPRCHUDUOMIUCDMYMDALRNYIDOMSEYBAZTIYRVLRIPENZYDVINERAGOMFYVKCIYXXJOVX";
                    string plain = "";
                    List<List<char>> arr = new List<List<char>>();
                    List<char> line = new List<char>();
                    
                    for (int i = 0; i < crypted.Length; i++)
                    {
                        line.Add(crypted[i]);
                        if (i > 0 && (i + 1) % key.Length == 0)
                        {
                            arr.Add(line);
                            line = new List<char>();
                        }
                    }
                    if(line.Count != 0) arr.Add(line);

                    for (int j = 0; j < arr.Count; j++)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            int pos = Int32.Parse(key[i].ToString()) - 1;
                            plain += arr[j][pos];
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine(plain);
                }
               
            }

                    
        }
    }
}
