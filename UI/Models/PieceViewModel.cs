using System;
using Game.Logic;

public class PieceViewModel
{
    private string PieceCodeToImage(int code)
    {
        return code switch
        {
            1 => "PawnW.png",
            -1 => "PawnB.png",
            5 => "RookW.png",
            -5 => "RookB.png",
            2 => "KnightW.png",
            -2 => "KnightB.png",
            3 => "BishopW.png",
            -3 => "BishopB.png",
            4 => "QueenW.png",
            -4 => "QueenB.png",
            6 => "KingW.png",
            -6 => "KingB.png",
            0 => null,
        };
    }
}