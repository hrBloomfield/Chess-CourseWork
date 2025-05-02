using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public class Pawn : Move
    {
        
        // constructor(isWhite)
        //     this.isWhite = isWhite
        //
        //     function GetLegalMoves(currentPos, board, enPassantTargetSquare)
        // legalMoves = empty list
        // direction = isWhite ? +8 : -8
        // startRank = isWhite ? 1 : 6
        // promotionRank = isWhite ? 7 : 0
        //
        // forwardOne = currentPos + direction
        //
        // // Forward one square
        // if IsOnBoard(forwardOne) and board[forwardOne] is empty
        // if Rank(forwardOne) == promotionRank
        //     legalMoves.add(promotionMove(forwardOne))
        //     else
        // legalMoves.add(forwardOne)
        //
        //     // Forward two squares from starting position
        //     forwardTwo = currentPos + 2 * direction
        //         if Rank(currentPos) == startRank and board[forwardTwo] is empty
        //     legalMoves.add(forwardTwo)
        //
        // // Diagonal captures
        // captureOffsets = isWhite ? [+7, +9] : [-7, -9]
        // for offset in captureOffsets
        //     target = currentPos + offset
        //         if IsOnBoard(target) and IsOpponentPiece(board[target])
        //     if Rank(target) == promotionRank
        //     legalMoves.add(promotionMove(target))
        //     else
        // legalMoves.add(target)
        //
        // // En passant capture
        // for offset in captureOffsets
        //     sideTarget = currentPos + offset
        //         if sideTarget == enPassantTargetSquare
        //     legalMoves.add(enPassantCapture(sideTarget))
        //
        //     return legalMoves
        //
        //     function IsOnBoard(index)
        //     return index in 0..63
        //
        // function Rank(pos)
        //     return pos / 8
        //
        // function IsOpponentPiece(piece)
        //     return isWhite ? piece < 0 : piece > 0
        //
        // function promotionMove(square)
        //     return specialMove(square, type="promotion") // To be handled by game engine
        //
        // function enPassantCapture(square)
        //     return specialMove(square, type="enPassant") // To be handled by game engine
    }
}