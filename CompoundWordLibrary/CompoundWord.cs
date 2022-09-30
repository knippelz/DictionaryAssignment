namespace CompoundWordLibrary
{
    public class CompoundWord : IEquatable<CompoundWord>
    {
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }

        public CompoundWord(string word1, string word2)
        {
            FirstWord = word1;
            SecondWord = word2;
        }

        public string Compound()
        {
            return FirstWord + SecondWord;
        }

        public override string ToString()
        {
            return $"{FirstWord} + {SecondWord} => {Compound()}";
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as CompoundWord);
        }

        public bool Equals(CompoundWord other)
        {
            if (other == null)
                return false;
            return this.FirstWord.Equals(other.FirstWord) && this.SecondWord.Equals(other.SecondWord);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstWord, SecondWord);
        }
    }
}
