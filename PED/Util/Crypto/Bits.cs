namespace PED.Util.Crypto
{
    public class Bits
    {
        private bool[] bits;
        // Constructors:
        public Bits()
        {
            bits = new bool[2 * ByteProcessor.BYTE_WIDTH];
        }
        public Bits(char target)
        {
            bits = new bool[2 * ByteProcessor.BYTE_WIDTH];
            SetBits(target);
        }
        // Get and set methods:
        public bool GetBit(ushort position)
        {
            return bits[position];
        }
        public void SetBit(ushort bit, ushort position)
        {
            if (bit == 0)
                bits[position] = false;
            else
                bits[position] = true;
        }
        public void SetBits(char target)
        {
            byte upper = ByteProcessor.GetUpperByte(target);
            byte lower = ByteProcessor.GetLowerByte(target);

            for (ushort i = 0; i < ByteProcessor.BYTE_WIDTH; i++)
            {
                if (ByteProcessor.BitExtractor(lower, i) == 0)
                    bits[i] = false;
                else
                    bits[i] = true;
                if (ByteProcessor.BitExtractor(upper, i) == 0)
                    bits[i + ByteProcessor.BYTE_WIDTH] = false;
                else
                    bits[i + ByteProcessor.BYTE_WIDTH] = true;
            }
        }
        // To char and string methods:
        public char ToChar()
        {
            ushort upper = 0, lower = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                if (i < ByteProcessor.BYTE_WIDTH)
                {
                    if (bits[i])
                        lower += PowerOfTwo(i);
                }
                else
                {
                    if (bits[i])
                        upper += PowerOfTwo(i);
                }
            }

            return (char)(upper + lower);
        }
        public override string ToString()
        {
            string bitString = "";

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i])
                    bitString += 1;
                else
                    bitString += 0;
            }

            return bitString;
        }
        /* May want to think about adding this
         * to a static math class...*/
        private ushort PowerOfTwo(int n)
        {
            ushort power = 1;
            for (int i = 1; i <= n; i++)
                power *= 2;

            return power;
        }
    }
}
