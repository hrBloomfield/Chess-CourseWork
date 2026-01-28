using Game.Logic.Bot;
using System;


namespace Game.Logic
{
    public class MainGame
    {
        public static char userSide = ' ';
        public static string userGameMode;

        public static void Main()
        {
            string basicSetUp = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            // string basicSetUp = "4k3/pp3ppp/8/4q3/3P4/8/PP3PPP/RNB1KBNR w KQkq - 0 1";
            string startFen = " ";

            Board newBoard = new Board();

            startFen = basicSetUp;
            FenLoader.ReadFenAndLoad(startFen, newBoard);

            Console.WriteLine("Pick game mode:\n1: Player vs Bot\n2: Player vs Player\n3: Bot vs Bot");
            userGameMode = Console.ReadLine();

            Console.WriteLine("Pick a side w or b: ");
            userSide = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Ask if user wants to use a timer
            Console.WriteLine("Use timer? (y/n): ");
            char useTimerChoice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            bool useTimer = (useTimerChoice == 'y' || useTimerChoice == 'Y');
            int timePerSide = 600; // Default 10 minutes

            if (useTimer)
            {
                Console.WriteLine("Enter time per side in minutes (default 10): ");
                string timeInput = Console.ReadLine();
                
                if (int.TryParse(timeInput, out int minutes) && minutes > 0)
                {
                    timePerSide = minutes * 60;
                }
                else
                {
                    Console.WriteLine("Invalid input, using default 10 minutes");
                }
            }

            // Initialize the timer in MakingMoves
            MakingMoves.InitializeTimer(useTimer, timePerSide);

            while (true)
            {
                Console.Clear();
                newBoard.PrintBoard(userSide);
                MakingMoves.HandleMoves(newBoard);
            }
        }
    }
}