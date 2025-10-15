using System.Text.RegularExpressions;

namespace Game.Logic.Bot;
using System;
using System.Collections.Generic;

public class Kenith
{
    
    private const int MAX_DEPTH = 4;
    
    public static Move.moveInfo PickBestMove(Board board, char sideToMove)
    {
        char sideToPick = sideToMove;
        List<Move.moveInfo> possibleMoves = Game.GenerateAllLegalMoves(sideToPick, board);
        Move.moveInfo bestMove = null;
        int bestScore = -1;

        foreach (var move in possibleMoves)
        {
            Board clonedBoard = board.Clone();
            MakingMoves.ExecuteMove(clonedBoard, move);
            int score = Minimax(clonedBoard, MAX_DEPTH - 1, false, sideToMove);

            if (score > bestScore)
            {
                bestScore = score;
                bestMove = move;
            }
        }
        return bestMove;
    }
    
    private static int Minimax(Board board, int depth, bool maximizingPlayer, char sideToMove)
    {
        if (depth == 0)
            return EvaluateBoard(board, sideToMove);

        char currentSide = maximizingPlayer ? sideToMove : GetOpponent(sideToMove);
        List<Move.moveInfo> moves = Game.GenerateAllLegalMoves(currentSide, board);

        if (moves.Count == 0)
            return EvaluateBoard(board, sideToMove);

        int bestScore = maximizingPlayer ? int.MinValue : int.MaxValue;

        foreach (var move in moves)
        {
            Board newBoard = board.Clone();
            MakingMoves.ExecuteMove(newBoard, move);

            int score = Minimax(newBoard, depth - 1, !maximizingPlayer, sideToMove);

            if (maximizingPlayer)
                bestScore = Math.Max(bestScore, score);
            else
                bestScore = Math.Min(bestScore, score);
        }

        return bestScore;
    }

    private static int EvaluateBoard(Board board, char sideToMove)
    {
        int score = 0;

        for (int i = 0; i < 64; i++)
        {
            int piece = board.gameBoard[i];
            if (piece == 0) continue;

            int value = GetPieceValue(Math.Abs(piece)); 
            bool isWhitePiece = piece > 0;

            if ((sideToMove == 'w' && isWhitePiece) || (sideToMove == 'b' && !isWhitePiece))
                score += value;
            else
                score -= value;;
        }

        return score;
    }

    private static int GetPieceValue(int pieceType)
    {
        return pieceType switch
        {
            Pieces.pawn   => 100,
            Pieces.knight => 320,
            Pieces.bishop => 330,
            Pieces.rook   => 500,
            Pieces.queen  => 900,
            Pieces.king   => 20000,
            _ => 0
        };
    }


    private static char GetOpponent(char side)
    {
        return side == 'w' ? 'b' : 'w';
    }
}