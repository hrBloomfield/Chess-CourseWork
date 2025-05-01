using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public static class FenLoader
    {
        // read the fen pattern and load it into a new initalized board
        public static void readFENandLoad(string fen, Board board)
        {
            // create a link between each piece and each fen code
            var pieceTypeForFEN = new Dictionary<char, int>()
            {
                ['k'] = Piece.king, ['q'] = Piece.queen, ['b'] = Piece.bishop,
                ['r'] = Piece.rook, ['n'] = Piece.knight, ['p'] = Piece.pawn
            };
            // splits the fen pattern into seperate parts at the spaces allowing to read diffrent parts
            string fenBoard = fen.Split(' ')[0];
            // sets the starting file to 0 and the rank to the top rank starting at the top left corner
            int file = 0;
            int rank = 7;
            // goes through each digit in the fen pattern 
            foreach (char currentFenDigit in fenBoard)
            {
                // resets the file to the left and goes down one rank
                if (currentFenDigit == '/')
                {
                    file = 0;
                    rank--;
                }
                // checks if the fen current digit is a numerical digit if it is it skips that amount of squares 
                else if (char.IsDigit(currentFenDigit))
                {
                    file += (int)char.GetNumericValue(currentFenDigit);
                }
                // else assumes it is a char
                else
                {
                    // creating variables for what needs to be checked
                    int pieceColour;
                    int piece;
                    
                    // if it is upper it is a white piece else it is a black piece
                    if (char.IsUpper(currentFenDigit)) { pieceColour = Piece.white; } else { pieceColour = Piece.black; }
                    // sets piece to lower so it is readable 
                    piece = pieceTypeForFEN[char.ToLower(currentFenDigit)];
                    
                    // this finds the file and rank the piece needs to be placed at and gives it an index
                    int squareIndex = rank * 8 + file;
                    // sets that index to the piece and piece colour we found earlier
                    board.gameBoard[squareIndex] = piece | pieceColour;
                    // goes to the next file to repeat for the next item in the fen pattern
                    file++;
                }
            }
        }
    }
}