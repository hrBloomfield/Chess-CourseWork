using System.Collections;

namespace Game.Logic.Bot;

public class KenithsPossibleMoves
{
    private List<Move.moveInfo> moves = new();
    
    public void Add(Move.moveInfo move)
    {
        moves.Add(move);
    }
    
}
