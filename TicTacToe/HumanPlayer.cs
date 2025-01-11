using System.Windows.Controls;

namespace TicTacToe;

public class HumanPlayer(Button[] buttons) : Player('X', buttons)
{
    private TaskCompletionSource<bool> _tcs;

    public override async Task ExecuteTurn()
    {
        _tcs = new TaskCompletionSource<bool>();
        await _tcs.Task;
    }

    public void OnButtonClick()
    {
        _tcs?.SetResult(true);
    }
}