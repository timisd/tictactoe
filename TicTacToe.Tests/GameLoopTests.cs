using TicTacToe.TicTacToe.ViewModels;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameLoopTests
    {
        [Fact]
        public void Constructor_ShouldInitializeEmptyBoard()
        {
            // Arrange & Act
            var gameLoop = new GameLoop();

            // Assert
            Assert.All(gameLoop.Cells, cell => Assert.Equal(' ', cell));
        }

        [Fact]
        public void MakeMove_ShouldTriggerComputerMove()
        {
            // Arrange
            var gameLoop = new GameLoop();

            // Act
            gameLoop.MakeMove(4); // Make move in center

            // Assert
            var humanMoveCount = gameLoop.Cells.Count(c => c == 'X');
            var computerMoveCount = gameLoop.Cells.Count(c => c == 'O');
            Assert.Equal(1, humanMoveCount);
            Assert.Equal(1, computerMoveCount);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(9)]
        public void MakeMove_ShouldIgnoreInvalidMoves(int position)
        {
            // Arrange
            var gameLoop = new GameLoop();
            var initialBoard = gameLoop.Cells.ToArray();

            // Act
            gameLoop.MakeMove(position);

            // Assert
            Assert.Equal(initialBoard, gameLoop.Cells);
        }

        [Fact]
        public void MakeMove_ShouldNotAllowOverwritingOccupiedCell()
        {
            // Arrange
            var gameLoop = new GameLoop();
            gameLoop.MakeMove(4); // Make first move
            var boardAfterFirstMove = gameLoop.Cells.ToArray();

            // Act
            gameLoop.MakeMove(4); // Try to move in same position

            // Assert
            Assert.Equal(boardAfterFirstMove[4], gameLoop.Cells[4]);
        }
    }
}