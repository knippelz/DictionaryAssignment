namespace CompoundWordLibrary;

public class DictionaryTracker
{
    public HashSet<CompoundWord> Compounds { get; set;}
    public HashSet<string> RawWords { get; set;}
    public int TargetLength { get; set;}
    public Dictionary<int, HashSet<string>> WordsByLength;
    public List<CompoundWord> FinalWords { get; set; }

    public DictionaryTracker(string[] rawWords, int targetLength = 6)
    {
        this.TargetLength = targetLength;
        this.RawWords = new HashSet<string>(Array.ConvertAll(rawWords, word => word.ToLower()));
        this.Compounds = new HashSet<CompoundWord>();
        this.WordsByLength = new Dictionary<int, HashSet<string>>();
    }

    public bool IsValidCompoundWord(string firstWord, string secondWord)
    {
        int proposedLength = firstWord.Length + secondWord.Length;
        return (proposedLength == this.TargetLength);
    }

    public void SortWordsByLength()
    {
        foreach (var word in RawWords)
        {
            if (word.Length < this.TargetLength)
            {
                if (!WordsByLength.ContainsKey(word.Length))
                {
                    HashSet<string> init = new HashSet<string> { word };
                    WordsByLength.Add(word.Length, init);
                } else {
                    WordsByLength[word.Length].Add(word);
                }
            }
        }
    }

    public void CalculateCompoundWords()
    {
        foreach (var wordsList in this.WordsByLength)
        {
            int currentLength = wordsList.Key;
            int neededLength = this.TargetLength - currentLength;
            if (currentLength > 0 && neededLength >= 1 && this.WordsByLength.ContainsKey(neededLength))
            {
                var currentWords = wordsList.Value;
                foreach (var firstWord in currentWords){
                    foreach (var secondWord in this.WordsByLength[neededLength])
                    {
                        if (IsValidCompoundWord(firstWord, secondWord))
                        {
                            CompoundWord newWord = new(firstWord, secondWord);
                            this.Compounds.Add(newWord);
                        }
                    }
                }
            }
        }
    }

    public void SortFinalWords()
    {
        this.FinalWords = this.Compounds.OrderBy(word => word.Compound()).ThenBy(word => word.FirstWord.Length).ToList();
    }

    public void GenerateCompoundWords()
    {
        this.SortWordsByLength();
        this.CalculateCompoundWords();
        this.SortFinalWords();
    }

    public List<string> OutputList()
    {
        return this.FinalWords.ToList().ConvertAll(word => word.ToString());
    }

    public void OutputToConsole()
    {
        this.OutputList().ForEach(word => Console.WriteLine(word.ToString()));
    }

    public void OutputToFile(string outputFilePath)
    {
        File.WriteAllLines(outputFilePath, this.FinalWords.ToList().ConvertAll(word => word.ToString()));
    }
}