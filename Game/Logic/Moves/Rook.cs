using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Game.Logic
{
    public class Rook : Move
    {
        private bool isRookWhite;
        private List<moveInfo> legalMoves = new List<moveInfo>();
        public Rook(bool isRookWhite)
        {
            this.isRookWhite = isRookWhite;
        }

        void generateLegalMoves(int[] board, int currentPos)
        {
            legalMoves.Clear();
            int[] directions = { moveUp, moveDown, moveRight, moveLeft };

            bool IsOpponentPiece(int piece)
            {
                return isRookWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;
            }
            
            bool loop = true;
            while (loop)
            {
                foreach (int dir in directions)
                {
                    int pos = currentPos + dir;
                    int piece = board[pos];
                    if (piece == Pieces.noPiece)
                    {
                        legalMoves.Add(new moveInfo(currentPos, pos, MoveType.Normal));
                        pos += dir;
                    }
                    else
                    {
                        if (IsOpponentPiece(piece))
                        {
                            legalMoves.Add(new moveInfo(currentPos, pos, MoveType.Capture));
                        }

                        loop = false;
                    }
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