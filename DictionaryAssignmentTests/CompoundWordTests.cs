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
    }
}