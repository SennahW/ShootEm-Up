using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace ShootEm_Up
{
    public enum TileType { Solid, Gas};

    class TileMap
    {
        Texture2D myTextureTile1;
        Texture2D myTextureTile2;
        Texture2D myTextureTile3;
        Texture2D myTextureTile4;
        Texture2D myTextureTile5;
        Texture2D myTextureTile6;

        //Make 2d array of int that produces map

        int[,] myDesignMapLevelOne = {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0 }, 
            { 1, 1, 1, 1, 1 }, 
            { 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0 } };
        Tile[,] myMapLevelOne = {
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null },
            { null, null, null, null, null }, };

        public TileMap(Texture2D aTileOne, Texture2D aTileTwo, Texture2D aTileThree, Texture2D aTileFour, Texture2D aTileFive, Texture2D aTileSix)
        {
            myTextureTile1 = aTileOne;
            myTextureTile2 = aTileTwo;
            myTextureTile3 = aTileThree;
            myTextureTile4 = aTileFour;
            myTextureTile5 = aTileFive;
            myTextureTile6 = aTileSix;
        }

        public void Initialize()
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (myDesignMapLevelOne[y, x] == 0)
                    {
                        myMapLevelOne[y, x] = new Tile(myTextureTile1, TileType.Gas, new Vector2(0 + x * 128, 0 + y * 128));
                    }
                    else if (myDesignMapLevelOne[y, x] == 1)
                    {
                        myMapLevelOne[y, x] = new Tile(myTextureTile2, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128));
                    }
                    else if (myDesignMapLevelOne[y, x] == 2)
                    {
                        myMapLevelOne[y, x] = new Tile(myTextureTile3, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128));
                    }
                    else if (myDesignMapLevelOne[y, x] == 3)
                    {
                        myMapLevelOne[y, x] = new Tile(myTextureTile4, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128));
                    }
                    else if (myDesignMapLevelOne[y, x] == 4)
                    {
                        myMapLevelOne[y, x] = new Tile(myTextureTile5, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128));
                    }
                    else if (myDesignMapLevelOne[y, x] == 5)
                    {
                        myMapLevelOne[y, x] = new Tile(myTextureTile6, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128));
                    }

                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    myMapLevelOne[y, x].Draw(spriteBatch);
                }
            }
        }
    }
}
