﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace ShootEm_Up
{
    public enum TileType { Solid, Gas};

    class TileMap
    {
        //Texure declerations
        Texture2D myTextureTile1;
        Texture2D myTextureTile2;
        Texture2D myTextureTile3;
        Texture2D myTextureTile4;
        Texture2D myTextureTile5;
        Texture2D myTextureTile6;
        Texture2D myTextureTile7;
        Texture2D myTextureTile8;
        Texture2D myTextureTile9;
        Texture2D myTextureTile10;
        Texture2D myTextureTile11;
        Texture2D myTextureTile12;
        Texture2D myTextureTile13;
        Texture2D myTextureTile14;
        Texture2D myTextureTile15;
        Texture2D myTextureTile16;
        Texture2D myTextureTile17;
        Texture2D myTextureTile18;

        //Make 2d array of int that produces map
        Tile[,] myMapLevelOne;

        int[,] myDesignMapLevelOne = {
            { 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
            { 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
            { 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
            { 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
            { 17, 17, 17, 17, 17, 17, 17, 13, 14, 14, 15, 17, 17, 17, 17, 17, 17 },
            {  1,  1,  1,  1,  1,  2, 17, 17, 17, 17, 17, 17, 17, 13, 14, 14, 15 },
            {  4,  4,  4,  4,  4,  5, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
            {  4,  4,  4,  4,  4,  5, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
            {  4,  4,  4,  4,  4,  5, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
            {  4,  4,  4,  4,  4,  5, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },};

        public TileMap(Texture2D aTileOne, Texture2D aTileTwo, Texture2D aTileThree, Texture2D aTileFour, Texture2D aTileFive, Texture2D aTileSix, Texture2D aTileSeven, Texture2D aTileEight, Texture2D aTileNine, 
            Texture2D aTileTen, Texture2D aTileEleven, Texture2D aTileTwelve, Texture2D aTileThirteen, Texture2D aTileFourteen, Texture2D aTileFifteen, Texture2D aTileSixteen, Texture2D aTileSeventeen, Texture2D aTileEighteen)
        {
            myTextureTile1 = aTileOne;
            myTextureTile2 = aTileTwo;
            myTextureTile3 = aTileThree;
            myTextureTile4 = aTileFour;
            myTextureTile5 = aTileFive;
            myTextureTile6 = aTileSix;
            myTextureTile7 = aTileSeven;
            myTextureTile8 = aTileEight;
            myTextureTile9 = aTileNine;
            myTextureTile10 = aTileTen;
            myTextureTile11 = aTileEleven;
            myTextureTile12 = aTileTwelve;
            myTextureTile13 = aTileThirteen;
            myTextureTile14 = aTileFourteen;
            myTextureTile15 = aTileFifteen;
            myTextureTile16 = aTileSixteen;
            myTextureTile17 = aTileSeventeen;
            myTextureTile18 = aTileEighteen;
        }

        public void Initialize()
        {
            myMapLevelOne = new Tile[myDesignMapLevelOne.GetLength(0) , myDesignMapLevelOne.GetLength(1)];
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 17; x++)
                {
                    myMapLevelOne[y, x] = null;
                }
            }

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 17; x++)
                {
                    if (myDesignMapLevelOne[y, x] == 0)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile1, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 0);
                    }
                    else if (myDesignMapLevelOne[y, x] == 1)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile2, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 1);
                    }
                    else if (myDesignMapLevelOne[y, x] == 2)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile3, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 2);
                    }
                    else if (myDesignMapLevelOne[y, x] == 3)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile4, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 3);
                    }
                    else if (myDesignMapLevelOne[y, x] == 4)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile5, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 4);
                    }
                    else if (myDesignMapLevelOne[y, x] == 5)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile6, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 5);
                    }
                    else if (myDesignMapLevelOne[y, x] == 6)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile7, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 6);
                    }
                    else if (myDesignMapLevelOne[y, x] == 7)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile8, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 7);
                    }
                    else if (myDesignMapLevelOne[y, x] == 8)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile9, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 8);
                    }
                    else if (myDesignMapLevelOne[y, x] == 9)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile10, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 9);
                    }
                    else if (myDesignMapLevelOne[y, x] == 10)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile11, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 10);
                    }
                    else if (myDesignMapLevelOne[y, x] == 11)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile12, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 11);
                    }
                    else if (myDesignMapLevelOne[y, x] == 12)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile13, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 12);
                    }
                    else if (myDesignMapLevelOne[y, x] == 13)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile14, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 13);
                    }
                    else if (myDesignMapLevelOne[y, x] == 14)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile15, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 14);
                    }
                    else if (myDesignMapLevelOne[y, x] == 15)
                    {
                        myMapLevelOne[y, x] = new TileGround(myTextureTile16, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 15);
                    }
                    else if (myDesignMapLevelOne[y, x] == 16)
                    {
                        myMapLevelOne[y, x] = new TileSolid(myTextureTile17, TileType.Solid, new Vector2(0 + x * 128, 0 + y * 128), 16);
                    }
                    else if (myDesignMapLevelOne[y, x] == 17)
                    {
                        myMapLevelOne[y, x] = new TileAir(myTextureTile18, TileType.Gas, new Vector2(0 + x * 128, 0 + y * 128), 17);
                    }
                }
            }
        }

        public void Update(Player aPlayer)
        {
            for (int i = 0; i < myMapLevelOne.Length; i++)
            {
                Update( aPlayer, myMapLevelOne);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 17; x++)
                {
                    myMapLevelOne[y, x].Draw(spriteBatch);
                }
            }
        }
         
        public Tile[,] AccessMapLevelOne { get => myMapLevelOne; set => myMapLevelOne = value; }
    }
}
