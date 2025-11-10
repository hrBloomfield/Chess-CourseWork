namespace UI.Models
{
    public class PieceViewModel
    {
        public string Type { get; set; }    // "Pawn", "Rook", ...
        public string Color { get; set; }   // "White" or "Black"
        public int Row { get; set; }        // 0 = top row (rank 8)
        public int Column { get; set; }     // 0 = file a
        
        public double X => Column * 75.0;
        public double Y => Row * 75.0; 
        public string ImagePath => $"avares://UI/Assets/{Type}{(Color == "White" ? "B" : "W")}.png";
    }
}