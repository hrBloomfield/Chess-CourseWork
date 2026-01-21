    using Game.Logic;
    using System;

    public class MakingMoves : MainGame
    {
        private static char sideToMove = 'w';
        private static int enPassantSquare = -1;

        public static void HandleMoves(Board board)
        { 
            Console.WriteLine($"It is {(sideToMove == 'w' ? "White" : "Black")}'s turn.");
            
            string result = Game.Logic.Game.CheckGameState(sideToMove, board);
            if (result != "null")
            {
                Console.WriteLine($"Game over: {result}");
                Console.ReadKey();
                return; 
            }


            Console.WriteLine("Piece Coordinate to move: ");
            if (!int.TryParse(Console.ReadLine(), out int userPieceSelection) || userPieceSelection < 0 || userPieceSelection >= 64)
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
            
            if ((sideToMove == 'w' && !PieceHelpers.IsWhite(usersPiece)) || (sideToMove == 'b' && !PieceHelpers.IsBlack(usersPiece)))
            {
                Console.WriteLine("Wrong color. Try again.");
                return;
            }
            
            List<Move.moveInfo> moves = Game.Logic.Game.GetLegalMovesForPiece(sideToMove, board, userPieceSelection);

            Console.WriteLine("Legal moves:");
            int userMoveChoice = 0;
            if (moves.Count > 0)
            {
                foreach (var move in moves)
                {
                    Console.WriteLine($"From {move.from} > {move.to} ({move.moveType})");
                }

                Console.WriteLine("Move to where?");
                userMoveChoice = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("No legal moves.");
            }
            
            Move.moveInfo selectedMove = moves.Find(move => move.to == userMoveChoice);

            if (selectedMove != null)
            {
                if (selectedMove.moveType == Move.MoveType.Promotion || selectedMove.moveType == Move.MoveType.PromotionCapture)
                {
                    PromotePawn(board, selectedMove);
                }
                else
                {
                    ExecuteMove(board, selectedMove);
                }

                sideToMove = sideToMove == 'w' ? 'b' : 'w';
                board.PrintBoard(userSide);
            }
            else
            {
                Console.WriteLine("Illegal move");
                Console.ReadKey();
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
            if (move.moveType == Move.MoveType.Castle)
            {
                bool kingSide = move.to > move.from;

                // move king
                board.gameBoard[move.to] = movingPiece;
                board.gameBoard[move.from] = Pieces.noPiece;

                if (kingSide)
                {
                    int rookFrom = move.from + 3;
                    int rookTo   = move.from + 1;

                    board.gameBoard[rookTo] = board.gameBoard[rookFrom];
                    board.gameBoard[rookFrom] = Pieces.noPiece;
                }
                else
                {
                    int rookFrom = move.from - 4;
                    int rookTo   = move.from - 1;

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

                board.gameBoard[enPassantSquare] = PieceHelpers.IsWhite(movingPiece) ? Pieces.enPassantMarker : Pieces.black * Pieces.enPassantMarker;
            }
        }


        
        public static void PromotePawn(Board board, Move.moveInfo move)
        {
            string userChoiceForPromotion;
            
            ExecuteMove(board, move);
            Console.WriteLine("Promoting Pawn Options \n1: Queen\n1: Rook\n1: Bishop\n1: Knight\nEnter your choice:");
            userChoiceForPromotion = Console.ReadLine();

            switch (userChoiceForPromotion)
            {
                case "queen":
                    board.gameBoard[move.to] = Pieces.noPiece;
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.queen : Pieces.black * Pieces.queen;
                    break;
                case "rook":
                    board.gameBoard[move.to] = Pieces.noPiece;
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.rook : Pieces.black * Pieces.rook;
                    break;
                case "bishop":
                    board.gameBoard[move.to] = Pieces.noPiece;
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.bishop : Pieces.black * Pieces.bishop;
                    break;
                case "knight":
                    board.gameBoard[move.to] = Pieces.noPiece;
                    board.gameBoard[move.to] = sideToMove == 'w' ? Pieces.knight : Pieces.black * Pieces.knight;
                    break;
                default:
                    Console.WriteLine("Illegal choice");
                    break;
            }
            
        }
    }