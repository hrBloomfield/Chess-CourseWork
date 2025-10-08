namespace Game.Logic.Bot;

public class Kenith
{
    public static int PickBestMove(Board board)
    {
        int bestMove = 0;
        Game.GenerateAllLegalMoves('b', board);
        List<Move.moveInfo> moves = new List<Move.moveInfo>();
        
        foreach (var moveInfo in moves)
        {
            if (moveInfo.moveType == Move.MoveType.Capture)
            {
                
            }
        }
        
        return bestMove;
    }
}