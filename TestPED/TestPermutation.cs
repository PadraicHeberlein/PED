using PED.Util;
using Xunit;

namespace TestPED
{
    public class TestPermutation
    {
        [Fact]
        public void TestGenerator_CheckForFiniteTimeGeneration()
        {
            Permutation testPermutation = new Permutation();
            Assert.True(testPermutation != null);
        }

        [Fact]
        public void TestInverse_CheckIfTwoCompositionsProducesOriginal()
        {
            Permutation testPermutation = new Permutation();
            Permutation testInverse = testPermutation.Inverse();
            Assert.Equal(testPermutation, testInverse.Inverse());
        }
    }
}
