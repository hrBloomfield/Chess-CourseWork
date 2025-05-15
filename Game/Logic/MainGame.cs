using Game.Logic;
using System;

public class MainGame
{
    public static void Main()
    {
        // possible setups in FEN  for testing
        string basicSetUp = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        string testForStalemate = "3k4/8/8/8/2pp4/8/8/4K3 w KQkq - 0 1 ";
        string randomPosFromOneOfMyGames = "Q4qk1/6pp/5p2/p7/3Bn3/4P2P/PP3PP1/R5KR w - - 3 29";
        
        Board newBoard = new Board();
        string startFEN = basicSetUp;
        
        FenLoader.readFENandLoad(randomPosFromOneOfMyGames, newBoard);
        
        Console.Clear();
        // TEMPOARY
        for (int rank = 7; rank >= 0; rank--)
        {
            for (int file = 0; file < 8; file++)
            {
                int squareIndex = rank * 8 + file;
                Console.Write($"{newBoard.gameBoard[squareIndex],2} ");
            }
            Console.WriteLine();
        }
    }
}