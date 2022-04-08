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
    /// <summary>
    /// Generic piece class, defines draw function
    /// </summary>
    public abstract class Piece
    {
        public Point location;  //location of the piece on the canvas
        protected Image pieceImage; //actual piece image
        public bool isBlack;   //is piece "black" or "white"?
        public Size size = new Size(Board.SQUARE_SIZE, Board.SQUARE_SIZE);  //image size

        /// <summary>
        /// Constructor for a new piece, sets the location of the piece
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Piece(int x, int y, bool black, Image img)
        {
            location = new Point(x, y);
            isBlack = black;
        }

        /// <summary>
        /// Gets the movable points of the piece. Changes based on the piece and gamestate.
        /// </summary>
        /// <param name="boardState"></param>
        /// <returns></returns>
        public abstract List<Point> GetMovablePoints(Board boardState);

        /// <summary>
        /// Draws the piece on the provided canvas.
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawPiece(Graphics g)
        {
            Point loc = new Point(location.X * Board.SQUARE_SIZE, location.Y * Board.SQUARE_SIZE);
            Rectangle rect = new Rectangle(loc, size);
            g.DrawImage(pieceImage, rect);
        }
    }

    /// <summary>
    /// Pawn, subclass of piece.
    /// </summary>
    public class Pawn : Piece
    {
        /// <summary>
        /// Set the reference to the desired image
        /// </summary>
        /// <param name="x">x starting location</param>
        /// <param name="y">y starting location</param>
        /// <param name="black">is the piece black?</param>
        /// <param name="img">reference to image of piece</param>
        public Pawn(int x, int y, bool black, Image img) : base(x, y, black, img)
        {
            pieceImage = img;
        }

        public override List<Point> GetMovablePoints(Board boardState)
        {
            return null;
        }
    }

    /// <summary>
    /// Rook - subclass of piece
    /// </summary>
    public class Rook : Piece
    {
        /// <summary>
        /// Sets the image reference to the rook image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="black"></param>
        /// <param name="img"></param>
        public Rook(int x, int y, bool black, Image img) : base(x, y, black, img)
        {
            pieceImage = img;
        }

        public override List<Point> GetMovablePoints(Board boardState)
        {
            return null;
        }
    }

    /// <summary>
    /// Knight - subclass of piece
    /// </summary>
    public class Knight : Piece
    {
        /// <summary>
        /// Sets image to knight image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="black"></param>
        /// <param name="img"></param>
        public Knight(int x, int y, bool black, Image img) : base(x, y, black, img)
        {
            pieceImage = img;
        }

        public override List<Point> GetMovablePoints(Board boardState)
        {
            return null;
        }
    }

    /// <summary>
    /// Bishop - subclass of piece
    /// </summary>
    public class Bishop : Piece
    {
        /// <summary>
        /// Sets image to Bishop image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="black"></param>
        /// <param name="img"></param>
        public Bishop(int x, int y, bool black, Image img) : base(x, y, black, img)
        {
            pieceImage = img;
        }

        public override List<Point> GetMovablePoints(Board boardState)
        {
            return null;
        }
    }

    /// <summary>
    /// Queen - subclass of piece
    /// </summary>
    public class Queen : Piece
    {
        /// <summary>
        /// Sets image to Queen image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="black"></param>
        /// <param name="img"></param>
        public Queen(int x, int y, bool black, Image img) : base(x, y, black, img)
        {
            pieceImage = img;
        }

        public override List<Point> GetMovablePoints(Board boardState)
        {
            return null;
        }
    }

    /// <summary>
    /// King - subclass of piece
    /// </summary>
    public class King : Piece
    {
        /// <summary>
        /// Sets image to King image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="black"></param>
        /// <param name="img"></param>
        public King(int x, int y, bool black, Image img) : base(x, y, black, img)
        {
            pieceImage = img;
        }

        public override List<Point> GetMovablePoints(Board boardState)
        {
            return null;
        }
    }

}
