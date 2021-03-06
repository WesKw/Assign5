/**
 * Authors: Wesley Kwiecinski - Z1896564, Ojas DhiYogi - Z1849680
 * CSCI 473 Assignment 5
 * Due 4/14/2022
 * 
 * Player class. Handles creating the pieces of the board and removing them when necessary
 * 
 * Wesley was responsible for this class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
    internal class Player : IDisposable
    {
        private int killCount = 0; //how many pieces the player has taken out
        public int deadPieces = 0;
        private List<Piece> pieces = null;
        private Piece king;

        /// <summary>
        /// Gets the list of pieces in the game
        /// </summary>
        public List<Piece> Pieces
        {
            get => pieces;
        }

        /// <summary>
        /// Stores a constant reference to the king for ease of access.
        /// </summary>
        public Piece King
        {
            get => king;
        }

        public int KillCount
        {
            get => killCount;
            set => killCount += value;
        }

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="turn">Refers to if it's the player's turn when the game starts.
        ///                    True => White, False => black</param>
        public Player(bool turn = false)
        {
            pieces = new List<Piece>(16);

            if(turn)    //white piece
            {
                //Add 8 pawns to bottom
                for (int i = 0; i < 8; i++)
                {
                    Pawn p = new Pawn(i, 6, turn, Chess.pawnImgW);
                    pieces.Add(p);
                }

                //Add 2 rooks on the side
                Rook r = new Rook(0, 7, turn, Chess.rookImgW);
                Rook r1 = new Rook(7, 7, turn, Chess.rookImgW);
                pieces.Add(r);
                pieces.Add(r1);

                //Add the knights
                Knight k = new Knight(1, 7, turn, Chess.knightImgW);
                Knight k1 = new Knight(6, 7, turn, Chess.knightImgW);
                pieces.Add(k);
                pieces.Add(k1);

                //Add the bishops
                Bishop b = new Bishop(2, 7, turn, Chess.bishopImgW);
                Bishop b1 = new Bishop(5, 7, turn, Chess.bishopImgW);
                pieces.Add(b);
                pieces.Add(b1);

                //Add the king & queen
                King king = new King(4, 7, turn, Chess.kingImgW);
                Queen queen =  new Queen(3, 7, turn, Chess.queenImgW);
                pieces.Add(king);
                this.king = king;
                pieces.Add(queen);

            } else //black piece
            {
                //Add 8 pawns to top
                for(int i = 0; i < 8; i++)
                {
                    Pawn p = new Pawn(i, 1, turn, Chess.pawnImgB);
                    pieces.Add(p);
                }

                //Add 2 rooks on the side
                Rook r = new Rook(0, 0, turn, Chess.rookImgB);
                Rook r1 = new Rook(7, 0, turn, Chess.rookImgB);
                pieces.Add(r);
                pieces.Add(r1);

                //Add the knights
                Knight k = new Knight(1, 0, turn, Chess.knightImgB);
                Knight k1 = new Knight(6, 0, turn, Chess.knightImgB);
                pieces.Add(k);
                pieces.Add(k1);

                //Add the bishops
                Bishop b = new Bishop(2, 0, turn, Chess.bishopImgB);
                Bishop b1 = new Bishop(5, 0, turn, Chess.bishopImgB);
                pieces.Add(b);
                pieces.Add(b1);

                //Add the king & queen
                King king = new King(4, 0, turn, Chess.kingImgB);
                Queen queen = new Queen(3, 0, turn, Chess.queenImgB);
                pieces.Add(king);
                this.king = king;
                pieces.Add(queen);
            }
        }

        /// <summary>
        /// Removes a piece in the event that piece collide
        /// </summary>
        /// <param name="piece"></param>
        public void RemovePiece(Piece piece)
        {
            if(pieces.Contains(piece))
            {
                pieces.Remove(piece);
            }
        }

        /// <summary>
        /// Dispose every piece and clear the 
        /// </summary>
        public void Dispose()
        {
            foreach(Piece p in pieces)
                p.Dispose();
            pieces.Clear();
        }
    }
}
