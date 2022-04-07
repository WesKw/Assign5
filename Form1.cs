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
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        Board b;
        Point lastClicked = new Point(-1, -1);
        bool initialize = true;

        Player player1 = null;
        Player player2 = new Player(false);

        public Chess()
        {
            InitializeComponent();

            //Set up board
            b = new Board();
            //Player player1 = new Player(true);  //white goes first
            //Player player2 = new Player(false); //black goes 2nd
            Game.Refresh();

            AllocConsole();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            b.Draw(g, new SolidBrush(Color.White), new SolidBrush(Color.RoyalBlue), new SolidBrush(Color.Yellow), lastClicked, null);
            
            initialize = false;
            foreach(Piece p in player2.pieces)
            {
                p.DrawPiece(g);
            }
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            //get x and y points
            int xLoc = p.X / Board.SQUARE_SIZE;
            int yLoc = p.Y / Board.SQUARE_SIZE;

            lastClicked.X = xLoc;
            lastClicked.Y = yLoc;

            Game.Refresh(); //update the board

            Console.WriteLine(string.Format("{0}, {1}", xLoc, yLoc));
        }
    }
}
