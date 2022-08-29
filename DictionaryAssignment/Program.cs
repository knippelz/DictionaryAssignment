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
            string[] rawWords = System.IO.File.ReadAllLines("dictionary.txt");
            DictionaryTracker dT = new DictionaryTracker(rawWords);

            dT.outputToConsole();

        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}