using System.Collections.Generic;

namespace PED.Util.Crypto
{
    public static class BlockCypher
    {
        const int PERM_SIZE = 32;
        public static Message Encrypt(Key key, Message message)
        {
            uint[] blockEncryptionKey = MakePermutationFromKey(key);
            return PermutateMessage(blockEncryptionKey, message, Feature.Encryption);
        }
        public static Message Decrypt(Key key, Message message)
        {
            uint[] blockDecryptionKey = MakePermutationFromKey(key, true);
            return PermutateMessage(blockDecryptionKey, message, Feature.Decryption);
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

            for (int i = 0; i < bitPermutationSize; i++)
            {
                permutation[2 * i] = key1[i];
                permutation[2 * i + 1] = key2[i] + bitPermutationSize;
            }

            return permutation;
        }
        // Method to convert message to array of 32 strings. 
        static string[] MessageToBlocks(Message message, bool decrypt)
        {
            int numBlocks = Permutation.SIZE * 2;
            int blockSize = message.size / numBlocks;
            List<string> blocks = new List<string>();

            for (int i = 0; i < numBlocks; i++)
            {
                string currentBlock = "";
                for (int j = 0; j < blockSize; j++)
                {
                    int currentIndex = i * blockSize + j;
                    currentBlock += message.GetCharAt(currentIndex, decrypt);
                }
                blocks.Add(currentBlock);
            }

            return blocks.ToArray();
        }
        // Method for permutating blocks.
        static Message PermutateMessage
            (uint[] permutation, Message message, Feature feature)
        {
            bool encrypt = feature == Feature.Encryption ?
                false : true;

            string[] blocks = MessageToBlocks(message, encrypt);
            int numBlocks = blocks.Length;
            string blockString = "";

            for (int i = 0; i < numBlocks; i++)
                blockString += blocks[permutation[i]];
                
            return new Message(blockString, encrypt);
        }
    }
}
