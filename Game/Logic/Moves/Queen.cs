using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public class Queen : Move
    {

        private bool isQueenWhite;
        private List<moveInfo> legalMoves = new List<moveInfo>();

        public Queen(bool isQueenWhite)
        {
            this.isQueenWhite = isQueenWhite;
        }

        public List<moveInfo> GenerateLegalMoves(int[] board, int currentPos)
        {
            legalMoves.Clear();
            int[] directions = { moveDownRight, moveDownLeft, moveUpRight, moveUpLeft, moveUp, moveDown, moveRight, moveLeft };

            bool IsOpponentPiece(int piece)
            {
                return isQueenWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;
            }

            bool loop = true;
            while (loop)
            {
                foreach (int dir in directions)
                {
                    int pos = currentPos + dir;
                    
                    if (pos < 0 || pos >= 64)
                        continue;
                    int newRow = pos / 8;
                    int newCol = pos % 8;
                    
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
