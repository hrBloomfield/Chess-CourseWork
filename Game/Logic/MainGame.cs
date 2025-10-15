using Game.Logic;
using Game.Logic.Bot;
using System;

public class MainGame
{
    public static void Main()
    {
        // possible setups in FEN  for testing
        string basicSetUp = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        string testForStalemate = "3k4/8/8/8/2pp4/8/8/4K3 w KQkq - 0 1 ";
        string randomPosFromOneOfMyGames = "r1bqk2r/pppp1pp1/2n2n2/1B2p2p/1b2PB2/3P1N2/PPP1KPPP/RN1Q3R b kq - 1 6";
        string startFen = " ";

        bool isWhiteMove;
        
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

        while (true)
        {
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
            MakingMoves.HandleMoves(newBoard);
            
            Move.moveInfo bestMove = Kenith.PickBestMove(newBoard,'b');
            MakingMoves.ExecuteMove(newBoard, bestMove);
        }
    }
}