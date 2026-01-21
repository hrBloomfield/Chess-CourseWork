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
        
        public void PrintBoard(char userSide)
        {
            if (userSide == 'w')
            {
                for (int row = 7; row >= 0; row--)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        int index = row * 8 + col;
                        Console.Write($"{gameBoard[index],3}");
                    }
                    Console.WriteLine();
                }
            }
            else if (userSide == 'b')
            {
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        int index = row * 8 + col;
                        Console.Write($"{gameBoard[index],3}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid userSide");
                MainGame.Main();
            }
        }


    }
    
}