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
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

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
            Name = "Pawn";
        }

        /// <summary>
        /// Pawns can move +1 space forward, move diagonal if piece is 1 space diagonal
        /// </summary>
        /// <param name="boardState"></param>
        /// <returns></returns>
        public override List<Point> GetMovablePoints(Board boardState)
        {
            List<Point> points = new List<Point>();
            //black pieces on top, white on bottom
            int offset = isBlack ? -1 : 1;

            Point initial = new Point(location.X, location.Y + offset);
            Point possible1 = new Point(location.X + offset, location.Y + offset);
            Point possible2 = new Point(location.X - offset, location.Y + offset);

            if (initial.Y < boardState.board.Length && initial.Y >= 0)
                points.Add(initial);
            if (possible1.X >= 0 && possible1.X < 8 && possible1.Y >= 0 && possible1.Y < 8)
                if (boardState.board[possible1.X, possible1.Y] != null) points.Add(possible1);
            if (possible2.X >= 0 && possible2.X < 8 && possible2.Y >= 0 && possible2.Y < 8)
                if (boardState.board[possible2.X, possible2.Y] != null) points.Add(possible2);

            return points;
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
            Name = "Rook";
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
            Name = "Knight";
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
            Name = "Bishop";
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
            Name = "Queen";
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
            Name = "King";
        }

        public override List<Point> GetMovablePoints(Board boardState)
        {
            return null;
        }
    }

}
