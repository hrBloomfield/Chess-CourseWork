using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Game.Logic
{
    public class Knight : Move
    {
        private bool isKnightWhite;
        private List<moveInfo> legalMoves = new List<moveInfo>();
        
        public Knight(bool isKnightWhite)
        {
            this.isKnightWhite = isKnightWhite;
        }

        void generateLegalMoves(int[] board, int currentPos, int enPassantTargetSquare)
        {
            
            int[] knightOffSets = { 
                -17, -15, -10, -6, 6, 10, 15, 17 
            };

            int currentRow = currentPos / 8;
            int currentCol = currentPos % 8;

            bool IsOpponentPiece(int piece) => isKnightWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;

            foreach (int offset in knightOffSets)
            {
                int targetPos = currentPos + offset;
                

                if (board[targetPos] == 0)
                {
                    legalMoves.Add(new moveInfo(currentPos, targetPos, MoveType.Normal));
                }
                else if (IsOpponentPiece(board[targetPos]))
                {
                    legalMoves.Add(new moveInfo(currentPos, targetPos, MoveType.Capture));
                }
            }
        }

        
        public enum MoveType
        {
            Normal,
            Capture
        }
        public class moveInfo
        {
            public int from;
            public int to;
            public MoveType moveType;

            public moveInfo(int from, int to, MoveType moveType)
            {
                this.from = from;
                this.to = to;
                this.moveType = moveType;
            }
        }
        
    }
}