using Avalonia.Controls;
using System;
using System.Data;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        private string _currentInput = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Content.ToString() ?? "";

                if (buttonText == "C")
                {
                    _currentInput = "";
                }
                else if (buttonText == "=")
                {
                    try
                    {
                        _currentInput = new DataTable().Compute(_currentInput, null)?.ToString() ?? "0";
                    }
                    catch
                    {
                        _currentInput = "Błąd";
                    }
                }
                else
                {
                    _currentInput += buttonText;
                }

                this.FindControl<TextBlock>("Display").Text = _currentInput;
            }
        }
    }
}