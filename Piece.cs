/**
 * Authors: Wesley Kwiecinski - Z1896564, Ojas DhiYogi - Z1849680
 * CSCI 473 Assignment 5
 * Due 4/14/2022
 * 
 * Generic piece class, the base for all piece subclasses.
 * 
 * Wesley was responsible for the abstract class and the Pawn, Rook, and Knight classes.
 * Ojas was responsible for the Bishop, Queen, and King classes.
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
    public abstract class Piece : IDisposable
    {
        public Point location;  //location of the piece on the canvas
        protected Image pieceImage; //actual piece image
        private bool isBlack;   //is piece "black" or "white"?
        public Size size = new Size(Board.SQUARE_SIZE, Board.SQUARE_SIZE);  //image size
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public bool IsBlack
        {
            get => isBlack;
            set => isBlack = value;
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

        public void MoveTo(int x, int y)
        {
            location.X = x;
            location.Y = y;
        }

        /// <summary>
        /// Gets the movable points of the piece. Changes based on the piece and gamestate.
        /// </summary>
        /// <param name="boardState"></param>
        /// <returns>The full list of points that the piece can move to</returns>
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

        public void Dispose()
        {
            pieceImage = null;
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
            int offset = IsBlack ? -1 : 1;
            if (location.Y < 0 || location.Y > 7) return points;    //the new location is outside of the board

            Piece p = boardState.board[location.X, location.Y + offset];

            Point initial = new Point(location.X, location.Y + offset);
            Point possible1 = new Point(location.X + offset, location.Y + offset);
            Point possible2 = new Point(location.X - offset, location.Y + offset);

            //only add the point if there is no piece in front and on the board
            if (initial.Y < boardState.board.Length && initial.Y >= 0 && p == null)
                points.Add(initial);

            //add the diagonal points if the pawn can attack a piece on the diagonal
            if (possible1.X >= 0 && possible1.X < 8 && possible1.Y >= 0 && possible1.Y < 8)
                if (boardState.board[possible1.X, possible1.Y] != null && boardState.board[possible1.X, possible1.Y].IsBlack != IsBlack)
                    points.Add(possible1);
            if (possible2.X >= 0 && possible2.X < 8 && possible2.Y >= 0 && possible2.Y < 8)
                if (boardState.board[possible2.X, possible2.Y] != null && boardState.board[possible2.X, possible2.Y].IsBlack != IsBlack) 
                    points.Add(possible2);

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

        /// <summary>
        /// Get the list of possible points that a rook can move to.
        /// </summary>
        /// <param name="boardState">The state of the current board</param>
        /// <returns></returns>
        public override List<Point> GetMovablePoints(Board boardState)
        {
            List<Point> points = new List<Point>();

            //Is this horrible mess better than manually typing out the points? Hmmmmm
            //I think it probably is
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)  //if even move in x direction
                {
                    bool stop = false;
                    int dir = i - 1;
                    int j = 1;
                    while (j < 8)  //move in both x directions until we hit a friendly
                    {
                        Point p1 = new Point(location.X + j * dir, location.Y);

                        if ((p1.X >= 0 && p1.X < 8 && p1.Y >= 0 && p1.Y < 8) && !stop) //if the point is on the board
                        {
                            if (boardState.board[p1.X, p1.Y] == null)
                                points.Add(p1);
                            else if ((boardState.board[p1.X, p1.Y] != null && boardState.board[p1.X, p1.Y].IsBlack != IsBlack))
                            {
                                points.Add(p1);
                                break;
                            } else if (boardState.board[p1.X, p1.Y].IsBlack == IsBlack) //must be same color
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }

                        j++;
                    }
                }
                else //move in y direction
                {
                    bool stop = false;
                    int j = 1;
                    int dir = i - 2;
                    while (j < 8)  //move in both x directions until we hit a friendly
                    {
                        Point p1 = new Point(location.X, location.Y + j * dir);

                        if ((p1.X >= 0 && p1.X < 8 && p1.Y >= 0 && p1.Y < 8) && !stop) //if the point is on the board
                        {
                            if (boardState.board[p1.X, p1.Y] == null)
                                points.Add(p1);
                            else if (boardState.board[p1.X, p1.Y].IsBlack != IsBlack)
                            {
                                points.Add(p1);
                                break;
                            } else if (boardState.board[p1.X, p1.Y].IsBlack == IsBlack) //must be same color
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }
                        j++;
                    }
                }
            }

            return points;
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

        /// <summary>
        /// The knight piece moves in an L shape, this function gets all possible
        /// points of movement for a knight based on the current board state
        /// </summary>
        /// <param name="boardState"></param>
        /// <returns></returns>
        public override List<Point> GetMovablePoints(Board boardState)
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < 4; i++)
            {
                if(i % 2 == 0)  //if even move in x direction first
                {
                    int dir = i - 1;    //direction of the x offset
                    Point p1 = new Point(location.X + (dir * 2), location.Y + 1);    //move up and down
                    Point p2 = new Point(location.X + (dir * 2), location.Y - 1);

                    if (p1.X >= 0 && p1.X < 8 && p1.Y >= 0 && p1.Y < 8) //if the point is on the board
                        if (boardState.board[p1.X, p1.Y] == null || 
                           (boardState.board[p1.X, p1.Y] != null && boardState.board[p1.X, p1.Y].IsBlack != IsBlack))
                        {

                            points.Add(p1);
                        }

                    if (p2.X >= 0 && p2.X < 8 && p2.Y >= 0 && p2.Y < 8) //if the point is on the board
                        if (boardState.board[p2.X, p2.Y] == null || 
                           (boardState.board[p2.X, p2.Y] != null && boardState.board[p2.X, p2.Y].IsBlack != IsBlack))
                        {
                            points.Add(p2);
                        }

                } else //move in y direction first
                {
                    int dir = i - 2;    //direction of the y offset
                    Point p1 = new Point(location.X + 1, location.Y + (dir * 2));    //move left and right
                    Point p2 = new Point(location.X - 1, location.Y + (dir * 2));

                    if (p1.X >= 0 && p1.X < 8 && p1.Y >= 0 && p1.Y < 8) //if the point is on the board
                        if (boardState.board[p1.X, p1.Y] == null ||
                           (boardState.board[p1.X, p1.Y] != null && boardState.board[p1.X, p1.Y].IsBlack != IsBlack))
                        {

                            points.Add(p1);
                        }

                    if (p2.X >= 0 && p2.X < 8 && p2.Y >= 0 && p2.Y < 8) //if the point is on the board
                        if (boardState.board[p2.X, p2.Y] == null ||
                           (boardState.board[p2.X, p2.Y] != null && boardState.board[p2.X, p2.Y].IsBlack != IsBlack))
                        {
                            points.Add(p2);
                        }
                }
            }

            return points;
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
            List<Point> points = new List<Point>();

            int i = 1;
            while(i < 8)
            {
                Point p = new Point(location.X + 1 * i, location.Y + 1 * i);
                if (p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8)
                {
                    Piece piece = boardState.board[p.X, p.Y];
                    if (piece == null)
                        points.Add(p);
                    else if ((piece != null && piece.IsBlack != IsBlack))
                    {
                        points.Add(p);
                        break;
                    }
                    else if (piece.IsBlack == IsBlack)
                        break;
                }
                else
                    break;
                i++;
            }

            i = 1;
            while (i < 8)
            {
                Point p = new Point(location.X + -1 * i, location.Y + 1 * i);
                if (p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8)
                {
                    Piece piece = boardState.board[p.X, p.Y];
                    if (piece == null)
                        points.Add(p);
                    else if ((piece != null && piece.IsBlack != IsBlack))
                    {
                        points.Add(p);
                        break;
                    }
                    else if (piece.IsBlack == IsBlack)
                        break;
                }
                else
                    break;
                i++;
            }

            i = 1;
            while (i < 8)
            {
                Point p = new Point(location.X + -1 * i, location.Y + -1 * i);
                if (p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8)
                {
                    Piece piece = boardState.board[p.X, p.Y];
                    if (piece == null)
                        points.Add(p);
                    else if ((piece != null && piece.IsBlack != IsBlack))
                    {
                        points.Add(p);
                        break;
                    }
                    else if (piece.IsBlack == IsBlack)
                        break;
                }
                else
                    break;
                i++;
            }

            i = 1;
            while (i < 8)
            {
                Point p = new Point(location.X + 1 * i, location.Y + -1 * i);
                if (p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8)
                {
                    Piece piece = boardState.board[p.X, p.Y];
                    if (piece == null)
                        points.Add(p);
                    else if ((piece != null && piece.IsBlack != IsBlack))
                    {
                        points.Add(p);
                        break;
                    }
                    else if (piece.IsBlack == IsBlack)
                        break;
                }
                else
                    break;
                i++;
            }


            return points;
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

        /// <summary>
        /// Gets the list of points for a king
        /// </summary>
        /// <param name="boardState">Current state of the board</param>
        /// <returns>A list of possible points to move to</returns>
        public override List<Point> GetMovablePoints(Board boardState)
        {
            List<Point> points = new List<Point>();
            
            for (int i = 0; i < 4; i++)
            {
                if(i % 2 == 0)
                {
                    int dir = i - 1;
                    Point p = new Point(location.X + 1 * dir, location.Y);
                    if(p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8 )
                    {
                        if (boardState.board[p.X, p.Y] == null || (boardState.board[p.X, p.Y] != null && boardState.board[p.X, p.Y].IsBlack != IsBlack))
                            points.Add(p);
                    }
                } else
                {
                    int dir = i - 2;
                    Point p = new Point(location.X, location.Y + 1 * dir);
                    if (p.X >= 0 && p.X < 8 && p.Y >= 0 && p.Y < 8)
                    {
                        if (boardState.board[p.X, p.Y] == null || (boardState.board[p.X, p.Y] != null && boardState.board[p.X, p.Y].IsBlack != IsBlack))
                            points.Add(p);
                    }
                }
            }
            return points;
        }
    }

}
