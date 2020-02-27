using Microsoft.Xna.Framework;

namespace ShootEm_Up
{
    class Camera
    {
        public Matrix myTransform { get; private set; }

        public void Update (Vector2 aPositionToFollow, float ScreenWidth, float ScreenHeight)
        {
            Matrix tempPosition;

            if (-aPositionToFollow.X <= -ScreenWidth / 2 )
            {
                tempPosition = Matrix.CreateTranslation(-aPositionToFollow.X, -ScreenHeight / 2, 0);
            }
            else
            {
                 tempPosition = Matrix.CreateTranslation(-ScreenWidth / 2, -ScreenHeight / 2, 0);
            }

            Matrix tempOffset = Matrix.CreateTranslation(ScreenWidth / 2, ScreenHeight / 2, 0);

            myTransform = tempOffset * tempPosition ;

        }
    }
}
