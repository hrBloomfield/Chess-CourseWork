namespace Game.Logic
{
    public class Board
    {
        public int[] gameBoard;
        public Board()
        {
            gameBoard = new int[64];
        }
        
        public Board Clone()
        {
            var copy = new Board();
            copy.gameBoard = (int[])this.gameBoard.Clone();
            return copy;
        }
    }
    
}