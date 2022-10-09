using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Консольное1
{
    class Program
    {
        static int Count_For = 0;
        static int Count_If = 0;

        static int R = 10;

        static int[] Mass = new int[10];

        static int[] Mass1 = new int[10];
        static int[] Mass2 = new int[10];
        static int[] Mass2_1 = new int[10];
        static int[] Mass3 = new int[10];



        static void Clear()
        {

            Count_For = 0;
            Count_If = 0;

            for (int i = 0; i < Mass1.Length; i++)
                Mass[i] = Mass1[i];

            //for (int i = 0; i < Mass2.Length; i++)
            //    Mass[i] = Mass2[i];

            //for (int i = 0; i < Mass2_1.Length; i++)
            //    Mass[i] = Mass2_1[i];

            //for (int i = 0; i < Mass3.Length; i++)
            //    Mass[i] = Mass3[i];
        }


        static void Main(string[] args)
        {
            Arrays();

            Console.WriteLine(" Mass1 ▼");
            for (int i = 0; i < Mass1.Length; i++)
                Console.Write(" " + Mass1[i]);

            Console.WriteLine("\n \n Mass2 ▼");
            for (int i = 0; i < Mass2.Length; i++)
                Console.Write(" " + Mass2[i]);

            Console.WriteLine("\n \n Mass2_1 ▼");
            for (int i = 0; i < Mass2_1.Length; i++)
                Console.Write(" " + Mass2_1[i]);

            Console.WriteLine("\n \n Mass3 ▼");
            for (int i = 0; i < Mass3.Length; i++)
                Console.Write(" " + Mass3[i]);
            Console.WriteLine();



            Bubble();
            Bubble_Flag();
            Shaker();
            Insertion();
            Shell();



            Console.ReadLine();
        }

        static void Arrays()
        {     
            Random rand = new Random();

            for (int i = 0; i < Mass1.Length; i++)
                Mass1[i] = rand.Next(-R, R);

            for (int i = 0; i < Mass2.Length; i++) {
                if (i >= Mass2.Length / 2)
                    Mass2[i] = rand.Next(-R, R);
                else
                    Mass2[i] = i;
            }

            for (int i = 0; i < Mass2_1.Length; i++)
            {
                if (i >= Mass2_1.Length * 0.9)
                    Mass2_1[i] = rand.Next(-R, R);
                else
                    Mass2_1[i] = i;
            }

            for (int i = 0; i < Mass3.Length; i++)
            {
                Mass3[Mass3.Length - 1 - i] = i;
            }
        }

        static void Bubble()
        {
            Clear();            

            for (int j = 0; j < Mass.Length - 1; j++)
                for (int i = 0; i < Mass.Length - j - 1; i++)
                {
                    Count_For++;

                    if (Mass[i] > Mass[i + 1])
                    {
                        Count_If++;

                        var buf = Mass[i];
                        Mass[i] = Mass[i + 1];
                        Mass[i + 1] = buf;
                    }
                }

            Console.WriteLine("\n Bubble ▼");
            for (int i = 0; i < Mass.Length; i++)
                Console.Write(" " + Mass[i]);
            Console.WriteLine("\n if = " + Count_If + " for = " + Count_For);
        }


        static void Bubble_Flag()
        {
            Clear();
            
            for (int j = 0; j < Mass.Length - 1; j++)
            {
                bool Check = true;

                for (int i = 0; i < Mass.Length - j - 1; i++)
                {
                    Count_For++;

                    if (Mass[i] > Mass[i + 1])
                    {
                        Count_If++;

                        var buf = Mass[i];
                        Mass[i] = Mass[i + 1];
                        Mass[i + 1] = buf;

                        Check = false;
                    }
                }
                if (Check)
                {
                    Count_If++;
                    break;
                }
            }

            Console.WriteLine("\n Bubble_Flag ▼");
            for (int i = 0; i < Mass.Length; i++)
                Console.Write(" " + Mass[i]);
            Console.WriteLine("\n if = " + Count_If + " for = " + Count_For);
        }

        static void Shaker()
        {
            Clear();
            
            for (int j = 0; j < Mass.Length - 1; j++)
            {
                bool Check = true;

                for (int i = j; i < Mass.Length - j - 1; i++)
                {
                    Count_For++;

                    if (Mass[i] > Mass[i + 1])
                    {
                        Count_If++;

                        var buf = Mass[i];
                        Mass[i] = Mass[i + 1];
                        Mass[i + 1] = buf;

                        Check = false;
                    }
                }

                if (Check)
                    break;

                Check = true;

                for (int i = Mass.Length - j - 1; i > j; i--)
                {
                    Count_For++;

                    if (Mass[i-1] > Mass[i])
                    {
                        Count_If++;

                        var buf = Mass[i];
                        Mass[i] = Mass[i - 1];
                        Mass[i - 1] = buf;

                        Check = false;
                    }
                }

                if (Check)
                {
                    Count_If++;
                    break;
                }
            }

            Console.WriteLine("\n Shaker ▼");
            for (int i = 0; i < Mass.Length; i++)
                Console.Write(" " + Mass[i]);
            Console.WriteLine("\n if = " + Count_If + " for = " + Count_For);
        }

        static void Insertion()
        {
            Clear();

            for (int j = 1; j < Mass.Length; j++)  
                for (int i = j; i > 0; i--)
                {
                    Count_For++;

                    if (Mass[i - 1] > Mass[i])
                    {
                        Count_If++;

                        var buf = Mass[i];
                        Mass[i] = Mass[i - 1];
                        Mass[i - 1] = buf;                        
                    }
                    else
                        break;
                }       

            Console.WriteLine("\n Insertion ▼");
            for (int i = 0; i < Mass.Length; i++)
                Console.Write(" " + Mass[i]);
            Console.WriteLine("\n if = " + Count_If + " for = " + Count_For);
        }

        static void Shell()
        {
            Clear();
            int Step = Mass.Length;

            while (Step != 0)
            {
                Step /= 2;

                bool Check = true;

                Count_For++;

                for (int j = Step; j < Mass.Length; j++)
                    for (int i = j; i > Step - 1; i -= Step)
                    {
                        Count_For++;

                        if (Mass[i - Step] > Mass[i])
                        {
                            Count_If++;

                            var buf = Mass[i];
                            Mass[i] = Mass[i - Step];
                            Mass[i - Step] = buf;

                            Check = false;
                        }
                        else
                            break;
                    }

                if (Check)
                {
                    Count_If++;
                    break;
                }
            }

            Console.WriteLine("\n Shell ▼");
            for (int i = 0; i < Mass.Length; i++)
                Console.Write(" " + Mass[i]);
            Console.WriteLine("\n if = " + Count_If + " for = " + Count_For);
        }
    }
}
