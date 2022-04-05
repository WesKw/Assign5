/**
 * Authors: Wesley Kwiecinski - Z1896564, Ojas DhiYogi - Z1849680
 * CSCI 473 Assignment 5
 * Due 4/14/2022
 * 
 * Generic piece class, the base for all piece subclasses.
 * 
 * Wesley was responsible for this class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assign5
{
    abstract class Piece
    {
        protected Image pieceImage;
        public bool black;   //is piece "black" or "white"?
        public Point location;

        public abstract void DrawPiece(Graphics g);
    }
}
