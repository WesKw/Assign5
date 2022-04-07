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
    public abstract class Piece
    {
        public Point location;
        protected Image pieceImage;
        public bool isBlack;   //is piece "black" or "white"?
        public Size size = new Size(Board.SQUARE_SIZE, Board.SQUARE_SIZE);

        /// <summary>
        /// Constructor for a new piece, sets the location of the piece
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Piece(int x, int y, bool black)
        {
            location = new Point(x, y);
            isBlack = black;
        }

        public abstract List<Point> GetMovablePoints();
        public abstract void DrawPiece(Graphics g);
    }

    public class Pawn : Piece
    {
        public Pawn(int x, int y, bool black) : base(x, y, black)
        {
            string path = black ? @".\icons\black\chess-pawn.png" : @".\icons\black\chess-pawn.png";
            pieceImage = Image.FromFile(path);
        }

        public override List<Point> GetMovablePoints()
        {
            return null;
        }

        public override void DrawPiece(Graphics g)
        {
            Point loc = new Point(location.X*Board.SQUARE_SIZE, location.Y*Board.SQUARE_SIZE);
            Rectangle rect = new Rectangle(loc, size);
            g.DrawImage(pieceImage, rect);
        }
    }

    public class Rook : Piece
    {
        public Rook(int x, int y, bool black) : base(x, y, black) { }

        public override List<Point> GetMovablePoints()
        {
            return null;
        }

        public override void DrawPiece(Graphics g)
        {
            
        }
    }

    public class Knight : Piece
    {
        public Knight(int x, int y, bool black) : base(x, y, black)
        {

        }

        public override List<Point> GetMovablePoints()
        {
            return null;
        }

        public override void DrawPiece(Graphics g)
        {

        }
    }
}
