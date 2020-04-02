using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ShootEm_Up
{
    class TileGround : Tile
    {
        public TileGround(Texture2D aTexture, TileType aTileType, Vector2 aPosistion, float aTileID)
        {
            myTexture = aTexture;
            myTileType = aTileType; 
            myPosition = aPosistion;
            myRectangle = new Rectangle(Convert.ToInt32(myPosition.X), Convert.ToInt32(myPosition.Y), myTexture.Width, myTexture.Height);
            myTileID = aTileID;
        }

        public override void Update(Player aPlayer, Tile[,] aTileArray)
        {
            TileCollsion(aPlayer, aTileArray);

        }

        public void TileCollsion(Player aPlayer, Tile[,] aTileArray)
        {
            if (aPlayer.AccessRectangle.Intersects(myRectangle) && aPlayer.AccessRectangle.Bottom < myRectangle.Bottom - 50)
            {
                aPlayer.AccessGroundBool = true;
            }
            for (int i = 0; i < SnowballManager.AccessSnowballList.Count; i++)
            {
                if (SnowballManager.AccessSnowballList[i].AccessSnowballRectangle.Intersects(myRectangle))
                {
                    SnowballManager.RemoveSnowball(i);
                }
            }
        }
    }
}   
