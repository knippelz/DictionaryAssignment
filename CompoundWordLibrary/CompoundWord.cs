namespace CompoundWordLibrary
{
    public class CompoundWord
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
            return this.FirstWord.Equals(((CompoundWord)obj).FirstWord) && this.SecondWord.Equals(((CompoundWord)obj).SecondWord);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstWord, SecondWord);
        }
    }
}
