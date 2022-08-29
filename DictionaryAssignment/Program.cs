using DictionaryAssignmentLibraries;
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<CompoundWord> finalWords = new List<CompoundWord>();
            int targetLength = 6;
            string[] rawWords = System.IO.File.ReadAllLines("dictionary.txt");
            Dictionary<int, List<string>> wordsByLength = new Dictionary<int, List<string>>();

            foreach (string word in rawWords)
            {
                if (!wordsByLength.ContainsKey(word.Length))
                {
                    List<string> init = new List<string>();
                    init.Add(word);
                    wordsByLength.Add(word.Length, init);
                } else {
                    wordsByLength[word.Length].Add(word);
                }
            }
            
            foreach (KeyValuePair<int, List<string>> wordsList in wordsByLength)
            {
                int currentLength = wordsList.Key;
                int neededLength = targetLength - currentLength;
                if (currentLength > 0 && neededLength >= 1 && wordsByLength.ContainsKey(neededLength))
                {
                    List<string> currentWords = wordsList.Value;
                    currentWords.ForEach(firstWord => {
                        wordsByLength[neededLength].ForEach(secondWord => {
                            CompoundWord newWord = new CompoundWord(firstWord, secondWord);
                            finalWords.Add(newWord);
                        });
                    });
                }
                // Console.WriteLine("---------");
                // Console.WriteLine($"Array of Words with Length = {wordsList.Key}:");
                // wordsList.Value.ForEach(word => Console.Write("{0},", word));
                // System.IO.File.WriteAllLines($"wordsList_Length-{wordsList.Key}.txt", wordsList.Value);
            }

            IEnumerable<CompoundWord> query = finalWords.OrderBy(word => word.compound()).ThenBy(word => word.firstWord.Length);
            System.IO.File.WriteAllLines($"finalWords.txt", query.ToList().ConvertAll(word => word.ToString()));
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}