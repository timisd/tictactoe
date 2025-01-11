using System.Windows.Controls;

namespace TicTacToe;

public abstract class Player(char symbol, Button[] buttons)
{
    public char Symbol { get; } = symbol;
    protected Button[] Buttons { get; } = buttons;

    public abstract Task ExecuteTurn();
}