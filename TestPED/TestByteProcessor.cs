using PED.Util.Crypto;
using Xunit;

namespace TestPED
{
    public class TestByteProcessor
    {
        [Fact]
        public void TestByteProcessor_CheckBitExtractorZerothBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000001;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 0));
        }
        [Fact]
        public void TestByteProcessor_CheckBitExtractorFirstBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000001;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 1));
        }
        [Fact]
        public void TestByteProcessor_CheckBitExtractorSecondBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000001;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 2));
        }
        [Fact]
        public void TestByteProcessor_CheckBitExtractorThirdBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000001;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 3));
        }
        [Fact]
        public void TestByteProcessor_CheckBitExtractorFourthBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000000;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 4));
        }
        [Fact]
        public void TestByteProcessor_CheckBitExtractorFifthBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000000;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 5));
        }
        [Fact]
        public void TestByteProcessor_CheckBitExtractorSixthBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000000;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 6));
        }
        [Fact]
        public void TestByteProcessor_CheckBitExtractorSeventhBit()
        {
            byte testByte = 0b00001111;
            byte expected = 0b00000000;
            Assert.Equal(expected, ByteProcessor.BitExtractor(testByte, 7));
        }
    }
}
