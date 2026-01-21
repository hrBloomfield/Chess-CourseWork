namespace UI.Models
{
    public class PieceViewModel
    {
        public string Type { get; set; }    
        public string Colour { get; set; }   
        public int Row { get; set; }        
        public int Column { get; set; }    
        
        public double X => Column * 75;
        public double Y => Row * 75; 
        public string ImagePath => $"avares://UI/Assets/{Type}{(Colour == "White" ? "B" : "W")}.png";
    }
}