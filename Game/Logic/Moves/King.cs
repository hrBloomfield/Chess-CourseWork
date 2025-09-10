namespace Game.Logic;

public class King : Move
{
    private bool isKingWhite;
    private List<moveInfo> legalMoves = new List<moveInfo>();
    public King(bool isKingWhite)
    {
            this.isKingWhite = isKingWhite;
    }

    void generateLegalMoves(int[] board, int currentPos)
    {
        legalMoves.Clear();
        int[] directions = {moveDownRight, moveDownLeft, moveUpRight, moveUpLeft, moveUp, moveDown, moveRight, moveLeft };
        
        bool IsOpponentPiece(int piece)
        {
            return isKingWhite ? piece < Pieces.noPiece : piece > Pieces.noPiece;
        }
        
        
        foreach (int dir in directions)
        {
            int pos = currentPos + dir;
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
    }
        
    public enum MoveType
    {
        Normal,
        Capture
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