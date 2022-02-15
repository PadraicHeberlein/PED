using PED.Util;
using PED.Util.Crypto;
using System;

namespace PED
{
    public class Key
    {
        private uint[] bitCypherKey;
        private uint[] blockCypherKey;
        private UintBase64 key;
        // Costructors:
        public Key()
        {
            bitCypherKey = Permutation.Generate();
            blockCypherKey = Permutation.Generate();
            key = MakeBase64KeyFromHexKeys();
        }
        public Key(string theKey)
        {
            key = new UintBase64(theKey);
            MakeHexKeysFrom64Key(); 
        }
        // Helper methods for the constructors:
        private void MakeHexKeysFrom64Key()
        {
            bitCypherKey = new uint[Permutation.SIZE];
            blockCypherKey = new uint[Permutation.SIZE];
            uint[] hexNumber = key.ToHex();

            for (int i = 0; i < Permutation.SIZE; i++)
            {
                bitCypherKey[i] = hexNumber[i];
                blockCypherKey[i] = hexNumber[i + Permutation.SIZE];
            }
        }
        private UintBase64 MakeBase64KeyFromHexKeys()
        {
            uint[] hexNumber = new uint[36];

            Array.Copy(bitCypherKey, hexNumber, bitCypherKey.Length);
            Array.Copy(blockCypherKey, 0, hexNumber, bitCypherKey.Length,
                blockCypherKey.Length);

            return new UintBase64(hexNumber);
        }
        // Get methods:
        public uint[] GetBitEncryptionKey()
        {
            return bitCypherKey;
        }
        public uint[] GetBitDecryptionKey()
        {
            return Permutation.GenerateInverse(bitCypherKey);
        }
        public uint[] GetBlockEncryptionKey()
        {
            return blockCypherKey;
        }
        public uint[] GetBlockDecryptionKey()
        {
            return Permutation.GenerateInverse(blockCypherKey);
        }
        public override string ToString()
        {
            return key.ToString();
        }
    }
}
