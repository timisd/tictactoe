using TicTacToe.TicTacToe.Models;
using Xunit;

namespace TicTacToe.Tests
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void ComputerPlayer_ShouldHaveCorrectSymbol()
        {
            // Arrange & Act
            var computer = new ComputerPlayer();

            // Assert
            Assert.Equal('O', computer.Symbol);
        }

        [Fact]
        public void MakeMove_ShouldBlockPlayerWin()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var computer = new ComputerPlayer();
            
            // Set up a scenario where player is about to win
            gameBoard.MakeMove(0, 'X');
            gameBoard.MakeMove(1, 'X');

            // Act
            computer.MakeMove(gameBoard);

            // Assert
            Assert.Equal('O', gameBoard.Cells[2]); // Computer should block at position 2
        }

        [Fact]
        public void MakeMove_ShouldTakeCenterIfAvailable()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var computer = new ComputerPlayer();

            // Act
            computer.MakeMove(gameBoard);

            // Assert
            Assert.Equal('O', gameBoard.Cells[4]); // Center position
        }
    }
}