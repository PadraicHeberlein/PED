using System;

namespace PED
{
    static class Graphics
    {
        const int SCREEN_WIDTH = 64;
        const int NUM_EDGES_PER_LINE = 2;

        const string LINE = "-";
        const string EDGE = "|";
        const string SPACE = " ";
        const string WAIT = EDGE + SPACE + ":" + SPACE;
        const string WELCOME = "   WELCOME TO P.E.D. : PADDY'S ENCRYPTION/DECRYPTION!";
        const string HELP = "   Enter 'h' for help.";
        const string ENCRYPT = "   Enter 'e' for encryption.";
        const string DECRYPT = "   Enter 'd' for decryption.";
        const string QUIT = "   Enter 'q' to quit.";


        // Method for printing a line all the way across the screen. -> --- ... ---
        public static void PrintLine()
        {
            string line = "";

            for (int i = 0; i < SCREEN_WIDTH; i++)
                line += LINE;

            Console.WriteLine(line);
        }
        // Method for printing an empty line to the screen. -> |   ...   |
        public static void PrintEmptyLine()
        {
            string line = "";

            for(int i = 0; i < SCREEN_WIDTH; i++)
            {
                if (i == 0 || i == SCREEN_WIDTH - 1)
                    line += EDGE;
                else
                    line += SPACE;
            }

            Console.WriteLine(line);
        }
        // Method for printing the welcome message to the screen. -> | "text" ... |
        public static void PrintTextLine(string text)
        {
            int numObjects = 3; // 2 edges + 1 text
            int numEmptySpaces = SCREEN_WIDTH - text.Length - NUM_EDGES_PER_LINE;
            int numIterations = numEmptySpaces + numObjects;
            string line = "";

            for (int i = 0; i < numIterations; i++)
            {
                if (i == 0 || i == numIterations - 1)
                    line += EDGE;
                else if (i == 1)
                    line += text;
                else
                    line += SPACE;
            }

            Console.WriteLine(line);
        }
        // Method for printing the first edge while whaiting for command.
        public static void PrintWaitForNextCommand()
        {
            Console.Write(WAIT);
        }
        // Methods for printing the intro screen :
        private static void Intro()
        {
            PrintLine();
            PrintEmptyLine();
            PrintTextLine(WELCOME);
            PrintEmptyLine();
            PrintLine();
        }
        //  With arguments : 
        public static void IntroWithArgs()
        {
            Intro();
        }
        //  Without arguments :         
        public static void IntroWithoutArgs()
        {

            Intro();
            PrintEmptyLine();
            PrintTextLine(HELP);
            PrintTextLine(ENCRYPT);
            PrintTextLine(DECRYPT);
            PrintTextLine(QUIT);
            PrintEmptyLine();
            PrintLine();
        }
    }
}
