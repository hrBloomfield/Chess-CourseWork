using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Game.Logic
{
    public class Bishop  : Move
    {
        private bool isBishopWhite;
        private List<moveInfo> legalMoves = new List<moveInfo>();
        
        public Bishop(bool isBishopWhite)
        {
            this.isBishopWhite = isBishopWhite;
        }

        void generateLegalMoves(int[] board, int currentPos, int enPassantTargetSquare)
        {

            bool IsOpponentPiece(int piece)
            {
                return isBishopWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;
            }

            int i = 0;

            // checks forward moves till a piece is in front and if the piece is yours it wotn let capture
            void GenerateLegalMoves(int[] board, int currentPos)
            {
                legalMoves.Clear();
                int[] directions = { moveDownRight, moveDownLeft, moveUpRight, moveUpLeft};

                foreach (int dir in directions)
                {
                    int pos = currentPos + dir;

                    bool loop = true;
                    while (loop)
                    {
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