using Microsoft.VisualStudio.TestTools.UnitTesting;

using DictionaryAssignmentLibraries;

namespace DictionaryAssignmentTests
{
    [TestClass]
    public class CounpoundWordTests
    {
        [TestMethod]
        public void compoundIsCorrect()
        {
            string word1 = "test";
            string word2 = "er";
            string expectedCompoundWord = "tester";

            CompoundWord testCompound = new CompoundWord(word1, word2);

            Assert.AreEqual(testCompound.compound(), expectedCompoundWord, "Compound word not matching");
        }

        [TestMethod]
        public void compoundToString()
        {
            string word1 = "test";
            string word2 = "er";
            string expectedString = "test + er => tester";

            CompoundWord testCompound = new CompoundWord(word1, word2);

            Assert.AreEqual(testCompound.ToString(), expectedString, "Compound word not matching");
        }
    }

    [TestClass]
    public class DictionaryTrackerTests
    {
        [TestMethod]
        public void sortWordsByLength_Initialization()
        {
            string testWord = "test";
            string[] testArray = { testWord };
            int expectedKey = testWord.Length;
            DictionaryTracker dT = new DictionaryTracker(testArray);
            dT.sortWordsByLength();

            Assert.IsTrue(dT.wordsByLength.ContainsKey(expectedKey), "wordsByLength missing key");
            Assert.AreEqual(dT.wordsByLength[expectedKey].Count, 1, "wordsByLength array of strings is incorrect");
            Assert.AreEqual(dT.wordsByLength[expectedKey].First(), testWord, "wordsByLength item is incorrect");
        }

        [TestMethod]
        public void sortWordsByLength_AddingWords()
        {
            string testWord = "test";
            string testWord2 = "fred";
            string[] testArray = { testWord, testWord2 };
            int expectedKey = testWord.Length;
            DictionaryTracker dT = new DictionaryTracker(testArray);
            dT.sortWordsByLength();

            Assert.IsTrue(dT.wordsByLength.ContainsKey(expectedKey), "wordsByLength missing key");
            Assert.AreEqual(dT.wordsByLength[expectedKey].Count, 2, "wordsByLength array of strings is incorrect");
            // There has to be a better way to check these items rather than "first"/"last"...
            Assert.AreEqual(dT.wordsByLength[expectedKey].First(), testWord, "wordsByLength first word is incorrect");
            Assert.AreEqual(dT.wordsByLength[expectedKey].Last(), testWord2, "wordsByLength second word is incorrect");
        }

        [TestMethod]
        public void sortWordsByLength_SkipWordsThatAreTooLong()
        {
            string testWord = "supercalifragilisticexpialidocious";
            string[] testArray = { testWord };
            int expectedKey = testWord.Length;
            DictionaryTracker dT = new DictionaryTracker(testArray);
            dT.sortWordsByLength();

            Assert.IsFalse(dT.wordsByLength.ContainsKey(expectedKey), "wordsByLength has invalid key");
        }

        [TestMethod]
        public void calculateCompoundWords_addsTwoWordsTogether()
        {
            string testWord1 = "te";
            string testWord2 = "ster";
            CompoundWord expectedCompound1 = new CompoundWord(testWord1, testWord2);
            CompoundWord expectedCompound2 = new CompoundWord(testWord2, testWord1);
            string[] testArray = { testWord1, testWord2 };
            
            DictionaryTracker dT = new DictionaryTracker(testArray);
            dT.sortWordsByLength();
            dT.calculateCompoundWords();

            Assert.AreEqual(dT.finalWords.Count, 2, "compoundwords incorrect length");
            // I don't like this method, was having a tough time getting Contains() or list comparison to behave
            // I also don't like using the ToString() method for this - I should use a helper to compare these next time!!!
            Assert.AreEqual(dT.finalWords.First().ToString(), expectedCompound1.ToString(), "compoundword1 missing");
            Assert.AreEqual(dT.finalWords.Last().ToString(), expectedCompound2.ToString(), "compoundword2 missing");
        }

        [TestMethod]
        public void sortFinalWords_alphabeticalSort()
        {
            string testWord1 = "te";
            string testWord2 = "ster";
            CompoundWord expectedCompound1 = new CompoundWord(testWord2, testWord1);
            CompoundWord expectedCompound2 = new CompoundWord(testWord1, testWord2);
            string[] testArray = { testWord1, testWord2 };
            List<CompoundWord> expectedList = new List<CompoundWord> { expectedCompound1, expectedCompound2 };

            DictionaryTracker dT = new DictionaryTracker(testArray);
            dT.sortWordsByLength();
            dT.calculateCompoundWords();
            dT.sortFinalWords();
            
            Assert.AreEqual(dT.finalWords.First().ToString(), expectedCompound1.ToString(), "incorrect alphabetical sorting");
        }

        [TestMethod]
        public void sortFinalWords_firstWordTiebreaker()
        {
            string testWord1 = "test";
            string testWord2 = "er";
            string testWord3 = "te";
            string testWord4 = "ster";
            
            CompoundWord expectedCompound1 = new CompoundWord(testWord1, testWord2);
            CompoundWord expectedCompound2 = new CompoundWord(testWord3, testWord4);
            string[] testArray = { testWord1, testWord2, testWord3, testWord4 };

            DictionaryTracker dT = new DictionaryTracker(testArray);
            dT.sortWordsByLength();
            dT.calculateCompoundWords();
            dT.sortFinalWords();
            
            int shortFirstWordIndex = dT.finalWords.FindIndex(word => word.firstWord == testWord3 && word.secondWord == testWord4);
            int longFirstWordIndex = dT.finalWords.FindIndex(word => word.firstWord == testWord1 && word.secondWord == testWord2);

            Assert.IsTrue(longFirstWordIndex - shortFirstWordIndex == 1, "compound words not next to each other");
            Assert.IsTrue(shortFirstWordIndex < longFirstWordIndex, "firstword tiebreaker sort not working");
        }

        [TestMethod]
        public void outputList()
        {
            string testWord1 = "te";
            string testWord2 = "ster";
            CompoundWord expectedCompound1 = new CompoundWord(testWord2, testWord1);
            CompoundWord expectedCompound2 = new CompoundWord(testWord1, testWord2);
            string[] testArray = { testWord1, testWord2 };

            List<string> expectedOutput = new List<string> { expectedCompound1.ToString(), expectedCompound2.ToString() };

            DictionaryTracker dT = new DictionaryTracker(testArray);
            dT.generateCompoundWords();

            CollectionAssert.AreEqual(dT.outputList(), expectedOutput, "outputList is incorrect");
        }

    }
}