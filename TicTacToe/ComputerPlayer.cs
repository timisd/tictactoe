using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TicTacToe;

public class ComputerPlayer(Button[] buttons, TextBox output) : Player('O', buttons)
{
    private const char Computer = 'O';
    private const char Player = 'X';

    private void UpdateOutput(string message)
    {
        output.Dispatcher.Invoke(() => output.Text += message);
    }

    public override async Task ExecuteTurn()
    {
        var bestMove = FindBestMove();
        if (bestMove != -1) Buttons[bestMove].RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
    }

    private int FindBestMove()
    {
        var board = new char[Buttons.Length];
        for (var i = 0; i < Buttons.Length; i++)
            board[i] = Buttons[i].Content.ToString() == string.Empty ? ' ' : Buttons[i].Content.ToString()[0];

        var logOutput = string.Empty;
        var bestScore = int.MinValue;
        var move = -1;

        for (var i = 0; i < board.Length; i++)
            if (board[i] == ' ')
            {
                board[i] = Computer;
                var result = Minimax(board, 0, false);
                logOutput += result.Log;
                board[i] = ' ';
                if (result.Score <= bestScore) continue;

                bestScore = result.Score;
                move = i;
            }

        logOutput += $"Best move: {move}, Score: {bestScore}\n";
        UpdateOutput(logOutput);
        return move;
    }

    private (int Score, string Log) Minimax(char[] board, int depth, bool isMaximizing)
    {
        if (GameState.HasPlayerWon(board, Computer))
            return (10 - depth, string.Empty);
        if (GameState.HasPlayerWon(board, Player))
            return (depth - 10, string.Empty);
        if (GameState.IsDraw(board))
            return (0, string.Empty);

        var minimaxOutput = string.Empty;
        int bestScore;

        if (isMaximizing)
        {
            bestScore = int.MinValue;
            for (var i = 0; i < board.Length; i++)
                if (board[i] == ' ')
                {
                    board[i] = Computer;
                    var result = Minimax(board, depth + 1, false);
                    board[i] = ' ';
                    bestScore = Math.Max(result.Score, bestScore);
                    minimaxOutput += "Board for calculation:\n";
                    minimaxOutput += board.PrintBoard();
                    minimaxOutput += $"Maximizing: Depth: {depth}, Best Score: {bestScore}\n";
                    minimaxOutput += "--------------------------------\n";
                }
        }
        else
        {
            bestScore = int.MaxValue;
            for (var i = 0; i < board.Length; i++)
                if (board[i] == ' ')
                {
                    board[i] = Player;
                    var result = Minimax(board, depth + 1, true);
                    board[i] = ' ';
                    bestScore = Math.Min(result.Score, bestScore);
                    minimaxOutput += "Board for calculation:\n";
                    minimaxOutput += board.PrintBoard();
                    minimaxOutput += $"Minimizing: Depth: {depth}, Best Score: {bestScore}\n";
                    minimaxOutput += "--------------------------------\n\n";
                }
        }

        return (bestScore, minimaxOutput);
    }
}