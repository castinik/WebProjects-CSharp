using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CombinationsMakerConsole
{
    static class Iter
    {
    	public static List<TimeSpan> timers = new List<TimeSpan>();

        // dictionary where add, remove modify each list of char.
        public static Dictionary<Dictionary<int, string>, List<char>> Vocabs = new Dictionary<Dictionary<int, string>, List<char>>
        {
            {new Dictionary<int, string> 
                {
                    { 1, "Complete (80 characters)" } // index, title
                }, new List<char> {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'w', 'v', 'x', 'y', 'z', 'A', 'B', 'C',
                'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                'T', 'U', 'W', 'V', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8',
                '9', '+', '×', '÷', '=', '/', '_', '€', '!', '@', '#', '$', '%', '^', '&', '*',
                '-', ':', ';', ' ' } 
            },
            {new Dictionary<int, string> 
                { 
                    { 2, "Alfabetic (26 characters)" } 
                }, new List<char> {'a', 'b', 'c', 'd', 'e', 'f', 'g','h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'w', 'v', 'x', 'y', 'z'}
            },
            {new Dictionary<int, string> 
                {   
                    { 3, "Numeric (0 - 9)" } 
                }, new List<char> {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}
            },
            {new Dictionary<int, string> 
                { 
                    { 4, "Debug (0 1 2)" } 
                }, new List<char> {'0', '1', '2'}
            },
        };

        public static List<string> GetCombinations(int lenght, int vocabChoice)
        {
            // get how many combinations will be created.
            int combinations = Convert.ToInt32(Math.Pow(GetVocabList(vocabChoice).Count(), lenght));
        	Console.WriteLine("Creating " + combinations + " combinations...");
            
            // filling the word to avoid error in iterator().
			string currentWordCombined = string.Empty;
            for(int i = 0; i < lenght; i++)
            	currentWordCombined += (GetVocabList(vocabChoice))[0];
            	
            // creating the first container that will be passed to iterator().
            Container container = new Container{
            	Vocab = GetVocabList(vocabChoice),
            	WordCombined = currentWordCombined,
            	CharPosition = 0,
            	VocabPosition = 0
            };
            List<string> combinationsContainer = Iterator(container, 1);

            return combinationsContainer;
        }

        static List<string> Iterator(Container oldContainer, int vocabPosEntry) {
            // length of the word and vocab elements.
        	int wordCount = oldContainer.WordCombined.Length;
            int vocabCount = oldContainer.Vocab.Count();

            // lists of new combinations.
        	List<string> combinations = new List<string>();
            
            // iter on the vocaboulary incrementing 1 every Iterator() calling.
            while(true)
            {
                // if vocab or wordCombined index's are outside of their limits then exit the loop.
                if (oldContainer.VocabPosition == vocabCount)
                    break;
                if (oldContainer.CharPosition == wordCount)
                    break;
                
                // make the substitution of char.
                oldContainer.WordCombined = SlideVocabs(oldContainer);
                
                // save the new WordCombined in the combinations list.
                combinations.Add(oldContainer.WordCombined);
                	
                // set the variable for the next turn.
                Container newContainer = oldContainer.Copy();
                oldContainer.VocabPosition += 1;
                newContainer.CharPosition += 1;
                newContainer.VocabPosition = vocabPosEntry;

                /* calling the iterational function then store its data in a new list
                    and save it in combinations list through a foreach loop, after 
                    checking the presence in the list with CheckThePresence() */
                List<string> newCombinations = Iterator(newContainer, 0);
                foreach (string s in newCombinations)
                {
                	if(!CheckThePresence(s, combinations))
                    	combinations.Add(s);
                }
            }
            return combinations;
        }

        // return a new word with the char replaced in the position taken by the passed value.
        static string SlideVocabs(Container container)
        {
            // transform WordCombined in array of char to semplify the substitution.
            char[] arrWordCombined = container.WordCombined.ToCharArray();
            arrWordCombined[container.CharPosition] = container.Vocab[container.VocabPosition];

            string newWordCombined = string.Empty;            
            foreach (char c in arrWordCombined)
                newWordCombined += c; 

            return newWordCombined;
        }

        // return the list of value of choosed vocaboulary by the index given. 
        static List<char> GetVocabList(int index)
        {
            return Iter.Vocabs[Iter.Vocabs.Keys.ElementAt(index)];
        }

        // return the title of choosed vocaboulary by the index given.
        static string GetVocabTitle(int index)
        {
            return Iter.Vocabs.Keys.ElementAt(index).FirstOrDefault().Value;
        }

        // return the correct char-path to avoid path errors in the various device systems.
        static string GetDivPath()
        {
            OperatingSystem os = Environment.OSVersion;
            string osPlatform = os.Platform.ToString();
            if (osPlatform == "Unix")
                return "/";
            else
                return "\\";
        }

        // check the presence of the item in the list passed.
        static bool CheckThePresence(string item, List<string> list)
        {
        	foreach(string s in list)
        	{
        		if(item == s)
        			return true;
        	}
        	return false;
        }

        // create the view for the user.
        public static void MakeMenu()
        {
        	for(int i = 0; i < Vocabs.Count(); i++)
        		Console.WriteLine("[" + (i + 1) + "] - " + GetVocabTitle(i));
            Console.WriteLine("[" + (Vocabs.Count() + 1) + "] - To exit");
        }
        
        // print the output.
        public static void PrintOutput(List<string> combinations, int columns)
        {
        	int k = 0; // used to comparing with columns.
            for (int i = 0; i < combinations.Count(); i++)
            {
                if (k >= columns)
                {
                    k = 0;
                    Console.WriteLine();
                }
                Console.Write(combinations[i] + "  ");
            }
            Console.WriteLine("\n");
        }
        
        // save on file.
        public static void SaveOnFile(List<string> combinations)
        {
        	Console.Clear();
        	Console.WriteLine("Saving on file...");
        	DateTime dateTime = DateTime.Now;
            string time = Convert.ToString(dateTime).Replace(":", ".");
        	// found the correct char depending by the OS.
        	string divPath = GetDivPath();
        	
        	string path = Directory.GetCurrentDirectory();
        	string directory = divPath + "combinations";

        	// set the file name wich is the current date.
        	string file = divPath + "combinations_" + time.Replace("/", "-") + ".txt";

        	// try to go in combinations directory.
        	try
        	{
        		Directory.SetCurrentDirectory(path + directory);
        	}
        	// else create combinations directory.
        	catch(System.IO.DirectoryNotFoundException)
        	{
        		Directory.CreateDirectory(path + directory);
        		Directory.SetCurrentDirectory(path + directory);
        	}
        	// create new file.
        	using(FileStream combFile = File.Create(path + directory + file))
        	{
        		foreach(string s in combinations)
        		{
        			// transform string in byte array and write it on file.
        			byte[] stringa = new UTF8Encoding(true).GetBytes(s + "\n");
        			combFile.Write(stringa, 0, stringa.Count());
        		}
        	}
        	// return to the parent directory.
        	Directory.SetCurrentDirectory(path);
        	Console.WriteLine("Combinations saved on file: " + file);
        }
    }
}
