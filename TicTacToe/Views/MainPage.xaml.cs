using TicTacToe.ViewModels;

namespace TicTacToe.Views;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}