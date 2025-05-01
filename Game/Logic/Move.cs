namespace Game.Logic
{
    public class Move
    {
        // move values
        
        //straight movements
        private static readonly int moveUp = 8;
        private static readonly int moveDown = -8;
        private static readonly int moveLeft = -1;
        private static readonly int moveRight = 1;
        //diagonal movements
        private static readonly int moveUpLeft = 7;
        private static readonly int moveUpRight = 9;
        private static readonly int moveDownLeft = -7;
        private static readonly int moveDownRight = -9;
    }
}