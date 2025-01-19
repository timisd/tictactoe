using TicTacToe.ViewModels;
using Xunit;

namespace TicTacToe.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange & Act
            var viewModel = new MainViewModel();

            // Assert
            Assert.NotNull(viewModel.MakeMoveCommand);
            Assert.Equal('X', viewModel.CurrentPlayer); // First player should be X
        }

        [Fact]
        public void MakeMoveCommand_ShouldUpdateBoard()
        {
            // Arrange
            var viewModel = new MainViewModel();
            var initialCells = viewModel.Cells.ToArray();

            // Act
            viewModel.MakeMoveCommand.Execute("4"); // Center position

            // Assert
            Assert.NotEqual(initialCells[4], viewModel.Cells[4]);
        }

        [Theory]
        [InlineData("invalid")]
        [InlineData("9")]
        [InlineData("-1")]
        public void MakeMoveCommand_ShouldHandleInvalidInput(string input)
        {
            // Arrange
            var viewModel = new MainViewModel();
            var initialCells = viewModel.Cells.ToArray();

            // Act
            viewModel.MakeMoveCommand.Execute(input);

            // Assert
            Assert.Equal(initialCells, viewModel.Cells);
        }

        [Fact]
        public void PropertyChanged_ShouldBeRaisedAfterMove()
        {
            // Arrange
            var viewModel = new MainViewModel();
            var propertiesChanged = new List<string>();
            viewModel.PropertyChanged += (s, e) => propertiesChanged.Add(e.PropertyName!);

            // Act
            viewModel.MakeMoveCommand.Execute("4");

            // Assert
            Assert.Contains("Cells", propertiesChanged);
            Assert.Contains("CurrentPlayer", propertiesChanged);
        }
    }
}