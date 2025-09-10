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
        string startFen = " ";
        
        Board newBoard = new Board();
        // TEMPOARY
        Console.WriteLine("Enter a number\n1:Basic Setup\n2:Stalemate Test\n3:Random Pos");
        int userChoiceForFenString = Convert.ToInt32(Console.ReadLine());
        if (userChoiceForFenString == 1)
        {
            startFen = basicSetUp;
        }
        else if (userChoiceForFenString == 2)
        {
            startFen = testForStalemate;
        }
        else
        {
            startFen = randomPosFromOneOfMyGames;
        }
        
        FenLoader.ReadFenAndLoad(startFen, newBoard);
        
        Console.Clear();
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