using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine
{
    public class DDCamera
    {
        public Vector2 Position { get; private set; }
        public float Zoom { get; private set; }
        public float Rotation { get; private set; }
        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }
        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f);
            }
        }
        public Matrix TranslationMatrix 
        {
            get
            {
                return Matrix.CreateTranslation(-(int)Position.X, -(int)Position.Y, 0) * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
            }
        }
        public virtual void Initialize()
        {
            Zoom = 1.0f;
            ViewportWidth = (int)DDGame.Instance.Dimensions.X;
            ViewportHeight = (int)DDGame.Instance.Dimensions.Y;
        }
        public void CenterOn(Vector2 position)
        {
            Position = new Vector2(position.X, position.Y);
        }
    }
}
