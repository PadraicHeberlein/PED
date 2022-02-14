using System;
using System.IO;

namespace PED
{
    public static class Startup
    {
        // Upon startup create directory structure.
        public static void CreateDirectories()
        {
            try
            {
                Console.WriteLine("...creating directories...");
                // Get the current directory.
                Globals.path = Directory.GetCurrentDirectory();
                string dropToEncrypt = Globals.path + Globals.ENCRYPT_DIR;
                string dropToDecrypt = Globals.path + Globals.DECRYPT_DIR;
                string findDecrypted = Globals.path + Globals.DECRYPTED_DIR;
                string findEncrypted = Globals.path + Globals.ENCRYPTED_DIR;

                if (!Directory.Exists(dropToEncrypt))
                    Directory.CreateDirectory(dropToEncrypt);
                if (!Directory.Exists(dropToDecrypt))
                    Directory.CreateDirectory(dropToDecrypt);
                if (!Directory.Exists(findDecrypted))
                    Directory.CreateDirectory(findDecrypted);
                if (!Directory.Exists(findEncrypted))
                    Directory.CreateDirectory(findEncrypted);

                // Change the current directory.
                //Environment.CurrentDirectory = (target);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Startup create directories failed" +
                    $": {0}", e.ToString());
            }
        }
    }
}
