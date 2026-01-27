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
            // string basicSetUp = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            string basicSetUp = "4k3/pp3ppp/8/4q3/3P4/8/PP3PPP/RNB1KBNR w KQkq - 0 1";
            string startFen = " ";



            Board newBoard = new Board();

            startFen = basicSetUp;
            FenLoader.ReadFenAndLoad(startFen, newBoard);

            Console.WriteLine("Pick game mode:\n1: Player vs Bot\n2: Player vs Player\n3: Bot vs Bot");
            userGameMode = Console.ReadLine();


            Console.WriteLine("pick a side w or b: ");
            userSide = Console.ReadKey().KeyChar;

            while (true)
            {
                Console.Clear();
                newBoard.PrintBoard(userSide);
                MakingMoves.HandleMoves(newBoard);
            }
        }
    }
}