using System.Collections.Generic;

namespace Game.Logic
{
    public class Move
    {
        // Directions (8x8 board, 0–63)
        protected const int moveUp = 8;
        protected const int moveDown = -8;
        protected const int moveRight = 1;
        protected const int moveLeft = -1;
        protected const int moveUpRight = 9;
        protected const int moveUpLeft = 7;
        protected const int moveDownRight = -7;
        protected const int moveDownLeft = -9;

        public enum MoveType 
        {
            Normal, 
            Capture, 
            Castle, 
            //do
            EnPassant, 
            Promotion, 
            DoubleMove, 
            PromotionCapture 
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