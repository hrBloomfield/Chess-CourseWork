using Game.Logic;
using Game.Logic.Bot;
using System;


namespace Game.Logic
{
    public class MakingMoves : MainGame
    {
        public static char sideToMove = 'w';
        private static int enPassantSquare = -1;
        private static bool kingHasCastled = false;

        public static void HandleMoves(Board board)
        {
            Console.WriteLine($"It is {(sideToMove == 'w' ? "White" : "Black")}'s turn.");

            string result = Game.CheckGameState(sideToMove, board);
            if (result != "null")
            {
                Console.WriteLine($"Game over: {result}");
                Console.ReadKey();
                return;
            }

            // Determine if bot should move
            bool isBotTurn = false;
            if (userGameMode == "1") // PvB
                isBotTurn = (userSide == 'w' && sideToMove == 'b') || (userSide == 'b' && sideToMove == 'w');
            else if (userGameMode == "3") // BvB
                isBotTurn = true;

            if (isBotTurn)
            {
                Move.moveInfo botMove = Kenith.FindBestMove(sideToMove, board);
                if (botMove != null)
                {
                    Console.WriteLine($"Kenith moves from {botMove.from} to {botMove.to}");

                    if (botMove.moveType == Move.MoveType.Promotion ||
                        botMove.moveType == Move.MoveType.PromotionCapture)
                    {
                        ExecuteMove(board, botMove);
                        int colour = sideToMove == 'w' ? Pieces.white : Pieces.black;
                        board.gameBoard[botMove.to] = Pieces.queen * colour;
                    }
                    else
                    {
                        ExecuteMove(board, botMove);
                    }

                    sideToMove = sideToMove == 'w' ? 'b' : 'w';
                    // Console.WriteLine("Press any key to continue...");
                    // Console.ReadKey();
                }

                return;
            }

            // Human player's turn
            Console.WriteLine("Piece Coordinate to move: ");
            if (!int.TryParse(Console.ReadLine(), out int userPieceSelection) || userPieceSelection < 0 ||
                userPieceSelection >= 64)
            {
                Console.WriteLine("Invalid square index.");
                Console.ReadKey();
                return;
            }

            int usersPiece = board.gameBoard[userPieceSelection];
            if (usersPiece == Pieces.noPiece)
            {
                Console.WriteLine("No piece on that square.");
                Console.ReadKey();
                return;
            }

            if ((sideToMove == 'w' && !PieceHelpers.IsWhite(usersPiece)) ||
                (sideToMove == 'b' && !PieceHelpers.IsBlack(usersPiece)))
            {
                Console.WriteLine("Wrong colour. Try again.");
                Console.ReadKey();
                return;
            }

            List<Move.moveInfo> moves = Game.GetLegalMovesForPiece(sideToMove, board, userPieceSelection);

            Console.WriteLine("Legal moves:");
            if (moves.Count > 0)
            {
                foreach (var move in moves)
                {
                    Console.WriteLine($"From {move.from} > {move.to} ({move.moveType})");
                }

                Console.WriteLine("Move to where?");
                int userMoveChoice = Convert.ToInt32(Console.ReadLine());

                Move.moveInfo selectedMove = moves.Find(move => move.to == userMoveChoice);

                if (selectedMove != null)
                {
                    if (selectedMove.moveType == Move.MoveType.Promotion ||
                        selectedMove.moveType == Move.MoveType.PromotionCapture)
                        PromotePawn(board, selectedMove);
                    else
                        ExecuteMove(board, selectedMove);

                    sideToMove = sideToMove == 'w' ? 'b' : 'w';
                    board.PrintBoard(userSide);
                }
                else
                {
                    Console.WriteLine("Illegal move");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No legal moves.");
                Console.ReadKey();
                return;
            }
        }

        public static void ExecuteMove(Board board, Move.moveInfo move)
        {
            int movingPiece = board.gameBoard[move.from];

            // Clear old en passant marker
            if (enPassantSquare != -1)
            {
                board.gameBoard[enPassantSquare] = Pieces.noPiece;
                enPassantSquare = -1;
            }

            // ---------------- CASTLING ----------------
            if (move.moveType == Move.MoveType.Castle && kingHasCastled == false)
            {
                bool kingSide = move.to > move.from;

                // move king
                board.gameBoard[move.to] = movingPiece;
                board.gameBoard[move.from] = Pieces.noPiece;
                kingHasCastled = true;

                if (kingSide)
                {
                    int rookFrom = move.from + 3;
                    int rookTo = move.from + 1;

                    board.gameBoard[rookTo] = board.gameBoard[rookFrom];
                    board.gameBoard[rookFrom] = Pieces.noPiece;
                }
                else
                {
                    int rookFrom = move.from - 4;
                    int rookTo = move.from - 1;

                    board.gameBoard[rookTo] = board.gameBoard[rookFrom];
                    board.gameBoard[rookFrom] = Pieces.noPiece;
                }

                return;
            }
            // ------------------------------------------

            // En passant capture
            if (move.moveType == Move.MoveType.EnPassant)
            {
                int capturedPawnSquare = PieceHelpers.IsWhite(movingPiece) ? move.to - 8 : move.to + 8;
                board.gameBoard[capturedPawnSquare] = Pieces.noPiece;
            }

            // Normal move
            board.gameBoard[move.to] = movingPiece;
            board.gameBoard[move.from] = Pieces.noPiece;

            // Double pawn move create en passant marker
            if (move.moveType == Move.MoveType.DoubleMove)
            {
                enPassantSquare = PieceHelpers.IsWhite(movingPiece) ? move.to - 8 : move.to + 8;

                board.gameBoard[enPassantSquare] = PieceHelpers.IsWhite(movingPiece)
                    ? Pieces.enPassantMarker
                    : Pieces.black * Pieces.enPassantMarker;
            }
        }

        public static void PromotePawn(Board board, Move.moveInfo move)
        {
            string userChoiceForPromotion;

            ExecuteMove(board, move);
            Console.WriteLine("Promoting Pawn Options \n1: Queen\n2: Rook\n3: Bishop\n4: Knight\nEnter your choice:");
            userChoiceForPromotion = Console.ReadLine();

            switch (userChoiceForPromotion)
            {
                case "1":
                case "queen":
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.queen : Pieces.black * Pieces.queen;
                    break;
                case "2":
                case "rook":
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.rook : Pieces.black * Pieces.rook;
                    break;
                case "3":
                case "bishop":
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.bishop : Pieces.black * Pieces.bishop;
                    break;
                case "4":
                case "knight":
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.knight : Pieces.black * Pieces.knight;
                    break;
                default:
                    Console.WriteLine("Invalid choice, promoting to Queen");
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.queen : Pieces.black * Pieces.queen;
                    break;
            }
        }
    }
}