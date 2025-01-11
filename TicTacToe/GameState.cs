namespace TicTacToe;

public static class GameState
{
    public static bool IsGameOver(char[] board)
    {
        foreach (var content in board)
            if (content == ' ')
                return false;

        return true;
    }

    public static bool HasPlayerWon(char[] board, char player)
    {
        // Check rows
        for (var i = 0; i < 3; i++)
            if (board[i * 3] == player && board[i * 3 + 1] == player && board[i * 3 + 2] == player)
                return true;

        // Check columns
        for (var i = 0; i < 3; i++)
            if (board[i] == player && board[i + 3] == player && board[i + 6] == player)
                return true;

        // Check diagonals
        if (board[0] == player && board[4] == player && board[8] == player)
            return true;

        return board[2] == player && board[4] == player && board[6] == player;
    }

    public static bool IsDraw(char[] board)
    {
        if (!IsGameOver(board))
            return false;

        return !HasPlayerWon(board, 'X') && !HasPlayerWon(board, 'O');
    }
}