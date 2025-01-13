namespace TicTacToe.Models;

public class ComputerPlayer() : Player('O')
{
    private const char computer = 'O';
    private const char player = 'X';

    public void MakeMove(GameBoard gameBoard)
    {
        var move = FindBestMove(gameBoard.Cells);
        gameBoard.MakeMove(move, computer);
    }

    private int FindBestMove(char[] board)
    {
        var logOutput = string.Empty;
        var bestScore = int.MinValue;
        var move = -1;

        for (var i = 0; i < board.Length; i++)
            if (board[i] == ' ')
            {
                board[i] = computer;
                var result = Minimax(board, 0, false);
                logOutput += result.Log;
                board[i] = ' ';
                if (result.Score <= bestScore) continue;

                bestScore = result.Score;
                move = i;
            }

        logOutput += $"Best move: {move}, Score: {bestScore}\n";

        return move;
    }

    private (int Score, string Log) Minimax(char[] board, int depth, bool isMaximizing)
    {
        if (board.IsWinner(computer))
            return (10 - depth, string.Empty);
        if (board.IsWinner(player))
            return (depth - 10, string.Empty);
        if (board.IsDraw())
            return (0, string.Empty);

        var minimaxOutput = string.Empty;
        int bestScore;

        if (isMaximizing)
        {
            bestScore = int.MinValue;
            for (var i = 0; i < board.Length; i++)
                if (board[i] == ' ')
                {
                    board[i] = computer;
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
                    board[i] = player;
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