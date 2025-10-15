namespace Game.Logic;

public class Game
{
    public static string CheckGameState(char sideToMove, Board board)
    {
        string winner = "null";
        var moves = GenerateAllLegalMoves(sideToMove, board);
        if (moves.Count == 0)
        {
            if (IsKingInCheck(sideToMove, board))
            {
                winner = sideToMove == 'w' ? "black" : "white";
            }
            else
            {
                winner = "draw by stalemate";
            }
        }
        else if (CheckFiftyMoveRule())
        {
            winner = "draw by fifty move rule";
        }
        else if (CheckThreeMoveRule())
        {
            winner = "draw by three move rule";
        }
        return winner;
    }

    public static List<Move.moveInfo> GenerateAllLegalMoves(char sideToMove, Board board)
    {
        var allMoves = new List<Move.moveInfo>();
        
        for (int i = 0; i < board.gameBoard.Length; i++)
        {
            int piece = board.gameBoard[i];
            if (piece == Pieces.noPiece)
            {
                continue;
            }

            bool isWhitePiece = piece > 0;

            if ((sideToMove == 'w' && !isWhitePiece) || (sideToMove == 'b' && isWhitePiece))
            {
                continue;
            }
            
            List<Move.moveInfo> pieceMoves = MovePieces.GetLegalMoves(board.gameBoard, i);
            allMoves.AddRange(pieceMoves);
        }
        return allMoves;
    }

    public static bool IsKingInCheck(char sideToMove, Board board)
    {
        bool kingInCheck = false;
        // if ()
        // {}
        return kingInCheck;
    }

    public static bool CheckFiftyMoveRule()
    {
        return false;
    }

    public static bool CheckThreeMoveRule()
    {
        return false;
    }
}