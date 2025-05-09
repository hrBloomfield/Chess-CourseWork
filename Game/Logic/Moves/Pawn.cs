using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

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

        void main(int[] board, int currentPos)
        {
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
            int captureLeft = currentPos + diaganalLeft;
            int captureRight = currentPos + diaganalRight;

            // the reason i havent used else ifs is because a chess piece can have multiple legal moves as an
            // option so i dont want it displaying only the first legal move it finds
            if (board[forwardOne] == 0)
            {
                // normal move
                legalMoves.Add(new moveInfo(currentPos, forwardOne, MoveType.Normal));

                if (board[forwardOne] == promotionRank && board[forwardOne] == 0)
                {
                    // promotion move
                    legalMoves.Add(new moveInfo(currentPos, forwardOne, MoveType.Promotion));
                }
            }
            if (board[captureLeft] != 0 && board[captureRight] != 0)
            {
                if (IsOpponentPiece(board[captureLeft]) == true)
                {
                    legalMoves.Add(new moveInfo(currentPos, captureLeft, MoveType.Capture));
                }
                if (IsOpponentPiece(board[captureRight]) == true)
                {
                    legalMoves.Add(new moveInfo(currentPos, captureRight, MoveType.Capture));
                }
            }
            
        }
        
        public enum MoveType
        {
            Normal,
            Capture,
            Promotion,
            PromotionCapture,
            EnPassant,
            PawnDoubleMove
        }

        public class moveInfo(int currentPos, int targetPos, MoveType moveType)
        {
            public int from = currentPos;
            public int to = targetPos;
            public MoveType moveType = moveType;
        }
        
    }
}