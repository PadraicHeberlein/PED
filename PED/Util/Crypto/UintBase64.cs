using System;

namespace PED.Util.Crypto
{
    public class UintBase64
    {
        public const int NUM_BASE64_DIGITS = 24;
        public const int NUM_HEX_DIGITS = 36;
        private const int NUM_BITS_IN_BASE64_PART = 6;
        private const int NUM_BITS_IN_HEX_PART = 4;
        // Base 64 masks:
        private const int LOWER_64_MASK = 0b000000111111;
        private const int UPPER_64_MASK = 0b111111000000;
        // Hex masks:
        private const int LOWER_HEX_MASK = 0b000000001111;
        private const int MID_HEX_MASK = 0b000011110000;
        private const int UPPER_HEX_MASK = 0b111100000000;
        // Partial base64 indices:
        private const int LOWER_64 = 0;
        private const int UPPER_64 = 1;
        // Partial hex indices:
        private const int LOWER_HEX = 0;
        private const int MID_HEX = 1;
        private const int UPPER_HEX = 2;
        /* For every three digits in hex, there
         * are two digits in base 64 */
        private const int NUM_HEX_DIGITS_PER_BASE64 = 3;
        private const int NUM_BASE64_DIGITS_PER_HEX = 2;
        // array to hold numbers 0 - 63;
        public uint[] number;
        // Constructors:
        public UintBase64(uint[] hexNumber)
        {
            number = HexToBase64(hexNumber);
        }
        public UintBase64(string numberString)
        {
            number = new uint[NUM_BASE64_DIGITS];

            for (int i = 0; i < numberString.Length; i++)
            {
                char nextChar = numberString[i];
                number[i] = CharToInt(nextChar);
            }
        }
        // Method used in constuctor to convert hex number to base64.
        uint[] HexToBase64(uint[] hexNumber)
        {
            int numIterations = NUM_BASE64_DIGITS / NUM_BASE64_DIGITS_PER_HEX;
            uint[] base64Number = new uint[NUM_BASE64_DIGITS];

            for (int i = 0; i < numIterations; i++)
            {
                uint[] partialHex = new uint[NUM_HEX_DIGITS_PER_BASE64];

                Array.Copy(hexNumber, i * NUM_HEX_DIGITS_PER_BASE64,
                            partialHex, 0, NUM_HEX_DIGITS_PER_BASE64);

                uint partialNumber = PartialHexToPartialNumber(partialHex);
                uint[] partialBase64 = PartialNumberToPartialBase64(partialNumber);

                Array.Copy(partialBase64, 0, base64Number,
                            i * NUM_BASE64_DIGITS_PER_HEX, NUM_BASE64_DIGITS_PER_HEX);
            }

            return base64Number;
        }
        // Helper method for HexToBase64.
        uint PartialHexToPartialNumber(uint[] number)
        {
            uint result = 0;

            for (uint i = 0; i < NUM_HEX_DIGITS_PER_BASE64; i++)
                result += number[i] * Power(0x10, i);

            return result;
        }
        // Helper method for HexToBase64.
        uint[] PartialNumberToPartialBase64(uint number)
        {
            uint[] partialBase64 = new uint[NUM_BASE64_DIGITS_PER_HEX];

            uint lower = (uint)((int)number & LOWER_64_MASK);
            uint upper = (uint)((int)number & UPPER_64_MASK);

            partialBase64[LOWER_64] = lower;
            partialBase64[UPPER_64] = (upper >> NUM_BITS_IN_BASE64_PART);

            return partialBase64;
        }
        // Public method for converting to hex
        public uint[] ToHex()
        {
            int numIterations = NUM_BASE64_DIGITS / NUM_HEX_DIGITS_PER_BASE64;
            uint[] hexNumber = new uint[NUM_HEX_DIGITS];

            for (int i = 0; i < numIterations; i++)
            {
                uint[] partialBase64 = new uint[NUM_BASE64_DIGITS_PER_HEX];

                Array.Copy(number, i * NUM_BASE64_DIGITS_PER_HEX,
                            partialBase64, 0, NUM_BASE64_DIGITS_PER_HEX);

                uint partialNumber = PartialBase64ToPartialNumber(partialBase64);
                uint[] partialHex = PartialNumberToPartialHex(partialNumber);

                Array.Copy(partialHex, 0, hexNumber,
                            i * NUM_HEX_DIGITS_PER_BASE64, NUM_HEX_DIGITS_PER_BASE64);
            }

            return hexNumber;
        }
        // Helper method for Base64ToHex.
        uint PartialBase64ToPartialNumber(uint[] number)
        {
            uint result = 0;

            for (uint i = 0; i < NUM_BASE64_DIGITS_PER_HEX; i++)
                result += number[i] * Power(0b1000000, i);

            return result;
        }
        // Helper method for Base64ToHex.
        uint[] PartialNumberToPartialHex(uint number)
        {
            uint[] partialHex = new uint[NUM_HEX_DIGITS_PER_BASE64];

            uint lower = (uint)((int)number & LOWER_HEX_MASK);
            uint mid = (uint)((int)number & MID_HEX_MASK);
            uint upper = (uint)((int)number & UPPER_HEX_MASK);

            partialHex[LOWER_HEX] = lower;
            partialHex[MID_HEX] = (mid >> NUM_BITS_IN_HEX_PART);
            partialHex[UPPER_HEX] = (upper >> (2 * NUM_BITS_IN_HEX_PART));

            return partialHex;
        }
        /* Maybe think about making a static math class?
         * ... see ByteProcessor.cs...*/
        uint Power(uint theBase, uint exponent)
        {
            uint result = 1;

            for (int i = 1; i <= exponent; i++)
                result *= theBase;

            return result;
        }
        /* Methods for converting an int from 
         * 0-63 to a char and vice versa. */
        uint CharToInt(char number)
        {
            return number switch
            {
                'A' => 0,
                'B' => 1,
                'C' => 2,
                'D' => 3,
                'E' => 4,
                'F' => 5,
                'G' => 6,
                'H' => 7,
                'I' => 8,
                'J' => 9,
                'K' => 10,
                'L' => 11,
                'M' => 12,
                'N' => 13,
                'O' => 14,
                'P' => 15,
                'Q' => 16,
                'R' => 17,
                'S' => 18,
                'T' => 19,
                'U' => 20,
                'V' => 21,
                'W' => 22,
                'X' => 23,
                'Y' => 24,
                'Z' => 25,
                'a' => 26,
                'b' => 27,
                'c' => 28,
                'd' => 29,
                'e' => 30,
                'f' => 31,
                'g' => 32,
                'h' => 33,
                'i' => 34,
                'j' => 35,
                'k' => 36,
                'l' => 37,
                'm' => 38,
                'n' => 39,
                'o' => 40,
                'p' => 41,
                'q' => 42,
                'r' => 43,
                's' => 44,
                't' => 45,
                'u' => 46,
                'v' => 47,
                'w' => 48,
                'x' => 49,
                'y' => 50,
                'z' => 51,
                '0' => 52,
                '1' => 53,
                '2' => 54,
                '3' => 55,
                '4' => 56,
                '5' => 57,
                '6' => 58,
                '7' => 59,
                '8' => 60,
                '9' => 61,
                '+' => 62,
                '/' => 63,
                _ => throw new Exception("Invalid input for base 64 to char!"),
            };
        }
        char IntToChar(uint number)
        {
            return number switch
            {
                0 => 'A',
                1 => 'B',
                2 => 'C',
                3 => 'D',
                4 => 'E',
                5 => 'F',
                6 => 'G',
                7 => 'H',
                8 => 'I',
                9 => 'J',
                10 => 'K',
                11 => 'L',
                12 => 'M',
                13 => 'N',
                14 => 'O',
                15 => 'P',
                16 => 'Q',
                17 => 'R',
                18 => 'S',
                19 => 'T',
                20 => 'U',
                21 => 'V',
                22 => 'W',
                23 => 'X',
                24 => 'Y',
                25 => 'Z',
                26 => 'a',
                27 => 'b',
                28 => 'c',
                29 => 'd',
                30 => 'e',
                31 => 'f',
                32 => 'g',
                33 => 'h',
                34 => 'i',
                35 => 'j',
                36 => 'k',
                37 => 'l',
                38 => 'm',
                39 => 'n',
                40 => 'o',
                41 => 'p',
                42 => 'q',
                43 => 'r',
                44 => 's',
                45 => 't',
                46 => 'u',
                47 => 'v',
                48 => 'w',
                49 => 'x',
                50 => 'y',
                51 => 'z',
                52 => '0',
                53 => '1',
                54 => '2',
                55 => '3',
                56 => '4',
                57 => '5',
                58 => '6',
                59 => '7',
                60 => '8',
                61 => '9',
                62 => '+',
                63 => '/',
                _ => throw new Exception("Invalid input for base 64 to char!"),
            };
        }
        // Public ToString override
        public override string ToString()
        {
            string numberString = "";

            // The last 2 digists will always be 'A'
            for (int i = 0; i < NUM_BASE64_DIGITS - 2; i++)
                numberString += IntToChar(number[i]);

            return numberString;
        }
    }
}
