namespace TicTacToe;

public static class GameState
{
    public static string PrintBoard(this char[] board)
    {
        var output = string.Empty;
        for (var i = 0; i < 3; i++)
        {
            output +=
                $" {board[i * 3]} | {board[i * 3 + 1]} | {board[i * 3 + 2]} \n";
            if (i < 2)
                output += "-----------\n";
        }

        return output;
    }

    public static bool IsGameOver(this char[] cells)
    {
        return cells.IsDraw() || cells.IsWinner('X') || cells.IsWinner('O');
    }

    public static bool IsDraw(this char[] cells)
    {
        return cells.All(cell => cell != ' ') && !cells.IsWinner('X') && !cells.IsWinner('O');
    }

    public static bool IsWinner(this char[] cells, char symbol)
    {
        // Check rows
        for (var i = 0; i < 9; i += 3)
            if (cells[i] == symbol && cells[i + 1] == symbol && cells[i + 2] == symbol)
                return true;

        // Check columns
        for (var i = 0; i < 3; i++)
            if (cells[i] == symbol && cells[i + 3] == symbol && cells[i + 6] == symbol)
                return true;

        // Check diagonals
        return (cells[0] == symbol && cells[4] == symbol && cells[8] == symbol) ||
               (cells[2] == symbol && cells[4] == symbol && cells[6] == symbol);
    }
}