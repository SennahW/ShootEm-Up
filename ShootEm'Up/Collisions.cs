using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ShootEm_Up
{
    class Collisions
    {
        bool myPlayerIsGrounded = false;
        public void Update (GameTime gameTime, Player aPlayer, Tile[,] aTileArray)
        {
            PlatformCollsion(aPlayer, aTileArray);
        }

        public void PlatformCollsion (Player aPlayer, Tile[,] aTileArray)
        { 
            myPlayerIsGrounded = false;

            for (int y = 0; y < aTileArray.GetLength(0); y++)
            {
                for (int x = 0; x < aTileArray.GetLength(1); x++)
                {
                    if (aTileArray[y,x].AccessTileType == TileType.Solid)
                    {

                        if (aTileArray[y, x].AccessFloat != 17f)
                        {
                            if (aPlayer.AccessRectangle.Intersects(aTileArray[y,x].AccessRectangle))
                            {
                                
                                aPlayer.AccessVelocity = new Vector2(aPlayer.AccessVelocity.X, 0);
                                myPlayerIsGrounded = true;
                            }
                        }
                    }
                    if (myPlayerIsGrounded == true)
                    {
                        //if (aPlayer.AccessRectangle.Left < aTileArray[y, x].AccessRectangle.Right)
                        //{
                        //    aPlayer.AccessPosition = new Vector2(aTileArray[y, x].AccessRectangle.Right, aPlayer.AccessPosition.Y);
                        //}
                    }
                }
            }

            if (myPlayerIsGrounded == false)
            {
                aPlayer.AccessVelocity += new Vector2(0, 4);
            }

        }

        public bool AccessGroundBool { get => myPlayerIsGrounded; set => myPlayerIsGrounded = value; }

    }
}
