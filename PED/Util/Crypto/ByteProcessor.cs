namespace PED.Util.Crypto
{
    public static class ByteProcessor
    {
        public const int BYTE_WIDTH = 8;
        // Named constants for the bit postion in a byte
        public const ushort ZEROTH_POSITION = 0;
        public const ushort FIRST_POSITION = 1;
        public const ushort SECOND_POSITION = 2;
        public const ushort THIRD_POSITION = 3;
        public const ushort FOURTH_POSITION = 4;
        public const ushort FIFTH_POSITION = 5;
        public const ushort SIXTH_POSITION = 6;
        public const ushort SEVENTH_POSITION = 7;
        // Masks for bit extraction via & operation.
        public const byte ZEROTH_BIT_MASK = 0b00000001;
        public const byte FIRST_BIT_MASK = 0b00000010;
        public const byte SECOND_BIT_MASK = 0b00000100;
        public const byte THIRD_BIT_MASK = 0b00001000;
        public const byte FOURTH_BIT_MASK = 0b00010000;
        public const byte FIFTH_BIT_MASK = 0b00100000;
        public const byte SIXTH_BIT_MASK = 0b01000000;
        public const byte SEVENTH_BIT_MASK = 0b10000000;
        /* Working with 16-bit char type, so need to
         * extract the upper and lower bytes via & operation.*/
        public const ushort UPPER_BYTE_MASK = 0xff00;
        public const ushort LOWER_BYTE_MASK = 0x00ff;
        /* Various methods to help with extracting and manipulating
         * information(bits) from bytes.*/
        public static byte BitExtractor(byte target, ushort position)
        {         
            byte maskedByte = 0x00;
            switch (position)
            {
                case ZEROTH_POSITION:
                    maskedByte = ApplyMask(ZEROTH_BIT_MASK, target);                  
                    break;
                case FIRST_POSITION:
                    maskedByte = ApplyMask(FIRST_BIT_MASK, target);
                    break;
                case SECOND_POSITION:
                    maskedByte = ApplyMask(SECOND_BIT_MASK, target);
                    break;
                case THIRD_POSITION:
                    maskedByte = ApplyMask(THIRD_BIT_MASK, target);
                    break;
                case FOURTH_POSITION:
                    maskedByte = ApplyMask(FOURTH_BIT_MASK, target);
                    break;
                case FIFTH_POSITION:
                    maskedByte = ApplyMask(FIFTH_BIT_MASK, target);
                    break;
                case SIXTH_POSITION:
                    maskedByte = ApplyMask(SIXTH_BIT_MASK, target);
                    break;
                case SEVENTH_POSITION:
                    maskedByte = ApplyMask(SEVENTH_BIT_MASK, target);
                    break;
            }

            return ExtractBit(maskedByte, position); ;
        }
        static byte ExtractBit(byte target, ushort position)
        {
            return (byte)((int)target >> (int)position);
        }
        public static byte GetUpperByte(char symbol)
        {
            int upper = (ushort)symbol & UPPER_BYTE_MASK;
            return (byte)(upper >> BYTE_WIDTH);
        }
        public static byte GetLowerByte(char symbol)
        {
            return (byte)((ushort)symbol & LOWER_BYTE_MASK);
        }
        public static byte ApplyMask(byte mask, byte target)
        {
            return (byte)(target & mask);
        }
        /* May want to rethink the variable types here
         * and possible go with ushort or uint all the way, everywhere*/
    }
}
