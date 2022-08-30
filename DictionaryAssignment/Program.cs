using DictionaryAssignmentLibraries;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        int targetLength = 0;
        DictionaryTracker dT;

        // Check for argument for target length
        // There's got to be a better way that just args[0]...
        if (args.Length == 1 && !int.TryParse(args[0], out targetLength)) {
            Console.WriteLine("target length given is not valid");
        }
        try
        {
            string[] rawWords = System.IO.File.ReadAllLines("dictionary.txt");
            if (targetLength == 0)
            {
                dT = new DictionaryTracker(rawWords);
            } else
            {
                dT = new DictionaryTracker(rawWords, targetLength);
            }

            dT.generateCompoundWords();
            dT.outputToConsole();
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}