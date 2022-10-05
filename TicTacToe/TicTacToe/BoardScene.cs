using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class BoardScene
    {
        private char _player1Token;
        private char _player2Token;
        /// <summary>
        /// Stores the current player's token.
        /// </summary>
        private char _currentToken;
        private char[,] _board;
        private bool _gameOver;
        /// <summary>
        /// Keeps track of the amount of turns that have passed.
        /// Will be needed to detect a draw.
        /// </summary>
        private int _turnCount;
        private Engine _engine;

        public BoardScene()
        {
            _board = new char[3, 3] { { '1','2','3'}, { '4','5','6'}, { '7','8','9'} };
            _gameOver = false;
            _player1Token = 'x';
            _player2Token = 'o';
        }

        public void Start()
        {
            _currentToken = _player1Token;
        }

        public void Update()
        {
            //Check if the game over.
            //Get where the player wants to put their token.
            //Check if player wants to quit the application.
            //Check if any player won.
            ////Update player turns.
            char choice = 'q';
            if (choice == 'q')
                Engine.EndApplication();

            //int choice = Engine.GetInput();

            //choice--;

            int row = choice / 3;
            int column = choice % 3;

            //SetToken(_currentToken, row, column );

        }

        public void Draw()
        {
            Console.WriteLine(_board[2, 0] + " | " + _board[2, 1] + " | " + _board[2, 2] + "\n" +
                                                    "__________\n" +
                              _board[1, 0] + " | " + _board[1, 1] + " | " + _board[1, 2] + "\n" +
                                                    "__________\n" +
                              _board[0, 0] + " | " + _board[0, 1] + " | " + _board[0, 2]);

        }

        public void End()
        {

        }

        /// <summary>
        /// Sets a position on the grid to be the value of the given token
        /// </summary>
        /// <param name="token">The token to write in the position</param>
        /// <param name="row">The position of the row to access in the array</param>
        /// <param name="column">The position of the column to access in the array</param>
        /// <returns></returns>
        private bool SetToken(char token, int row, int column)
        {
            return true;
        }

        /// <summary>
        /// Checks if a match of three was found for the token
        /// </summary>
        /// <param name="token">The token to use to check for matches</param>
        private bool CheckWinner(char token)
        {
            return false;
        }

        /// <summary>
        /// Changes the board array to have it's default values
        /// </summary>
        public void ClearBoard()
        {

        }
    }
}
