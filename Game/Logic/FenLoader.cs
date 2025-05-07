using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public static class FenLoader
    {
        public static void readFENandLoad(string fen, Board board)
        {
            var pieceTypeForFEN = new Dictionary<char, int>()
            {
                ['k'] = Piece.king, ['q'] = Piece.queen, ['b'] = Piece.bishop,
                ['r'] = Piece.rook, ['n'] = Piece.knight, ['p'] = Piece.pawn
            };

            string fenBoard = fen.Split(' ')[0];

            int file = 0;
            int rank = 7;

            foreach (char currentFenDigit in fenBoard)
            {

                if (currentFenDigit == '/')
                {
                    file = Piece.noPiece;
                    rank--;
                }
                else if (char.IsDigit(currentFenDigit))
                {
                    file += (int)char.GetNumericValue(currentFenDigit);
                }
                else
                {

                    int pieceColour;
                    int piece;
                    pieceColour = char.IsUpper(currentFenDigit) ? Piece.white : Piece.black;
                    piece = pieceTypeForFEN[char.ToLower(currentFenDigit)];
                    
                    int squareIndex = rank * 8 + file;
                    board.gameBoard[squareIndex] = piece * pieceColour;

                    file++;
                }
            }
        }
    }
}