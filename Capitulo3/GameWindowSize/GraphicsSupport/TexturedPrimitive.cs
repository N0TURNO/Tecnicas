using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameWindowSize;
using GameWindowSize.GraphicsSupport;

namespace GameWindowSize
{
    /// <summary>
    /// TexturedPrimitive class
    /// </summary>
    public class TexturedPrimitive
    {
        // Support for drawing the image
        protected Texture2D mImage;     // The UWB-JPG.jpg image to be loaded
        protected Vector2 mPosition;    // Center position of image
        protected Vector2 mSize;        // Size of the image to be drawn
        internal string Position;
        public Vector2 MinBound { get { return mPosition - (0.5f * mSize); } }
        public Vector2 MaxBound { get { return mPosition + (0.5f * mSize); } }
        protected float mRotateAngle; // In radians, clockwise rotation
        /*è a variavel que guarda o angulo em radianos da rotaçao da imagem no sentido dos ponteiros do relogio*/
        /// <summary>
        /// Constructor of TexturePrimitive
        /// </summary>
        /// <param name="imageName">name of the image to be loaded as texture.</param>
        /// <param name="position">top left pixel position of the texture to be drawn</param>
        /// <param name="size">width/height of the texture to be drawn</param>
        public TexturedPrimitive(String imageName, Vector2 position, Vector2 size)
        {
            mImage = Game1.sContent.Load<Texture2D>(imageName);
            mPosition = position;
            mRotateAngle = 0f;//Iniciar a variavel a zero ou seja sem rotaçao.
            mSize = size;
        }
        public float RotateAngleInRadian//Para modificar o angulo de rotaçao.
        {
            get { return mRotateAngle; }
            set { mRotateAngle = value; }
        }

        public object RoateAngleInRadian { get; internal set; }

        //internal void Update(Vector2 right)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Allows the primitive object to update its state
        /// </summary>
        /// <param name="deltaTranslate">Amount to change the position of the primitive. 
        ///                              Value of 0 says position is not changed.</param>
        /// <param name="deltaScale">Amount to change of the scale the primitive. 
        ///                          Value of 0 says size is not changed.</param>
        public void Update(Vector2 deltaTranslate, Vector2 deltaScale, float deltaAngleInRadian)
        {
            mPosition += deltaTranslate;
            mSize += deltaScale;
            mRotateAngle += deltaAngleInRadian;//delta indica mudança em matematica portanto é esta variavel que modifica o angulo.
        }//a funçao update recebe mais um parametro de forma a fazer o update ao angulo.

        /// <summary>
        /// Draw the primitive
        /// </summary>
       
            virtual public void Draw()
        {
            // Define location and size of the texture
            Rectangle destRect = Camera.ComputePixelRectangle(mPosition, mSize);
            // Define the rotation origin
            Vector2 org = new Vector2(mImage.Width / 2, mImage.Height / 2);//ponto de origem da imagem onde se vai aplicar o angulo de rotaçao.
            // Draw the texture
            Game1.sSpriteBatch.Draw(
            mImage,
            destRect, // Area to be drawn in pixel space
            null,
            Color.White,
            mRotateAngle, // Angle to rotate (clockwise)
            org, // Image reference position
            SpriteEffects.None, 0f);
        }
    

        /*Deteta o toque entre 2 objetos*/
        public bool PrimitivesTouches(TexturedPrimitive otherPrim)
        {
            Vector2 v = mPosition - otherPrim.mPosition;
            float dist = v.Length();
            return (dist < ((mSize.X / 2f) + (otherPrim.mSize.X / 2f)));
        }
       
    }
}
