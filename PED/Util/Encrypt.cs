using PED.Util.Crypto;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PED.Util
{
    public static class Encrypt
    {
        private static readonly Feature ENCRYPTION = Feature.Encryption;
        // TODO:
        public static async Task<string> WithArgs(string[] args)
        {
            throw new NotImplementedException();
        }
        public static async Task<string> WithoutArgs()
        {
            try
            {
                // Get the information that needs to be encry
                string messageText = FileIO.GetTextFor(ENCRYPTION);
                /* Instatiate a message with encryption set to true, so
                 * the Message() constructor pads the text. */
                Message message = new Message(messageText);
                // Generate random key for permutations to be used.
                Key key = new Key();
                // Encrypt the message with the above key.
                message.PermutateBits(key.GetBitEncryptionKey());
                message = BlockCypher.Encrypt(key, message);
                // Create new file for the encrypted text.
                using StreamWriter encryptedFile =
                    new StreamWriter(FileIO.MakePathFor(ENCRYPTION));
                // Write to file and close.
                await encryptedFile.WriteLineAsync(message.GetEncryptedText());
                encryptedFile.Close();
                // TODO: Delete original file.
                // Return the generated key to the user.
                return key.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.ToString());
            }
        }
    }
}
