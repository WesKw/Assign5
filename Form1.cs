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

        Board b;
        Point lastClicked = new Point(-1, -1);
        Piece lastSelected = null;

        Player player1 = new Player(true);
        Player player2 = new Player(false);

        public Chess()
        {
            InitializeComponent();

            //Set up board
            b = new Board();

            //place pieces on board
            foreach(Piece p in player1.pieces)
            {
                b.board[p.location.X, p.location.Y] = p;
            }

            //place pieces on board
            foreach (Piece p in player2.pieces)
            {
                b.board[p.location.X, p.location.Y] = p;
            }

            Game.Refresh();

            AllocConsole();
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
            
            foreach (Piece p in player1.pieces)  //draw player1 pieces
            {
                p.DrawPiece(g);
            }

            foreach (Piece p in player2.pieces)  //draw player2 pieces
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

            lastClicked.X = xLoc;
            lastClicked.Y = yLoc;

            //There is a piece here
            if(b.board[xLoc, yLoc] != null)
            {
                b.PossiblePoints = b.board[xLoc, yLoc].GetMovablePoints(b);
                lastSelected = b.board[xLoc, yLoc];
            } else
            {
                b.PossiblePoints = null;
                lastSelected = null;
            }

            Game.Refresh(); //update the board

            if(b.board[xLoc, yLoc] != null)
                Console.WriteLine(string.Format("Piece: {0}", b.board[xLoc, yLoc].Name));//xLoc, yLoc));
        }
    }
}
