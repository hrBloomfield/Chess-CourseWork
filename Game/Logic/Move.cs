namespace Game.Logic
{
    public class Move
    {
        // move values
        
        
        //straight movements
        protected static readonly int moveUp = 8;
        protected static readonly int moveDown = -8;
        protected static readonly int moveLeft = -1;
        protected static readonly int moveRight = 1;

        //diagonal movements
        protected static readonly int moveUpLeft = 7;
        protected static readonly int moveUpRight = 9;
        protected static readonly int moveDownLeft = -7;
        protected static readonly int moveDownRight = -9;
    }
}