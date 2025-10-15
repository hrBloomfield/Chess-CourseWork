using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public class Pawn : Move
    {
        private bool isPawnWhite;
        private List<moveInfo> legalMoves = new List<moveInfo>();

        public Pawn(bool isPawnWhite)
        {
            this.isPawnWhite = isPawnWhite;
        }

        public List<moveInfo> GenerateLegalMoves(int[] board, int currentPos, int enPassantTargetSquare = -1)
        {
            legalMoves.Clear();

            int direction = isPawnWhite ? moveUp : moveDown;
            int startRank = isPawnWhite ? 1 : 6;
            int promotionRank = isPawnWhite ? 7 : 0;
            int diaganalLeft = isPawnWhite ? moveUpLeft : moveDownLeft;
            int diaganalRight = isPawnWhite ? moveUpRight : moveDownRight;

            bool IsOpponentPiece(int piece) => isPawnWhite ? piece < 0 : piece > 0;

            int forwardOne = currentPos + direction;
            if (forwardOne < 0 || forwardOne >= 64) return legalMoves; // safety guard

            // Move forward one square
            if (board[forwardOne] == Pieces.noPiece)
            {
                int forwardRank = forwardOne / 8;
                if (forwardRank == promotionRank)
                    legalMoves.Add(new moveInfo(currentPos, forwardOne, MoveType.Promotion));
                else
                    legalMoves.Add(new moveInfo(currentPos, forwardOne, MoveType.Normal));
            }

            // Captures
            int captureLeft = currentPos + diaganalLeft;
            int captureRight = currentPos + diaganalRight;

            if (captureLeft >= 0 && captureLeft < 64 && IsOpponentPiece(board[captureLeft]))
            {
                legalMoves.Add(new moveInfo(currentPos, captureLeft, MoveType.Capture));
            }

            if (captureRight >= 0 && captureRight < 64 && IsOpponentPiece(board[captureRight]))
            {
                legalMoves.Add(new moveInfo(currentPos, captureRight, MoveType.Capture));
            }

            // Double move
            if ((currentPos / 8) == startRank)
            {
                int moveTwice = currentPos + direction * 2;
                if (moveTwice >= 0 && moveTwice < 64 &&
                    board[currentPos + direction] == Pieces.noPiece &&
                    board[moveTwice] == Pieces.noPiece)
                {
                    legalMoves.Add(new moveInfo(currentPos, moveTwice, MoveType.DoubleMove));
                }
            }

            // TODO: En passant
            return legalMoves;
        }
    }
}
