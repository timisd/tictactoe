using TicTacToe.Models;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameStateTests
    {
        [Fact]
        public void IsWinner_HorizontalWin_ReturnsTrue()
        {
            // Arrange
            var board = new char[] 
            {
                'X', 'X', 'X',  // Top row win
                ' ', 'O', 'O',
                ' ', ' ', ' '
            };

            // Act & Assert
            Assert.True(board.IsWinner('X'));
        }

        [Fact]
        public void IsWinner_VerticalWin_ReturnsTrue()
        {
            // Arrange
            var board = new char[] 
            {
                'O', 'X', ' ',
                'O', 'X', ' ',
                'O', ' ', ' '  // Left column win
            };

            // Act & Assert
            Assert.True(board.IsWinner('O'));
        }

        [Fact]
        public void IsWinner_DiagonalWin_ReturnsTrue()
        {
            // Arrange
            var board = new char[] 
            {
                'X', 'O', ' ',
                'O', 'X', ' ',
                ' ', 'O', 'X'  // Diagonal win
            };

            // Act & Assert
            Assert.True(board.IsWinner('X'));
        }

        [Fact]
        public void IsDraw_FullBoardNoWinner_ReturnsTrue()
        {
            // Arrange
            var board = new char[] 
            {
                'X', 'O', 'X',
                'X', 'O', 'O',
                'O', 'X', 'X'
            };

            // Act & Assert
            Assert.True(board.IsDraw());
        }

        [Fact]
        public void IsGameOver_WinnerExists_ReturnsTrue()
        {
            // Arrange
            var board = new char[] 
            {
                'X', 'X', 'X',
                'O', 'O', ' ',
                ' ', ' ', ' '
            };

            // Act & Assert
            Assert.True(board.IsGameOver());
        }
    }
}