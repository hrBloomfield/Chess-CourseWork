using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public class King : Move
    {
        private bool isKingWhite;
        private List<moveInfo> legalMoves = new List<moveInfo>();

        public King(bool isKingWhite)
        {
            this.isKingWhite = isKingWhite;
        }

        public List<moveInfo> GenerateLegalMoves(int[] board, int currentPos)
        {
            legalMoves.Clear();
            int[] directions =
                { moveDownRight, moveDownLeft, moveUpRight, moveUpLeft, moveUp, moveDown, moveRight, moveLeft };

            bool IsOpponentPiece(int piece)
            {
                return isKingWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;
            }

            //castling 
            if (currentPos + Move.moveLeft == Pieces.noPiece && currentPos + (Move.moveLeft * 2) == Pieces.noPiece &&
                currentPos + (Move.moveLeft * 3) == Pieces.noPiece && currentPos + (Move.moveLeft * 4) == Pieces.rook)
            {
                if (currentPos == (isKingWhite ? 61 : 5))
                {
                    legalMoves.Add(new moveInfo(currentPos, (Move.moveLeft * 3), MoveType.Castle));
                }
            }
            else if (currentPos + Move.moveRight == Pieces.noPiece &&
                     currentPos + (Move.moveRight * 2) == Pieces.noPiece &&
                     currentPos + (Move.moveRight * 3) == Pieces.rook)
            {
                if (currentPos == (isKingWhite ? 61 : 5))
                {
                    legalMoves.Add(new moveInfo(currentPos, (Move.moveRight * 2), MoveType.Castle));
                }
            }

            // normal moves
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
                }
            }

            return legalMoves;
        }
    }
}