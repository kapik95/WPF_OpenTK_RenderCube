using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_OpenTK_RenderCube.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _selectedMode;
        private bool _isDrawing;
        private readonly string _defaultItem = "Только поверхности";

        public ICommand Start { get; }
        public ICommand Stop { get; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<string> Modes { get; } = new()
        {
            "Грани",
            "Грани и поверхности",
            "Только поверхности"
        };

        public bool IsDrawing
        {
            get => _isDrawing;
            private set
            {
                if (_isDrawing != value)
                {
                    _isDrawing = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedMode
        {
            get => _selectedMode;
            set
            {
                if (_selectedMode != value)
                {
                    _selectedMode = value;
                }
            }
        }

        public MainViewModel()
        {
            Start = new Commands.RelayCommand(DrawingStart);
            Stop = new Commands.RelayCommand(DrawingEnd);
            SelectedMode = _defaultItem;
        }

        private void DrawingStart()
        {
            IsDrawing = true;
        }

        private void DrawingEnd()
        {
            IsDrawing = false;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
