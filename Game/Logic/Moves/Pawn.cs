using System;
using System.Collections.Generic;

namespace Game.Logic
{
    public class Pawn : Move
    {
        private bool isPawnWhite;
        public Pawn(bool isPawnWhite)
        {
            this.isPawnWhite = isPawnWhite;
        }
    }
}