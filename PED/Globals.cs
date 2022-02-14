namespace PED
{
    public class Globals
    {
        public static readonly string ENCRYPT_DIR = 
            @"\DropFilesToEncryptHere";
        public static readonly string DECRYPT_DIR = 
            @"\DropFilesToDecryptHere";
        public static readonly string DECRYPTED_DIR =
            @"\FindDecryptedFilesHere";
        public static readonly string ENCRYPTED_DIR =
            @"\FindEncryptedFilesHere";

        public static readonly string TOO_MANY_FILES =
            "There are too many files in that directory!";
        public static readonly string SOMETHING_WRONG =
            "Something went wrong : ";

        public static string path;
    }
}
