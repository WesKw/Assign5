using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign5
{
    public partial class Chess : Form
    {
        Board b;

        public Chess()
        {
            InitializeComponent();

            //Set up board
            b = new Board();
            Game.Refresh();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            b.Draw(g, new SolidBrush(Color.White), new SolidBrush(Color.RoyalBlue));
        }
    }
}
