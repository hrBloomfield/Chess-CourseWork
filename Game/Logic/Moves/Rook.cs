using System;
using System.Collections.Generic;

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

        public List<moveInfo> GenerateLegalMoves(int[] board, int currentPos)
        {
            legalMoves.Clear();
            int[] directions = { moveUp, moveDown, moveRight, moveLeft };

            bool IsOpponentPiece(int piece)
            {
                return isRookWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;
            }


            foreach (int dir in directions)
            {
                int pos = currentPos + dir;
                
                if (pos < 0 || pos >= 64)
                    continue;
                int newRow = pos / 8;
                int newCol = pos % 8;
                bool loop = true;
                while (loop == true)
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

            return legalMoves;
        }
    }
}