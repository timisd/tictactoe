using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TicTacToe.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly GameLoop _gameLoop;

    public MainViewModel()
    {
        _gameLoop = new GameLoop();
        MakeMoveCommand = new RelayCommand(MakeMove);
    }

    public ICommand MakeMoveCommand { get; }

    public char[] Cells => _gameLoop.Cells;
    public char CurrentPlayer => _gameLoop.CurrentPlayer;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void MakeMove(object? index)
    {
        if (index is not string strIndex || !int.TryParse(strIndex, out var intIndex)) return;

        _gameLoop.MakeMove(intIndex);
        OnPropertyChanged(nameof(Cells));
        OnPropertyChanged(nameof(CurrentPlayer));
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}