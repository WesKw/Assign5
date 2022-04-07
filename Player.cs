using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
    internal class Player
    {
        public bool theirTurn = false;
        public int deadPieces = 0;
        public List<Piece> pieces = null;

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="turn">Refers to if it's the player's turn when the game starts.
        ///                    True => White, False => black</param>
        public Player(bool turn = false)
        {
            theirTurn = turn;
            pieces = new List<Piece>(16);

            if(turn)
            {
                //Add 8 pawns to bottom
                for (int i = 0; i < 8; i++)
                {
                    Pawn p = new Pawn(i, 6, turn);
                    pieces.Add(p);
                }
            } else
            {
                //Add 8 pawns to top
                for(int i = 0; i < 8; i++)
                {
                    Pawn p = new Pawn(i, 1, turn);
                    pieces.Add(p);
                }
            }
        }
    }
}
