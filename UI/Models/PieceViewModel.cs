using System;
using Game.Logic;

public class PieceViewModel
{
    private string PieceCodeToImage(int code)
    {
        // Example mapping
        return code switch
        {
            9 => "PawnW.png",
            17 => "PawnB.png",
            13 => "RookW.png",
            21 => "RookB.png",
            10 => "KnightW.png",
            18 => "KnightB.png",
            11 => "BishopW.png",
            19 => "BishopB.png",
            12 => "QueenW.png",
            22 => "QueenB.png",
            14 => "KingW.png",
            29 => "KingB.png",
            0 => null,
        };
    }
}