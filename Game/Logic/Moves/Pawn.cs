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

            bool IsOpponentPiece(int piece)
            {
                return isPawnWhite ? piece < 0 : piece > 0;
            }
            
            int forwardOne = currentPos + direction;
            int forwardOneRow = forwardOne / 8;
            int captureLeft = currentPos + diaganalLeft;
            int captureRight = currentPos + diaganalRight;


            // the reason i havent used else ifs is because a chess piece can have multiple legal moves as an
            // option so i dont want it displaying only the first legal move it finds
            if (board[forwardOne] == Pieces.noPiece)
            {
                // normal move
                legalMoves.Add(new moveInfo(currentPos, forwardOne, MoveType.Normal));

                if (board[forwardOneRow] == promotionRank && board[forwardOne] == Pieces.noPiece)
                {
                    // promotion move
                    legalMoves.Add(new moveInfo(currentPos, forwardOne, MoveType.Promotion));
                }
            }

            // capture
            if (board[captureLeft] != Pieces.noPiece || board[captureRight] != Pieces.noPiece)
            {
                if (IsOpponentPiece(board[captureLeft]) == true)
                {
                    legalMoves.Add(new moveInfo(currentPos, captureLeft, MoveType.Capture));
                    if (board[forwardOne] == promotionRank)
                    {
                        // capture promotion
                        legalMoves.Add(new moveInfo(currentPos, captureLeft, MoveType.PromotionCapture));
                    }
                }

                if (IsOpponentPiece(board[captureRight]) == true)
                {
                    legalMoves.Add(new moveInfo(currentPos, captureRight, MoveType.Capture));
                    if (board[forwardOne] == promotionRank)
                    {
                        // capture promotion
                        legalMoves.Add(new moveInfo(currentPos, captureRight, MoveType.PromotionCapture));
                    }
                }
            }

            int moveTwice = isPawnWhite ? currentPos + direction * 2 : currentPos - direction * 2;
            // double move
            if (board[currentPos] == startRank && board[forwardOne + forwardOne] == Pieces.noPiece)
            {
                legalMoves.Add(new moveInfo(currentPos, moveTwice, MoveType.DoubleMove));
            }
            // en passant
            return legalMoves;
            
        }
    }
}
