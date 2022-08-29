namespace DictioanryAssignmentLibraries;
public static class CompoundWordLibrary
{
    public static bool IsValidCompoundWord(string firstWord, string secondWord, int targetLength) {
        int proposedLength = firstWord.Length + secondWord.Length;
        return (proposedLength == targetLength);
    }
}
