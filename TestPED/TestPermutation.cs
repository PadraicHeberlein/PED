using PED.Util;
using Xunit;

namespace TestPED
{
    public class TestPermutation
    {
        [Fact]
        public void TestGenerator_CheckForFiniteTimeGeneration()
        {
            uint[] testPermutation = Permutation.Generate();
            Assert.True(testPermutation != null);
        }
        [Fact]
        public void TestInverse_CheckIfTwoCompositionsProducesOriginal()
        {
            uint[] testPermutation = Permutation.Generate();
            uint[] testInverse = Permutation.GenerateInverse(testPermutation);
            Assert.Equal(testPermutation, Permutation.GenerateInverse(testInverse));
        }
    }
}
