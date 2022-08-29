namespace DictionaryAssignmentLibraries;
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