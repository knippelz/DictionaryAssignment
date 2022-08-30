namespace DictionaryAssignmentLibraries;
using System;
using System.Linq;
public static class CompoundWordLibrary
{
    public static bool IsValidCompoundWord(string firstWord, string secondWord, int targetLength) {
        int proposedLength = firstWord.Length + secondWord.Length;
        return (proposedLength == targetLength);
    }
}

public class CompoundWord
{
    public string firstWord { get; set; }
    public string secondWord { get; set; }

    public CompoundWord(string word1, string word2)
    {
        firstWord = word1;
        secondWord = word2;
    }

    public string compound()
    {
        return firstWord + secondWord;
    }

    public override string ToString()
    {
        return $"{firstWord} + {secondWord} => {compound()}";
    }
}

public class DictionaryTracker
{
    public List<CompoundWord> finalWords { get; set;}
    public string[] rawWords { get; set;}
    public int targetLength { get; set;}
    public Dictionary<int, List<string>> wordsByLength;
    
    public DictionaryTracker(string[] rawWords, int targetLength = 6)
    {
        this.targetLength = targetLength;
        this.rawWords = rawWords;
        this.finalWords = new List<CompoundWord>();
        this.wordsByLength = new Dictionary<int, List<string>>();
    }

    public void sortWordsByLength()
    {
        foreach (string word in rawWords)
        {

            if (word.Length < this.targetLength)
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
        }
    }

    public void calculateCompoundWords()
    {
        foreach (KeyValuePair<int, List<string>> wordsList in this.wordsByLength)
        {
            int currentLength = wordsList.Key;
            int neededLength = this.targetLength - currentLength;
            if (currentLength > 0 && neededLength >= 1 && this.wordsByLength.ContainsKey(neededLength))
            {
                List<string> currentWords = wordsList.Value;
                currentWords.ForEach(firstWord => {
                    this.wordsByLength[neededLength].ForEach(secondWord => {
                        CompoundWord newWord = new CompoundWord(firstWord, secondWord);
                        this.finalWords.Add(newWord);
                    });
                });
            }
        }
    }

    public void sortFinalWords()
    {
        IEnumerable<CompoundWord> sortedWords = this.finalWords.OrderBy(word => word.compound()).ThenBy(word => word.firstWord.Length);
        this.finalWords = sortedWords.ToList();
        // System.IO.File.WriteAllLines($"finalWords.txt", sortedWords.ToList().ConvertAll(word => word.ToString()));
    }

    public void generateCompoundWords()
    {
        this.sortWordsByLength();
        this.calculateCompoundWords();
        this.sortFinalWords();
    }

    public List<string> outputList()
    {
        return this.finalWords.ToList().ConvertAll(word => word.ToString());
    }

    public void outputToConsole()
    {
        this.outputList().ForEach(word => Console.WriteLine(word.ToString()));
    }
}