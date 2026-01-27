using System;

namespace Game.Logic
{
    public class Game
    {
        public static string CheckGameState(char sideToMove, Board board)
        {
            string winner = "null";

            bool kingInCheck = IsKingInCheck(sideToMove, board);
            var moves = GenerateAllLegalMoves(sideToMove, board);

            if (moves.Count == 0)
            {
                if (kingInCheck)
                {
                    winner = sideToMove == 'w' ? "black wins" : "white wins";
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
                if (piece == Pieces.noPiece) continue;

                bool isWhitePiece = piece > 0;
                if ((sideToMove == 'w' && !isWhitePiece) || (sideToMove == 'b' && isWhitePiece))
                    continue;
                
                List<Move.moveInfo> legalMoves = GetLegalMovesForPiece(sideToMove, board, i);
                allMoves.AddRange(legalMoves);
            }

            return allMoves;
        }

        public static bool IsKingInCheck(char sideToMove, Board board)
        {
            int kingPiece = (sideToMove == 'w') ? Pieces.white * Pieces.king : Pieces.black * Pieces.king;
            int kingPosition = Array.IndexOf(board.gameBoard, kingPiece);

            if (kingPosition == -1) return true; // king missing

            char opponentSide = (sideToMove == 'w') ? 'b' : 'w';

            // Scan all opponent pieces
            for (int i = 0; i < board.gameBoard.Length; i++)
            {
                int piece = board.gameBoard[i];
                if (piece == Pieces.noPiece) continue;

                bool isWhitePiece = piece > 0;
                if ((opponentSide == 'w' && !isWhitePiece) || (opponentSide == 'b' && isWhitePiece))
                    continue;

                var pseudoMoves = MovePieces.GetLegalMoves(board.gameBoard, i);
                foreach (var move in pseudoMoves)
                {
                    if (move.to == kingPosition)
                        return true;
                }
            }

            return false;
        }

        public static bool WillKingBeInCheck(char sideToMove, Board board, Move.moveInfo move)
        {
            Board tempBoard = board.Clone();
            tempBoard.gameBoard[move.to] = tempBoard.gameBoard[move.from];
            tempBoard.gameBoard[move.from] = Pieces.noPiece;

            return IsKingInCheck(sideToMove, tempBoard);
        }

        public static List<Move.moveInfo> GetLegalMovesForPiece(char sideToMove, Board board, int pieceIndex)
        {
            List<Move.moveInfo> moves = MovePieces.GetLegalMoves(board.gameBoard, pieceIndex);
            List<Move.moveInfo> legalMoves = new List<Move.moveInfo>();

            foreach (var move in moves)
            {
                if (!WillKingBeInCheck(sideToMove, board, move))
                    legalMoves.Add(move);
            }
            
            return legalMoves;
        }
        
        public static bool CheckFiftyMoveRule() => false;
        public static bool CheckThreeMoveRule() => false;
    }
}
