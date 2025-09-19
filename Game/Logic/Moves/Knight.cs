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

        void GenerateLegalMoves(int[] board, int currentPos)
        {
            
            int[] directions = {-17, -15, -10, -6, 6, 10, 15, 17 };

            int currentRow = currentPos / 8;
            int currentCol = currentPos % 8;

            bool IsOpponentPiece(int piece) => isKnightWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;

            foreach (int dir in directions)
            {
                int pos = currentPos + dir;
                int piece = board[pos];

                if (board[pos] == Pieces.noPiece)
                {
                    legalMoves.Add(new moveInfo(currentPos, pos, MoveType.Normal));
                }
                else if (IsOpponentPiece(piece))
                {
                    legalMoves.Add(new moveInfo(currentPos, pos, MoveType.Capture));
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