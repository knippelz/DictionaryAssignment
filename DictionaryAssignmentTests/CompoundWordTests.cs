using CompoundWordLibrary;

namespace DictionaryAssignmentTests;

public class CompoundWordTests
{
    [TestClass]
    public class CounpoundWordTests
    {
        [TestMethod]
        public void CompoundIsCorrect()
        {
            string word1 = "test";
            string word2 = "er";
            string expectedCompoundWord = "tester";

            CompoundWord testCompound = new CompoundWord(word1, word2);

            Assert.AreEqual(testCompound.Compound(), expectedCompoundWord, "Compound word not matching");
        }

        [TestMethod]
        public void CompoundToString()
        {
            string word1 = "test";
            string word2 = "er";
            string expectedString = "test + er => tester";

            CompoundWord testCompound = new CompoundWord(word1, word2);

            Assert.AreEqual(testCompound.ToString(), expectedString, "Compound word not matching");
        }

        [TestMethod]
        public void CompoundEqualsTrue()
        {
            string word1 = "test";
            string word2 = "er";

            CompoundWord testCompound = new CompoundWord(word1, word2);
            CompoundWord actualCompound = new CompoundWord(word1, word2);

            Assert.AreEqual(testCompound, actualCompound, "Compounds that should be equal are not");
        }

        [TestMethod]
        public void CompoundEqualsFirstWordMismatch()
        {
            string word1 = "test";
            string word2 = "er";
            string word3 = "bett";

            CompoundWord testCompound = new CompoundWord(word1, word2);
            CompoundWord actualCompound = new CompoundWord(word3, word2);

            Assert.AreNotEqual(testCompound, actualCompound, "Compound first word equality error");
        }

        [TestMethod]
        public void CompoundEqualsSecondWordMismatch()
        {
            string word1 = "test";
            string word2 = "er";
            string word3 = "ed";

            CompoundWord testCompound = new CompoundWord(word1, word2);
            CompoundWord actualCompound = new CompoundWord(word1, word3);

            Assert.AreNotEqual(testCompound, actualCompound, "Compound second word equality error");
        }

    }
}