using Game.Logic;
using System;

public class MakingMoves : MainGame
{
    public static void HandleMoves(Board board)
    {
        Console.WriteLine("Piece Coordinate to move: ");
        int userPieceSelection = Convert.ToInt32(Console.ReadLine());
        int usersPiece = board.gameBoard[userPieceSelection];

        List<Move.moveInfo> moves = MovePieces.GetLegalMoves(board.gameBoard, userPieceSelection);

        Console.WriteLine("Legal moves:");
        foreach (var move in moves)
        {
            Console.WriteLine($"From {move.from} --> {move.to} ({move.moveType})");
        }

        Console.WriteLine("Move to where?");
        int userMoveChoice = Convert.ToInt32(Console.ReadLine());

        // legality check
        if (moves.Exists(move => move.to == userMoveChoice))
        {
            board.gameBoard[userMoveChoice] = usersPiece;
            board.gameBoard[userPieceSelection] = 0;
        }
        else
        {
            Console.WriteLine("Illegal move");
            Console.ReadKey();
        }

        char sideToMove = 'w';
        // Game.Logic.Game.CheckGameState(sideToMove, board);
    }
}