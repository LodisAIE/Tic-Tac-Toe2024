using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Engine
    {
        private static bool _applicationShouldClose;
        private Board _gameBoard;

        public static void EndApplication()
        {
            _applicationShouldClose = true;
        }

        public static int GetInput()
        {

            return choiceConverted;
        }

        /// <summary>
        /// Called at the beginning of the application.
        /// </summary>
        public void Start()
        {
            _gameBoard = new Board();
            _gameBoard.Start();
        }

        /// <summary>
        /// Called every time the application loops.
        /// Used to update game state and logic.
        /// </summary>
        public void Update()
        {
            _gameBoard.Update();
        }

        /// <summary>
        /// Called every time the application loops.
        /// Used to display current game state.
        /// </summary>
        void Draw()
        {
            Console.Clear();
            _gameBoard.Draw();
            Console.ReadKey();
        }

        /// <summary>
        /// Called when the application ends.
        /// </summary>
        public void End()
        {
            _gameBoard.End();
        }


        public void Run()
        {
            Start();

            while (!_applicationShouldClose)
            {
                Draw();
                Update();
            }

            End();

            string choice = Console.ReadLine();
            int choiceConverted = Convert.ToInt32(choice);
        }
    }
}
