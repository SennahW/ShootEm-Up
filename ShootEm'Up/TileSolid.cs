using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;

namespace ShootEm_Up
{
    class TileSolid : Tile
    {
        public TileSolid(Texture2D aTexture, TileType aTileType, Vector2 aPosistion, float aTileID)
        {
            myTexture = aTexture;
            myTileType = aTileType;
            myPosition = aPosistion;
            myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), myTexture.Width, myTexture.Height);
            myTileID = aTileID;
        }

        public override void Update(Player aPlayer, Tile[,] aTileArray)
        {
            TileCollision(aPlayer, aTileArray);
        }

        public void TileCollision(Player aPlayer, Tile[,] aTileArray)
        {
            if (aPlayer.AccessRectangle.Intersects(myRectangle))
            {
                //Col from left
                if (aPlayer.AccessOldRectangle.Right < myRectangle.Left && aPlayer.AccessRectangle.Right >= myRectangle.Left)
                {
                    aPlayer.AccessPosition = new Vector2(aPlayer.AccessOldRectangle.Left - 40, aPlayer.AccessPosition.Y);
                }
                //Col from right
                if (aPlayer.AccessOldRectangle.Left > myRectangle.Right && aPlayer.AccessRectangle.Left <= myRectangle.Right)
                {
                    aPlayer.AccessPosition = new Vector2(aPlayer.AccessOldRectangle.Right + 40, aPlayer.AccessPosition.Y);
                }
                //Col from top
                if (aPlayer.AccessOldRectangle.Bottom < myRectangle.Top && aPlayer.AccessRectangle.Bottom >= myRectangle.Top)
                {
                    aPlayer.AccessPosition = new Vector2(aPlayer.AccessPosition.X, aPlayer.AccessOldRectangle.Top - 10);
                }
                //Col from bottom 
                if (aPlayer.AccessOldRectangle.Top > myRectangle.Bottom && aPlayer.AccessRectangle.Top <= myRectangle.Bottom)
                {
                    aPlayer.AccessPosition = new Vector2(aPlayer.AccessPosition.X, myRectangle.Bottom);
                }
            }
        }
    }
}