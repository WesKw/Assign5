﻿/**
 * Authors: Wesley Kwiecinski - Z1896564, Ojas DhiYogi - Z1849680
 * CSCI 473 Assignment 5
 * Due 4/14/2022
 * 
 * Board class. Sets up the board and tracks which squares are filled.
 * 
 * Wesley was responsible for this class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Assign5
{
    internal class Board : IDisposable
    {
        private const int SQUARE_SIZE = 60;
        public Piece[,] board;

        public Board()
        {
            board = new Piece[8, 8]; //initialize board
        }

        /// <summary>
        /// Responsible for drawing the board
        /// </summary>
        /// <param name="g"></param>
        /// <param name="white"></param>
        /// <param name="black"></param>
        public void Draw(Graphics g, Brush white, Brush black)
        {
            bool w = true;
            for(int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)  //the board is square so who cares!
                {
                    g.FillRectangle(w == true ? white : black,
                                    j * SQUARE_SIZE, i * SQUARE_SIZE,
                                    SQUARE_SIZE, SQUARE_SIZE);
                    w = !w; //swap colors
                }
                w = !w; //swap colors
            }
        }

        /// <summary>
        /// Updates the board by placing a boolean value at the given x and y.
        /// Checks if other pieces exist, if it needs to take a piece, etc
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="y">y location</param>
        public void UpdateBoard(int x, int y)
        {

        }

        public void Dispose()
        {
            board = null;
        }
    }
}
