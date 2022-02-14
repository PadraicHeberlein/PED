using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PED
{
    public static class FileIO
    {
        // Get text from file for the given feature.
        public static string GetTextFor(Feature feature)
        {
            try
            { 
                string directory = feature == Feature.Encryption ? 
                    Globals.path + Globals.ENCRYPT_DIR :
                    Globals.path + Globals.DECRYPT_DIR;

                string file = GetFileFrom(directory);
                string fromFile = System.IO.File
                    .ReadAllText(file);

                string text = feature == Feature.Encryption ?
                    fromFile : fromFile.Trim('\n').Trim('\r');

                return text;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.ToString());
            }
        }
        // Constructt path or the given file and directory/
        public static string MakePathFor(Feature feature)
        {
            string directory = feature == Feature.Encryption ?
                            Globals.path + Globals.ENCRYPTED_DIR :
                            Globals.path + Globals.DECRYPTED_DIR;

            string file = feature == Feature.Encryption ?
                        @"\encryptedFile.txt" :
                        @"\decryptedFile.txt";

            return directory + file;
        }
        // Get file name for the given directroy.
        static string? GetFileFrom(string directory) 
        {
            string file = null;
            // Get all files in that directory.
            string[] filePaths = Directory.GetFiles(directory);
            // There should only be one file in that directory!
            if (filePaths.Length > 1)
                throw new Exception(Globals.TOO_MANY_FILES);
            else
                file = filePaths[0];

            return file;
        }
    }
}
