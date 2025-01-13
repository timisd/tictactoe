using System.ComponentModel;
using System.Runtime.CompilerServices;
using TicTacToe.Models;

namespace TicTacToe.ViewModels;

public class GameLoop : INotifyPropertyChanged
{
    private readonly ComputerPlayer _computerPlayer = new();
    private readonly Player _currentPlayer;
    private readonly GameBoard _gameBoard = new();
    private readonly HumanPlayer _humanPlayer = new();

    public GameLoop()
    {
        _currentPlayer = _humanPlayer;
    }

    public char[] Cells => _gameBoard.Cells;

    public char CurrentPlayer => _currentPlayer.Symbol;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void MakeMove(int index)
    {
        if (!_gameBoard.MakeMove(index, _currentPlayer.Symbol)) return;

        if (!Cells.IsGameOver()) _computerPlayer.MakeMove(_gameBoard);

        OnPropertyChanged(nameof(Cells));
    }
}