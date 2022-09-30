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
    }
}
