using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RadixSortOptimized
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 29, 72, 98, 13, 87, 66, 52, 51, 36 };
            int[] LSD = new int[arr.Length];
            int[] lastSorted = new int[10]; // array from 0 - 9

            int toInsertValue = 0;
            int toInsertLSD = 0;

            int baseNum = 1;

            bool sorted = false;

            int charToDisplay = 0;
            string temp = "";
            int tempVal = 0;

            while (!sorted)
            {
                Console.Clear();
                sorted = true;

                // reset lastSorted array
                for (int a = 0; a < lastSorted.Length; a++)
                    lastSorted[a] = 0;

                for (int x = 0; x < arr.Length; x++)
                {
                    LSD[x] = arr[x] / baseNum % 10;
                    if (LSD[x] > 0)
                        sorted = false;
                }

                if (sorted)
                    break;

                Console.WriteLine("The number array to be sorted in base {0}", baseNum);
                foreach (int a in arr)
                    Console.WriteLine("\t" + a);
                Console.ReadKey();
                Console.Clear();

                for(int x = 0; x < LSD.Length; x++)
                {
                    #region Highlighting all LSDs
                    // display
                    Console.WriteLine("Base {0} Getting all LSDs", baseNum);
                    for (int a = 0; a < arr.Length; a++)
                    {
                        temp = arr[a] + ""; // converts the int into a string
                        Console.Write("\t");
                        for (int b = 0; b < temp.Length; b++)
                        {
                            tempVal = temp.Length - 1 - b;

                            if (tempVal < 0) // logic for absolute value
                                tempVal *= -1;

                            if (tempVal == charToDisplay)
                                Console.BackgroundColor = ConsoleColor.Red;
                            else
                                Console.ResetColor();

                            Console.Write(temp[b]);
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    #endregion

                    toInsertValue = arr[x];
                    toInsertLSD = LSD[x];
                    arr[x] = -1;

                    #region Highlight Removal of value to be moved
                    // display
                    Console.ResetColor();
                    Console.WriteLine("Base {0} : Removing {1}.", baseNum, toInsertValue);
                    for (int a = 0; a < arr.Length; a++)
                    {
                        temp = arr[a] + "";
                        Console.Write("\t");
                        if (arr[a] > 0)
                        {
                            for (int b = 0; b < temp.Length; b++)
                            {
                                tempVal = temp.Length - 1 - b;

                                if (tempVal < 0)
                                    tempVal *= -1;

                                Console.ResetColor();

                                if (tempVal == charToDisplay)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }

                                Console.Write(temp[b]);
                            }
                            Console.WriteLine();
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("  ");
                            Console.ResetColor();
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Console.ResetColor();
                    #endregion

                    for (int y = x - 1; y >= lastSorted[LSD[x]]; y--)
                    {
                        arr[y + 1] = arr[y];
                        LSD[y + 1] = LSD[y];
                        arr[y] = -1;

                        #region Highlight moving of values
                        // display
                        Console.ResetColor();
                        Console.WriteLine("Base {0} : Moving {1}.", baseNum, arr[y + 1]);
                        for (int a = 0; a < arr.Length; a++)
                        {
                            temp = arr[a] + "";
                            Console.Write("\t");
                            if (arr[a] > 0)
                            {
                                for (int b = 0; b < temp.Length; b++)
                                {
                                    tempVal = temp.Length - 1 - b;

                                    if (tempVal < 0)
                                        tempVal *= -1;

                                    Console.ResetColor();

                                    if (tempVal == charToDisplay)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                    }

                                    Console.Write(temp[b]);
                                }
                                Console.WriteLine();
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("  ");
                                Console.ResetColor();
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                        Console.ResetColor();
                        #endregion
                    }

                    arr[lastSorted[LSD[x]]] = toInsertValue;
                    LSD[lastSorted[LSD[x]]] = toInsertLSD;

                    for (int y = toInsertLSD; y < lastSorted.Length; y++)
                        lastSorted[y]++;
                }


                Console.WriteLine("The Sorted Number array base {0}", baseNum);
                foreach (int a in arr)
                    Console.WriteLine("\t" + a);
                Console.ReadKey();


                baseNum *= 10;
                charToDisplay++;
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
