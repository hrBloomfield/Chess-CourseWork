using System.Collections.ObjectModel;
using Game.Logic;
using UI.Models;
using System;

namespace UI.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<PieceViewModel> Pieces { get; } = new();

        public MainWindowViewModel()
        {
            string startingFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            LoadFromFen(startingFen);
            Console.WriteLine($"Loaded {Pieces.Count} pieces from VM.");
        }

        private void LoadFromFen(string fen)
        {
            var board = new Board();
            FenLoader.ReadFenAndLoad(fen, board);
            Pieces.Clear();

            for (int i = 0; i < 64; i++)
            {
                int value = board.gameBoard[i];
                if (value == 0) continue;
                
                var (type, colour) = GetPieceInfo(value);
                int row = i / 8;
                int col = i % 8;
                Pieces.Add(new PieceViewModel{ Type = type, Colour = colour, Row = row, Column = col });
            }
        }

        private (string Type, string colour) GetPieceInfo(int value)
        {
            string colour = value > 0 ? "White" : "Black";
            int abs = System.Math.Abs(value);

            string type = abs switch
            {
                Game.Logic.Pieces.pawn => "Pawn",
                Game.Logic.Pieces.knight => "Knight",
                Game.Logic.Pieces.bishop => "Bishop",
                Game.Logic.Pieces.rook => "Rook",
                Game.Logic.Pieces.queen => "Queen",
                Game.Logic.Pieces.king => "King",
                _ => "Unknown"
            };

            return (type, colour);
        }
    }
}