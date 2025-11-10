using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;            
using Avalonia.Media.Imaging;    
using Avalonia.Platform;         
using UI.ViewModels;


namespace UI.Views
{
    public partial class MainWindow : Window
    {
        private Canvas _piecesCanvas;
        private MainWindowViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _piecesCanvas = this.FindControl<Canvas>("PiecesCanvas");
            _vm = new MainWindowViewModel();
            DataContext = _vm;
            this.Opened += (_, __) => DrawPiecesOnCanvas();
        }

        private void DrawPiecesOnCanvas()
        {
            _piecesCanvas.Children.Clear();

            foreach (var piece in _vm.Pieces.ToArray())
            {
                var img = new Image
                {
                    Width = 75,
                    Height = 75,
                    Stretch = Stretch.Uniform
                };
                try
                {
                    var uri = new Uri(piece.ImagePath);
                    using var stream = AssetLoader.Open(uri);
                    img.Source = new Bitmap(stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load image {piece.ImagePath}: {ex.Message}");
                    continue;
                }

                Canvas.SetLeft(img, piece.X);
                Canvas.SetTop(img, piece.Y);
                _piecesCanvas.Children.Add(img);
            }

            Console.WriteLine($"Rendered {_piecesCanvas.Children.Count} images.");
        }
    }
}