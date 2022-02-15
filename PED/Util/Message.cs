using PED.Util.Crypto;

namespace PED.Util
{
    public class Message
    {
        // Public members:
        public const char PAD = '#';
        public int size;
        // Private members:
        private string message;
        private Bits[] encryptedBits;
        private Bits[] originalBits;      
        // Constructor:
        public Message(string theMessage, bool encrypt = true)
        {
            message = theMessage;
            if (encrypt)
                size = PadMessage();
            else
                size = theMessage.Length;
            originalBits = new Bits[size];
            encryptedBits = new Bits[size];

            for (int i = 0; i < size; i++)
            {
                char nextChar = message[i];
                Bits nextBits = new Bits();
                nextBits.SetBits(nextChar);
                if (!encrypt)
                    encryptedBits[i] = nextBits;
                else
                    originalBits[i] = nextBits;
            }
        }
        // Need to pad the text so that 32 divides it's length.
        int PadMessage()
        {
            int divisor = Permutation.SIZE * 2;
            int remainder = message.Length % divisor;
            int theRest = divisor - remainder;
            if (theRest != 0)
            {
                int newLength = message.Length + theRest;
                message = message.PadRight(newLength, PAD);
            }

            return message.Length;
        }
        /* Permutates the bits of message based on a given
         * 16-bit permutation called the 'key'. The 'encrypt'
         * argument dierects where the permutated bits should go. */
        public void PermutateBits(uint[] key, bool encrypt = true)
        {
            for (int i = 0; i < size; i++)
            {
                Bits current;
                Bits toPermutate = new Bits();

                if (encrypt)
                    current = originalBits[i];
                else
                    current = encryptedBits[i];

                for (ushort j = 0; j < Permutation.SIZE; j++)
                {
                    ushort nextBit = 0;
                    if (current.GetBit(j))
                        nextBit = 1;

                    toPermutate.SetBit(nextBit, (ushort)key[j]);
                }

                if (encrypt)
                    encryptedBits[i] = toPermutate;
                else
                    originalBits[i] = toPermutate;
            }
        }
        // Public get methods:
        public string GetEncryptedText()
        {
            string text = "";

            for (int i = 0; i < size; i++)
                text += encryptedBits[i].ToChar();

            return text;
        }
        public string GetOriginalText()
        {
            string text = "";

            for (int i = 0; i < size; i++)
                text += originalBits[i].ToChar();

            return text;
        }
        public string GetOriginalMessage()
        {
            return message;
        }
        public char GetCharAt(int index)
        {
            return originalBits[index].ToChar();
        }
        // To bit string method:
        public string ToBitString(bool original = true)
        {
            string bitString = "";

            for (int i = 0; i < size; i++)
            {
                if (original)
                    bitString += originalBits[i].ToString();
                else
                    bitString += encryptedBits[i].ToString();
            }

            return bitString;
        }
    }
}
