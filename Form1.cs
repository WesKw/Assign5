﻿/**
 * Authors: Wesley Kwiecinski - Z1896564, Ojas DhiYogi - Z1849680
 * CSCI 473 Assignment 5
 * Due 4/14/2022
 * 
 * Form that handles updating the board and player information, calls draw methods
 * 
 * Wesley and Ojas were responsible for this class.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Assign5
{
    public partial class Chess : Form
    {
        /// <summary>
        /// I would include this in the chess class (and probably should)
        /// but I kept running out of memory trying to instance so many pictures at once
        /// Should save on memory
        /// </summary>
        #region piece_images
        public static Image pawnImgW = Image.FromFile(@".\icons\white\chess-pawn.png");
        public static Image pawnImgB = Image.FromFile(@".\icons\black\chess-pawn.png");

        public static Image rookImgW = Image.FromFile(@".\icons\white\chess-rook.png");
        public static Image rookImgB = Image.FromFile(@".\icons\black\chess-rook.png");

        public static Image knightImgW = Image.FromFile(@".\icons\white\chess-knight.png");
        public static Image knightImgB = Image.FromFile(@".\icons\black\chess-knight.png");

        public static Image bishopImgW = Image.FromFile(@".\icons\white\chess-bishop.png");
        public static Image bishopImgB = Image.FromFile(@".\icons\black\chess-bishop.png");

        public static Image kingImgW = Image.FromFile(@".\icons\white\chess-king.png");
        public static Image kingImgB = Image.FromFile(@".\icons\black\chess-king.png");

        public static Image queenImgW = Image.FromFile(@".\icons\white\chess-queen.png");
        public static Image queenImgB = Image.FromFile(@".\icons\black\chess-queen.png");
        #endregion

        //console stuff
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        bool check = false;
        Board b;
        Point lastClicked = new Point(-1, -1);
        Piece lastSelected = null;

        Player player1 = null;// new Player(true);
        Player player2 = null;// new Player(false);
        Player currentPlayer = null;

        uint moveCounter = 0;
        uint p1killCount = 0;
        uint p2killCount = 0;
        public static System.Windows.Forms.Timer myTimer;
        public static int tcounter = 0;

        public Chess()
        {
            InitializeComponent();
            AllocConsole();
            ResetGame();
        }

        private void ResetGame()
        {
            player1 = new Player(true);
            player2 = new Player(false);

            //Set up board
            b = new Board();
            
            //place pieces on board
            foreach (Piece p in player1.Pieces)
            {
                b.board[p.location.X, p.location.Y] = p;
            }

            //place pieces on board
            foreach (Piece p in player2.Pieces)
            {
                b.board[p.location.X, p.location.Y] = p;
            }

            currentPlayer = player1;

            CurrentPlayerLabel.Text = "Current Turn: White";
            CheckmateLabel.Text = "";

            myTimer = new System.Windows.Forms.Timer(); // Interval set to 1 second

            myTimer.Interval = 1000; // measured in milliseconds
            myTimer.Tick += new EventHandler(UpdateLabel);
            myTimer.Start();

            Game.Refresh();
        }

        /// <summary>
        /// Redraws the game canvas. Player pieces always go on the topmost layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using(Brush w = new SolidBrush(Color.White))
            using(Brush rb = new SolidBrush(Color.RoyalBlue))
            using(Brush y = new SolidBrush(Color.Yellow))
            {
                b.Draw(g, w, rb, y, lastClicked);
            }
           
            foreach (Piece p in player1.Pieces)  //draw player1 pieces
            {
                p.DrawPiece(g);
            }

            foreach (Piece p in player2.Pieces)  //draw player2 pieces
            {
                p.DrawPiece(g);
            }
        }

        /// <summary>
        /// Determines which piece has been clicked, and the action to take
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            //get x and y points
            int xLoc = p.X / Board.SQUARE_SIZE;
            int yLoc = p.Y / Board.SQUARE_SIZE;

            if (lastSelected != null && b.PossiblePoints != null)   //we want to do something if a piece was selected
            {
                Player otherPlayer = currentPlayer == player1 ? player2 : player1;
                bool moved = false;
                //check if the desired point is in our list of points
                foreach(Point point in b.PossiblePoints)
                {
                    if(point.X == xLoc && point.Y == yLoc)  //if the possible point matches the desired location
                    {
                        Piece piece = b.board[lastClicked.X, lastClicked.Y];
                        Piece othersPiece = b.board[xLoc, yLoc];
                        bool killedPiece = false;

                        //piece collision, not-current-turn player loses their piece
                        if (othersPiece != null && !currentPlayer.Pieces.Contains(othersPiece))
                        {
                            b.board[xLoc, yLoc].MoveTo(-10, -10);   //move piece "off of the board"
                            b.board[xLoc, yLoc] = null; //set the spot to null
                            killedPiece = true; //piece is temporarilly killed
                        }

                        piece.MoveTo(xLoc, yLoc);   //update piece location internally
                        b.board[xLoc, yLoc] = piece;//update location on the board
                        b.board[lastClicked.X, lastClicked.Y] = null;   //remove the piece in the last location

                        //if the king is vulnerable at the new location we need to reset the pieces
                        if (IsCheck(otherPlayer))
                        {
                            b.board[lastClicked.X, lastClicked.Y] = piece;
                            piece.MoveTo(lastClicked.X, lastClicked.Y);

                            if (othersPiece != null)    //if a piece was going to be killed
                            {
                                b.board[xLoc, yLoc] = othersPiece;
                                b.board[xLoc, yLoc].MoveTo(xLoc, yLoc);
                                killedPiece = false;
                            }
                            
                            feedbackBox.Text = "This king is vulnerable!";
                            ResetSelection();
                            return;
                        }

                        moved = true;

                        //if the king is not vulnerable and a piece has been killed we 
                        //can safely remove it from the board
                        if (killedPiece)
                            otherPlayer.Pieces.Remove(othersPiece);

                        break;  //exit the loop
                    }
                }

                ResetSelection();

                if (!moved)
                {
                    feedbackBox.Text = "This spot isn't valid";
                    return; //if we didn't move at all, the game state doesn't change
                }
                moveCounter += 1;

                currentPlayer = otherPlayer;   //only update the current player if a piece moves
                CurrentPlayerLabel.Text = currentPlayer == player1 ? "Current Turn: White" : "Current Turn: Black";

                //if successfully moved, need to check if the move results in a check for the new player
                if (IsCheck(otherPlayer))
                {
                    
                    check = true;
                    CheckmateLabel.Text = "Check";  //update the check label to indicate the check

                    if (IsCheckmate())
                    {
                        EndGame();
                        return;
                    }
                }
                else
                {
                    check = false;
                    feedbackBox.Text = "There is no checkmate";
                    CheckmateLabel.Text = "";
                }
            } else
            {
                lastClicked.X = xLoc;
                lastClicked.Y = yLoc;

                //There is a piece here
                if (b.board[xLoc, yLoc] != null && currentPlayer.Pieces.Contains(b.board[xLoc, yLoc]))
                {
                    b.PossiblePoints = b.board[xLoc, yLoc].GetMovablePoints(b);
                    lastSelected = b.board[xLoc, yLoc];
                }
                else
                {
                    b.PossiblePoints = null;
                    lastSelected = null;
                }

                Game.Refresh(); //update the board
            }
        }

        //Checks if the player's king would be in attacking range at the new point
        /// <summary>
        /// Checks if moving a piece exposes the current player's king to an attack
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsCheck(Player otherPlayer)
        {
            Console.WriteLine(String.Format("Check if otherplayer can attack {0} king", currentPlayer.King.IsBlack ? "black" : "white"));
            //check if any pieces on the other side can attack the king at the new piece point
            foreach(Piece p in otherPlayer.Pieces)
            {
                List<Point> points = p.GetMovablePoints(b);
                if(points != null)
                {
                    foreach (Point pt in points)
                    {
                        if (pt.X == currentPlayer.King.location.X && pt.Y == currentPlayer.King.location.Y)  //if one of the attacking points includes the king
                        {
                            return true;    //then check if it's a checkmate?
                        }
                    }
                }
            }

            return false;
        }

        public void Leaderboard()
        {

        }
        private bool IsCheckmate()
        {
            return false;
        }

        private void EndGame()
        {

        }

        private void ResetSelection()
        {
            lastSelected = null;
            b.PossiblePoints = null;
            lastClicked.X = -1; //reset last clicked
            lastClicked.Y = -1;
            Game.Refresh();
        }

        public void Timer()
        {
            InitializeComponent();

            myTimer = new System.Windows.Forms.Timer(); // Interval set to 10 seconds

            myTimer.Enabled = true;
            myTimer.Interval = 1000; // measured in milliseconds
            myTimer.Tick += new EventHandler(UpdateLabel);

        }

        private void UpdateLabel(object source, EventArgs args)
        {
            tcounter++;
            int minutes = (tcounter / 60000);
            Time_Label.Text = string.Format("{0:00}:{1:00}", minutes, tcounter);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myTimer.Dispose();
        }
    }
}
