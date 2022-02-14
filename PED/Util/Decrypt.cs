using System;
using System.IO;
using System.Threading.Tasks;

namespace PED.Util
{
    public static class Decrypt
    {
        private static readonly Feature DECRYPTION = Feature.Decryption;
        // TODO:
        public static async Task WithArgs(string[] args)
        {
            throw new NotImplementedException();
        }

        public static async Task WithoutArgs(string theKey)
        {
            try
            {
                // Get text from encrypted file.
                string encryptedText = FileIO.GetTextFor(DECRYPTION);
                /* Instatiate a message with encryption set to false, so
                 * the Message() constructor doesn't pad the text, 
                 * as it has already been padded.*/
                Message message = new Message(encryptedText, false);
                // Instantiate encryption key from the passed key string.
                Key key = new Key(theKey);
                // Get decryption key by finding the inverse permutation.
                uint[] decryptionKey = key.GetBitDecryptionKey();
                // Decrypt the message with the above key.
                message.PermutateBits(decryptionKey, false);
                // Create new file for the decrypted text.
                using StreamWriter decryptedFile =
                    new StreamWriter(FileIO.MakePathFor(DECRYPTION));
                // Write to file and close.
                await decryptedFile.WriteLineAsync(
                    message.GetOriginalText().Trim(Message.PAD)
                    );
                decryptedFile.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.ToString());
            }
        }
    }
}
