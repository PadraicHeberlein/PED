using PED.Util;
using Xunit;

namespace TestPED
{
    public class TestMessage
    {
        [Fact]
        public void TestMessage_CheckForPadding()
        {
            Message testMessage = new Message("this is a test!");
            string message = testMessage.GetOriginalText();
            Assert.True(message[15] == '#');
        }
        [Fact]
        public void TestMessage_CheckGetOriginalMessageFromBits()
        {
            Message expectedMessage = new Message("a");
            string message = expectedMessage.GetOriginalText();
            Assert.Equal(expectedMessage.GetOriginalText(), message);
        }
    }
}