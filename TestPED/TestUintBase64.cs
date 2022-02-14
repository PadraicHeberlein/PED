using PED.Util.Crypto;
using Xunit;

namespace TestPED
{
    public class TestUintBase64
    {
        [Fact]
        public void TestConstructor_WithHexNumber()
        {
            uint[] testHexNumber = GetTestHex();
            UintBase64 test64 = new UintBase64(testHexNumber);

            bool first = (test64.number[0] == 63);
            bool second = (test64.number[1] == 63);
            bool third = (test64.number[2] == 63);
            bool fourth = (test64.number[3] == 63);

            Assert.True(first && second && third && fourth);
        }
        [Fact]
        public void TestToHex_CheckForCorrectValue()
        {
            uint[] testHexNumber = GetTestHex();
            UintBase64 test64 = new UintBase64(testHexNumber);

            Assert.Equal(testHexNumber, test64.ToHex());
        }
        uint[] GetTestHex()
        {
            uint[] testHexNumber = new uint[36];
            testHexNumber[0] = 0xf;
            testHexNumber[1] = 0xf;
            testHexNumber[2] = 0xf;
            testHexNumber[3] = 0xf;
            testHexNumber[4] = 0xf;
            testHexNumber[5] = 0xf;

            return testHexNumber;
        }
    }
}
