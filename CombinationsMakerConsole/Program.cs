using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CombinationsMakerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
        	CombinationsMaker();
        }

        static void CombinationsMaker(int columns = 8)
        {
            while (true)
            {
                // choose the set of characters.
                Console.WriteLine("Choose witch set of characters you want use:");
                Iter.MakeMenu();
                try
                {
                    int choose = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (choose < 0 || choose > Iter.Vocabs.Count() + 1)
                    {
                        Console.WriteLine("You must choose a valid option.\n\nPress any key to continue...\n");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    if (choose == Iter.Vocabs.Count())
                        break;

                    // get the length of the word.
                    Console.Clear();
                    Console.WriteLine("Insert the lenght of the word: ");
                    int lenght = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();                    

                    // start the stopwatch.
                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    // start the iteration.
                    List<string> combinations = Iter.GetCombinations(lenght, choose);

                    // stop the stopwatch.
                    timer.Stop();

                    Console.WriteLine("\n\nCreating combinations in " + timer.Elapsed + "\n\n");

                    // choose the output.
                    Console.WriteLine("Save results on file or print them on screen? (May take some time) \n");
                    Console.WriteLine("[1] - Save on file (/combinations)");
                    Console.WriteLine("[2] - Print on screen");
                    Console.WriteLine("[3] - Skip");
                    int outChoose = Convert.ToInt16(Console.ReadLine());
                    if(outChoose == 1)
                        Iter.SaveOnFile(combinations);
                    else if(outChoose == 2)
                        Iter.PrintOutput(combinations, columns);
                    else if(outChoose == 3)
                    {
                    	Console.Clear();
                    	continue;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("You must choose a valid option.\n\nPress any key to continue...\n");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
