using System.Windows;
using System.Windows.Controls;

namespace TicTacToe;

public class GameLoop
{
    private readonly Button[] _buttons;
    private readonly Player _computerPlayer;
    private readonly Player _humanPlayer;
    private readonly MainWindow _ui;
    private Player _currentPlayer;

    public GameLoop(MainWindow ui)
    {
        _ui = ui;
        _buttons =
        [
            _ui.Button00, _ui.Button01, _ui.Button02, _ui.Button10, _ui.Button11, _ui.Button12, _ui.Button20,
            _ui.Button21,
            _ui.Button22
        ];
        SetUpButtons(_buttons);
        _humanPlayer = new HumanPlayer(_buttons);
        _computerPlayer = new ComputerPlayer(_buttons, _ui.OutputTextBox);
        _currentPlayer = _computerPlayer;
        Game();
    }

    private async Task Game()
    {
        do
        {
            ChangePlayer();
            _ui.StatusTextBlock.Text = $"Current player: {_currentPlayer.Symbol}";
            await _currentPlayer.ExecuteTurn();
        } while (!GameState.IsGameFinished(ConvertButtonsToCharArray(_buttons)));

        ShowGameEnd();
    }

    private void ShowGameEnd()
    {
        _ui.RestartButton.Click += RestartGame;
        _ui.WinnerTextBlock.Text = GameState.IsDraw(ConvertButtonsToCharArray(_buttons))
            ? "It's a draw!"
            : $"Player {_currentPlayer.Symbol} wins!";
        _ui.GameOverPanel.Visibility = Visibility.Visible;
    }

    private void RestartGame(object sender, RoutedEventArgs e)
    {
        foreach (var button in _buttons)
        {
            button.Content = " ";
            button.IsEnabled = true;
        }

        _ui.OutputTextBox.Text = "";
        _ui.GameOverPanel.Visibility = Visibility.Collapsed;
        _currentPlayer = _computerPlayer;
        Game();
    }

    private void ChangePlayer()
    {
        _currentPlayer = _currentPlayer == _humanPlayer ? _computerPlayer : _humanPlayer;
    }

    private void SetUpButtons(Button[] buttons)
    {
        foreach (var button in buttons)
        {
            button.Content = " ";
            button.Click += ButtonClick;
        }
    }

    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        button.Content = _currentPlayer.Symbol;
        button.IsEnabled = false;

        if (_currentPlayer is HumanPlayer humanPlayer) humanPlayer.OnButtonClick();
    }

    private char[] ConvertButtonsToCharArray(Button[] buttons)
    {
        var board = new char[buttons.Length];
        for (var i = 0; i < buttons.Length; i++)
            board[i] = buttons[i].Content.ToString() == string.Empty ? ' ' : buttons[i].Content.ToString()[0];
        return board;
    }
}