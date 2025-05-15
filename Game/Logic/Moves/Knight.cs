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
            int direction = isKnightWhite ? moveUp : moveDown;
            bool IsOpponentPiece(int piece)
            {
                return isKnightWhite ? piece < 0 : piece > 0;
            }
            
            int twoUpOneRightTurn = currentPos + direction + direction + moveRight;
            
            // always 8 possible mvoes that need checking
            for (int i = 0; i < 8; i++)
            {
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