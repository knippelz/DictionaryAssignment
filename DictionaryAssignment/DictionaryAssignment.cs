using System.Diagnostics;
using CompoundWordLibrary;

namespace DictionaryAssignment;

class DictionaryAssignment
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine("Timer started...");

        int targetLength = 0;

        if (args == null || args.Length < 2)
        {
            Console.WriteLine("Please specify an input file and output file as parameters.");
            return;
        }

        if (args.Length == 3 && !int.TryParse(args[2], out targetLength)) {
            Console.WriteLine("target length given is not valid");
        }

        try
        {
            string[] rawWords = File.ReadAllLines(args[0]);
            DictionaryTracker dT = targetLength == 0 ? new(rawWords) : new(rawWords, targetLength);
            dT.GenerateCompoundWords();
            dT.OutputToFile(args[1]);
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        stopwatch.Stop();
        TimeSpan timeSpan = stopwatch.Elapsed;
        Console.WriteLine("Final Time: " + timeSpan.TotalMilliseconds + "ms");
    }
}