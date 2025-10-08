using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public class Bishop : Move
    {
        private bool isBishopWhite;
        private List<moveInfo> legalMoves = new List<moveInfo>();

        public Bishop(bool isBishopWhite)
        {
            this.isBishopWhite = isBishopWhite;
        }

        public List<moveInfo> GenerateLegalMoves(int[] board, int currentPos)
        {
            legalMoves.Clear();
            bool IsOpponentPiece(int piece)
            {
                return isBishopWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;
            }

            int i = 0;

            // checks forward moves till a piece is in front and if the piece is yours it wotn let capture
            void GenerateLegalMoves(int[] board, int currentPos)
            {
                legalMoves.Clear();
                int[] directions = { moveDownRight, moveDownLeft, moveUpRight, moveUpLeft };

                foreach (int dir in directions)
                {
                    int pos = currentPos + dir;
                    
                    if (pos < 0 || pos >= 64)
                        continue;
                    int newRow = pos / 8;
                    int newCol = pos % 8;

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

            return legalMoves;
        }
    }
}
