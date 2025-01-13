namespace TicTacToe.Models;

public class GameBoard
{
    public char[] Cells { get; } = Enumerable.Repeat(' ', 9).ToArray();

    public bool MakeMove(int index, char symbol)
    {
        var isValidMove = index >= 0 && index < Cells.Length;

        if (Cells[index] != ' ' || !isValidMove || Cells.IsGameOver()) return false;

        Cells[index] = symbol;
        return true;
    }
}