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
        
        Move.moveInfo selectedMove = moves.Find(move => move.to == userMoveChoice);

        // legality check
        if (selectedMove != null)
        {
            ExecuteMove(board, selectedMove);
        }
        else
        {
            Console.WriteLine("Illegal move");
            Console.ReadKey();
        }

        char sideToMove = 'w';
        // Game.Logic.Game.CheckGameState(sideToMove, board);
    }
    
    public static void ExecuteMove(Board board, Move.moveInfo move)
    {
        int movingPiece = board.gameBoard[move.from];
        board.gameBoard[move.to] = movingPiece;
        board.gameBoard[move.from] = 0;
    }
}