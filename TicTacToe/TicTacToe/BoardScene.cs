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
            if (_gameOver)
            {
                Engine.EndApplication();
                return;
            }

            //Get where the player wants to put their token.
            int choice = Engine.GetInput();

            //TO DO: Check if player wants to quit the application.

            //Decrement the value so that we can use it as an index.
            choice--;

            //Use the choice index to find the row and column for the 2D array.
            int row = choice / 3;
            int column = choice % 3;

            //Try to place the player token in the array.
            bool tokenPlaced = SetToken(_currentToken, row, column);

            //If the token cannot be placed...
            if (!tokenPlaced)
            {
                //...leave the function.
                return;
            }
            
            //Check if any player won.
            //If someone has won or if there was a tie...
            if (CheckWinner(_currentToken))
            {
                //...end the the game.
                _gameOver = true;
                return;
            }
            else if (_turnCount == 8)
            {
                _gameOver = true;
                _currentToken = 'd';
                return;
            }

            //Update player turns.
            if (_currentToken == _player1Token)
            {
                _currentToken = _player2Token;
            }
            else if (_currentToken == _player2Token)
            {
                _currentToken = _player1Token;
            }

            _turnCount++;
        }

        public void Draw()
        {
            Console.WriteLine(_board[2, 0] + " | " + _board[2, 1] + " | " + _board[2, 2] + "\n" +
                                                    "__________\n" +
                              _board[1, 0] + " | " + _board[1, 1] + " | " + _board[1, 2] + "\n" +
                                                    "__________\n" +
                              _board[0, 0] + " | " + _board[0, 1] + " | " + _board[0, 2]);

            Console.WriteLine("Your turn " + _currentToken + "!");
        }

        public void End()
        {
            if (_currentToken == 'd')
            {
                Console.WriteLine("No one wins :(");
            }
            else
            {
                Console.WriteLine(_currentToken + " wins!!!");
            }
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
            //If the row or column is outside the bounds of our array...
            if (row >= 3 || row < 0 || column >= 3 || column < 0)
                //...return that the player can't place a token there
                return false;

            //If the spot is taken already...
            if (_board[row, column] == _player1Token || _board[row, column] == _player2Token)
                //...return that the player can't place a token there
                return false;

            //Assign the token to the board position and return that the placement was successful.
            _board[row, column] = token;
            return true;
        }

        /// <summary>
        /// Checks if a match of three was found for the token
        /// </summary>
        /// <param name="token">The token to use to check for matches</param>
        private bool CheckWinner(char token)
        {
            int matches = 0;

            //Check horizontal
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i, j] == token)
                        matches++;
                    else break;
                }

                if (matches == 3)
                    return true;

                matches = 0;
            }

            matches = 0;
            //Check vertical
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[j, i] == token)
                        matches++;
                    else break;
                }

                if (matches == 3)
                    return true;

                matches = 0;
            }

            //Check diagonal top left
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, i] == token)
                    matches++;
                else break;

                if (matches == 3)
                    return true;
            }

            matches = 0;
            int h = 2;
            //Check diagonal top right
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, h] == token)
                    matches++;
                else break;

                if (matches == 3)
                    return true;
                h--;
            }

            return false;
        }

        /// <summary>
        /// Changes the board array to have it's default values
        /// </summary>
        public void ClearBoard()
        {
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }
    }
}
