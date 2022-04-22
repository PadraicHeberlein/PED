using Information;

namespace PED.Util.Crypto
{
    public class Bits
    {
        private bool[] bits;
        // Constructors:
        public Bits()
        {
            bits = new bool[2 * Globals.BYTE_WIDTH];
        }
        public Bits(char target)
        {
            bits = new bool[2 * Globals.BYTE_WIDTH];
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
            byte upper = Processing.GetUpperByte(target);
            byte lower = Processing.GetLowerByte(target);

            for (ushort i = 0; i < Globals.BYTE_WIDTH; i++)
            {
                if (Processing.BitExtractor(lower, i) == Bit.ZERO)
                    bits[i] = false;
                else
                    bits[i] = true;
                if (Processing.BitExtractor(upper, i) == Bit.ZERO)
                    bits[i + Globals.BYTE_WIDTH] = false;
                else
                    bits[i + Globals.BYTE_WIDTH] = true;
            }
        }
        // To char and string methods:
        public char ToChar()
        {
            ushort upper = 0, lower = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                if (i < Globals.BYTE_WIDTH)
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
