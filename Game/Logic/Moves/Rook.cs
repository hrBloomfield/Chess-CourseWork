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
            int direction = isRookWhite ? moveUp : moveDown;
            int sideDirection = isRookWhite ? moveRight : moveLeft;
            int startRank = isRookWhite ? 1 : 6;
            
            bool noPiecesInWay = true;
            int forwardOne = currentPos + direction;
            int backwardsOne = currentPos - direction;
            int sideOne = currentPos + moveRight;
            int otherSideOne = currentPos + moveLeft;
            
            bool IsOpponentPiece(int piece)
            {
                return isRookWhite ? piece < 0 : piece > 0;
            }
            int i = 0;
            
            // checks forward moves till a piece is in front and if the piece is yours it wotn let capture
            while (noPiecesInWay == true)
            {
                if (board[forwardOne + i] == Pieces.noPiece)
                {
                    legalMoves.Add(new moveInfo(currentPos, forwardOne + i, MoveType.Normal));
                    i += direction;
                }
                else
                {
                    if (IsOpponentPiece(board[sideOne + i]) == true)
                    {
                        legalMoves.Add(new moveInfo(currentPos, forwardOne + i, MoveType.Capture));
                    }
                    noPiecesInWay = false;
                    i = 0;
                }
                
            }
            
            noPiecesInWay = true;
            
            // checks for side moves with the same taking mechanism
            while (noPiecesInWay == true)
            {
                if (board[sideOne + i] == Pieces.noPiece)
                {
                    legalMoves.Add(new moveInfo(currentPos, sideOne + i, MoveType.Normal));
                    i += sideDirection;
                }
                else
                {
                    if (IsOpponentPiece(board[sideOne + i]) == true)
                    {
                        legalMoves.Add(new moveInfo(currentPos, sideOne + i, MoveType.Capture));
                    }
                    noPiecesInWay = false;
                    i = 0;
                }
            }
            noPiecesInWay = true;
            
            // checks for side moves with the same taking mechanism
            // due to me having no way of knowiung if the piece is black or white
            // movign right and left dont apply as they dont have any form of direction
            // so i have gone with neutral variable names such as side on and otheer side one
            while (noPiecesInWay == true)
            {
                if (board[otherSideOne + i] == Pieces.noPiece)
                {
                    legalMoves.Add(new moveInfo(currentPos, otherSideOne + i, MoveType.Normal));
                    i += sideDirection;
                }
                else
                {
                    if (IsOpponentPiece(board[otherSideOne + i]) == true)
                    {
                        legalMoves.Add(new moveInfo(currentPos, otherSideOne + i, MoveType.Capture));
                    }
                    noPiecesInWay = false;
                    i = 0;
                }
            }
            noPiecesInWay = true;
            
            // checks for moves backwards
            while (noPiecesInWay == true)
            {
                if (board[backwardsOne + i] == Pieces.noPiece)
                {
                    legalMoves.Add(new moveInfo(currentPos, backwardsOne + i, MoveType.Normal));
                    i -= direction;
                }
                else
                {
                    if (IsOpponentPiece(board[backwardsOne + i]) == true)
                    {
                        legalMoves.Add(new moveInfo(currentPos, backwardsOne + i, MoveType.Capture));
                    }
                    noPiecesInWay = false;
                    i = 0;
                }
            }
        }
        
        public enum MoveType
        {
            Normal,
            Capture
        }
        public class moveInfo(int currentPos, int targetPos, MoveType moveType)
        {
            public int from = currentPos;
            public int to = targetPos;
            public MoveType moveType = moveType;
        }
        
    }
}