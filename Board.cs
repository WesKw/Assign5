/**
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
    public class Board : IDisposable
    {
        public enum State
        {
            NORMAL = 0,
            CHECK = 1,
            CHECKMATE = 2
        }

        public const int SQUARE_SIZE = 60;
        public Piece[,] board;
        private List<Point> possiblePoints = null;

        public List<Point> PossiblePoints
        {
            get => possiblePoints;
            set => possiblePoints = value;
        }

        public Board()
        {
            board = new Piece[8, 8]; //initialize board
        }

        /// <summary>
        /// Responsible for drawing the board, also highlight where a piece can move and the current selected piece
        /// </summary>
        /// <param name="g"></param>
        /// <param name="white"></param>
        /// <param name="black"></param>
        public void Draw(Graphics g, Brush white, Brush black, Brush highlight, Point lastClicked)
        {
            bool w = true;
            //i is y (column), j is x (row)
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)  //the board is square so who cares!
                {
                    g.FillRectangle(w == true ? white : black,
                                    j * SQUARE_SIZE, i * SQUARE_SIZE,
                                    SQUARE_SIZE, SQUARE_SIZE);
                    w = !w; //swap colors

                    if(lastClicked.X != -1 && lastClicked.X == j && lastClicked.Y == i) //highlight the current clicked square
                        g.FillRectangle(highlight, j * SQUARE_SIZE, i * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
                }
                w = !w; //swap colors
            }

            if(PossiblePoints != null)
            {
                foreach(Point p in PossiblePoints)
                {
                    g.FillRectangle(highlight, p.X * SQUARE_SIZE, p.Y * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
                }
            }

            //g.FillRectangle(highlight, 1 * SQUARE_SIZE, 0 * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
        }

        public void Dispose()
        {
            board = null;
        }
    }
}
