using System;
using System.Collections.Generic;
using System.Text;

namespace PED
{
    public static class Valid
    {
        // String for helping user with cmd arguments.
        const string argHelp = "-e for encryption,\n" +
                                "-d for decription,\n" +
                                "-h for help.";
        // Named constants for entries in flag array.
        const int FLAG_MARKER = 0;
        const int FLAG = 1;
        const int FLAG_LENGTH = 2;
        // Methods to validate commands.
        public static bool Command(char command)
        {
            if (command.Equals(Run.CONTINUE) ||
                command.Equals(Run.HELP) ||
                command.Equals(Run.ENCRYPT) ||
                command.Equals(Run.DECRYPT) ||
                command.Equals(Run.QUIT))
                return true;

            return false;
        }
        // Method to validate the flag argument.
        public static char Flag(string flag)
        {
            if (!(flag[FLAG_MARKER] == '-'))
                throw new Exception("Not a valid flag argument!\n" +
                                    "Flags need to be preceded by '-'!\n" +
                                    argHelp);
            if (flag.Length != FLAG_LENGTH)
                throw new Exception("Must include valid flag in cmd argument!\n" +
                                    argHelp);

            return flag[FLAG];
        }
    }
}
