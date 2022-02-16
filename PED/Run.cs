using System;
using System.IO;
using System.Threading.Tasks;

namespace PED
{
    public static class Run
    {
        // Named command constants.
        public const char CONTINUE = 'c';
        public const char HELP = 'h';
        public const char ENCRYPT = 'e';
        public const char DECRYPT = 'd';
        public const char QUIT = 'q';
        // Named string constants.
        const string INVALID_CMD = "Command is invalid!";
        const string NEXT = "What would you like to do?";
        const string YOUR_KEY = "Here is your encryption key : ";
        const string GOOD_BYE = "Goodbye, and don't forget to write down your key!";
        const string ENTER_KEY = "Please enter your encryption key : ";
        const string DECRYPTION_COMPLETE = "Decryption complete!";
        // Run the program with agruments from the command line (cmd).
        public static async Task WithArgs(string[] args)
        {
            char flag = 'c';
            // Check to see if flag argument is valid.
            try 
            {
                flag = Valid.Flag(args[0]);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            // Switch based on flag argument.
            switch(flag)
            {
                case ENCRYPT:
                    string encryptionKey = await Util.Encrypt.WithArgs(args);
                    Console.WriteLine($"Your encryption key is : {encryptionKey}");
                    break;
                case DECRYPT:
                    await Util.Decrypt.WithArgs(args);
                    break;
                case HELP:
                    Util.Help.PrintFile();
                    break;
            }
            // Program will exit here.
        }
        // Run the program without arguments from the command line (cmd).
        public static async Task WithoutArgs()
        {
            Graphics.IntroWithoutArgs();
            char command = 'c';
            string informUser = "";
            // Run time loop, will quit once command is 'q'.
            while (command != QUIT)
            {
                Graphics.PrintTextLine(NEXT);
                command = GetNextCommand();
                // Check to see if command is valid.
                while (!Valid.Command(command))
                {
                    Graphics.PrintTextLine(INVALID_CMD);
                    command = GetNextCommand();
                }             
                // Switch based on command value.
                switch(command)
                {
                    case HELP:
                        Util.Help.PrintFile();
                        break;
                    case ENCRYPT:
                        // Encrypt.WithoutArgs returns the encryption key.
                        string yourKey = await Util.Encrypt.WithoutArgs();
                        informUser = YOUR_KEY + yourKey;
                        break;
                    case DECRYPT:
                        // Prompt user for ecryption key.
                        Graphics.PrintTextLine(ENTER_KEY);
                        Graphics.PrintWaitForNextCommand();
                        string encrytionString = Console.ReadLine();
                        // Try to decrypt with key.
                        await Util.Decrypt.WithoutArgs(encrytionString);
                        informUser = DECRYPTION_COMPLETE;
                        break;
                }
                // Print completed message and reset incase of quit.
                Graphics.PrintTextLine(informUser);
                informUser = GOOD_BYE;
            }
            // Print last graphics line and exit...
            Graphics.PrintLine();
        }
        // Helper method to get command from the user.
        private static char GetNextCommand()
        {
            Graphics.PrintWaitForNextCommand();
            char command = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return command;
        }
    }
}
