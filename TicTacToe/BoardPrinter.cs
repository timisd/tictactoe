namespace TicTacToe;

public static class BoardPrinter
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
}