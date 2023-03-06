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

        static int R = 100;
        static int M = 0;

        static int[] Mass = new int[1000];

        static int[] Mass1 = new int[1000];
        static int[] Mass2 = new int[1000];
        static int[] Mass2_1 = new int[1000];
        static int[] Mass3 = new int[1000];





        static void Clear()
        {

            Count_For = 0;
            Count_If = 0;

            if (M == 0)
                for (int i = 0; i < Mass1.Length; i++)
                Mass[i] = Mass1[i];
            if (M == 1)
                for (int i = 0; i < Mass2.Length; i++)
                Mass[i] = Mass2[i];
            if (M == 2)
                for (int i = 0; i < Mass2_1.Length; i++)
                Mass[i] = Mass2_1[i];
            if (M == 3)
                for (int i = 0; i < Mass3.Length; i++)
                Mass[i] = Mass3[i];
        }


        static void Main(string[] args)
        {
            Arrays();

            Console.WriteLine(" Mass1 ▼");
            for (int i = 0; i < Mass1.Length; i++)
                Console.Write(" " + Mass1[i]);

            Console.WriteLine(" \n Mass2 ▼");
            for (int i = 0; i < Mass2.Length; i++)
                Console.Write(" " + Mass2[i]);

            Console.WriteLine(" \n Mass2_1 ▼");
            for (int i = 0; i < Mass2_1.Length; i++)
                Console.Write(" " + Mass2_1[i]);

            Console.WriteLine(" \n Mass3 ▼");
            for (int i = 0; i < Mass3.Length; i++)
                Console.Write(" " + Mass3[i]);
            Console.WriteLine();

            
            while (M-4 < 0)
            {
                Bubble();
                Bubble_Flag();
                Shaker();
                Insertion();
                Shell();
                QSort();

                M++;

                Console.WriteLine("\n ↑↑↑↑↑↑↑↑↑↑↑ Mass " + M);
            }



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

            Console.Write("\n Bubble ▼");
            //for (int i = 0; i < Mass.Length; i++)
            //    Console.Write(" " + Mass[i]);
            Console.Write("if = " + Count_If + " for = " + Count_For);
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

            Console.Write("\n Bubble_Flag ▼");
            //for (int i = 0; i < Mass.Length; i++)
            //    Console.Write(" " + Mass[i]);
            Console.Write("if = " + Count_If + " for = " + Count_For);
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

            Console.Write("\n Shaker ▼");
            //for (int i = 0; i < Mass.Length; i++)
            //    Console.Write(" " + Mass[i]);
            Console.Write("if = " + Count_If + " for = " + Count_For);
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

            Console.Write("\n Insertion ▼");
            //for (int i = 0; i < Mass.Length; i++)
            //    Console.Write(" " + Mass[i]);
            Console.Write("if = " + Count_If + " for = " + Count_For);
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

            Console.Write("\n Shell ▼");
            //for (int i = 0; i < Mass.Length; i++)
            //    Console.Write(" " + Mass[i]);
            Console.Write("if = " + Count_If + " for = " + Count_For);
        }

        static void QSort()
        {
            Clear();           

            int[] sortedArray = QuickSort(Mass, 0, Mass.Length - 1);

            Console.Write("\n QSort ▼");
            //for (int i = 0; i < Mass.Length; i++)
            //    Console.Write(" " + Mass[i]);
            Console.Write("if = " + Count_If + " for = " + Count_For);            
        }

        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                Count_If++;
                return array;
            }

            int pivotIndex = GetPivotIndex(array, minIndex, maxIndex);

            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        private static int GetPivotIndex(int[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;

            //Random rand = new Random();
            //int OpEl = rand.Next(0, Mass.Length - 1);

            for (int i = minIndex; i <= maxIndex; i++)
            {
                Count_For++;
                if (array[i] < array[maxIndex])
                {
                    Count_If++;
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);

            return pivot;
        }

        private static void Swap(ref int leftItem, ref int rightItem)
        {
            var temp = leftItem;
            leftItem = rightItem;
            rightItem = temp;
        }
    }
}
