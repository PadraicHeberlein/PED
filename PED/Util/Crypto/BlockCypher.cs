using System;
using System.Collections.Generic;
using System.Text;

namespace PED.Util.Crypto
{
    public static class BlockCypher
    {
        const int PERM_SIZE = 32;
        public static Message Encrypt(Key key, Message message)
        {
            uint[] blockEncryptionKey = MakePermutationFromKey(key);
            return message;
        }
        public static Message Decrypt(Key key, Message message)
        {
            uint[] blockDecryptionKey = MakePermutationFromKey(key, true);
            return message;
        }
        // Make a permutation of numbers 0 - 31 from bit and block keys.
        static uint[] MakePermutationFromKey(Key key, bool inverse = false)
        {
            uint bitPermutationSize = PERM_SIZE / 2;
            uint[] permutation = new uint[PERM_SIZE], key1, key2;

            if (inverse)
            {
                key1 = key.GetBlockDecryptionKey();
                key2 = key.GetBitDecryptionKey();
            }
            else
            {
                key1 = key.GetBlockEncryptionKey();
                key2 = key.GetBitEncryptionKey();
            }

            for (int i = 0; i < PERM_SIZE / bitPermutationSize; i++)
            {
                permutation[2 * i] = key1[i];
                permutation[2 * i + 1] = key2[i] + bitPermutationSize;
            }

            return permutation;
        }
    }
}
