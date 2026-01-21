using Game.Logic;
using Game.Logic.Bot;
using System;

public class MainGame
{
    public static char userSide = ' ';

    public static void Main()
    {

        string basicSetUp = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        string startFen = " ";
        
        
        
        Board newBoard = new Board();
        
        startFen = basicSetUp;
        FenLoader.ReadFenAndLoad(startFen, newBoard);
        
        Console.WriteLine("pick a side w or b: ");
        userSide = Console.ReadKey().KeyChar;

        while (true)
        {
            Console.Clear();
            newBoard.PrintBoard(userSide);
            
            MakingMoves.HandleMoves(newBoard);
            
            // Move.moveInfo bestMove = Kenith.PickBestMove(newBoard,'b');
            // MakingMoves.ExecuteMove(newBoard, bestMove);
            //
            // Console.Clear();
            // newBoard.PrintBoard();
            // Console.WriteLine("Bot moved. Press any key for next turn...");
            // Console.ReadKey();
        }
    }
}