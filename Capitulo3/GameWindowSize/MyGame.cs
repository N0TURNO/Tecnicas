using BookExample;
using GameWindowSize.GraphicsSupport;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWindowSize
{
    class MyGame
    {
        // Hero stuff
        TexturedPrimitive mHero;
        Vector2 kHeroSize = new Vector2(15, 15);
        Vector2 kHeroPosition = new Vector2(20,30);

        // Basketballs stuff
        List<BasketBall> mBBallList;
        TimeSpan mCreationTimeStamp;
        int mTotalBBallCreated = 0;
        // this is 0.5 seconds
        const int kBballMSecInterval = 500;

        // Game state
        int mScore = 0;
        int mBBallMissed = 0, mBBallHit = 0;
        const int kBballTouchScore = 1;
        const int kBballMissedScore = -2;
        const int kWinScore = 10;
        const int kLossScore = -10;
        TexturedPrimitive mFinal = null;
        // Work with TexturedPrimitive
        TexturedPrimitive mBall, mUWBLogo;
        TexturedPrimitive mWorkPrim;

        ///*Inicializar o personagem com uma certa textura,posição e tamanho*/
        //public MyGame()
        //{
        //    // Hero ...
        //    mHero = new TexturedPrimitive("Me", kHeroPosition, kHeroSize);
        //    // Basketballs
        //    mCreationTimeStamp = new TimeSpan(0);
        //    mBBallList = new List<BasketBall>();
        //}
        public MyGame()
        {
            // Create the primitives
            mBall = new TexturedPrimitive("Soccer",
            new Vector2(30, 30), new Vector2(10, 15));
            mUWBLogo = new TexturedPrimitive("UWB-JPG",
            new Vector2(60, 30), new Vector2(20, 20));
            mWorkPrim = mBall;
        }

        public void UpdateGame(GameTime gameTime)
        {
            //    /*Verifica se o jogo chegou ao final*/
            //    #region Step a.
            //    if (null != mFinal) // Done!!
            //        return;
            //    #endregion Step a.

            //    /*Remove as bolas que explodiram e atualiza o score*/
            //    #region Step b.
            //    // Hero movement: right thumb stick
            //    mHero.Update(InputWrapper.ThumbSticks.Right, InputWrapper.ThumbSticks.Left);
            //    // Basketball ...
            //    for (int b = mBBallList.Count - 1; b >= 0; b--)
            //    {
            //        if (mBBallList[b].UpdateAndExplode())
            //        {
            //            mBBallList.RemoveAt(b);
            //            mBBallMissed++;
            //            mScore += kBballMissedScore;
            //        }
            //    }
            //    #endregion Step b.

            //    /*Remove as bolas que foram tocadas pela personagem e atualiza o score*/
            //    #region Step c.
            //    for (int b = mBBallList.Count - 1; b >= 0; b--)
            //    {
            //        if (mHero.PrimitivesTouches(mBBallList[b]))
            //        {
            //            mBBallList.RemoveAt(b);
            //            mBBallHit++;
            //            mScore += kBballTouchScore;
            //        }
            //    }
            //    #endregion Step c.

            //    /*Dá spawn de novos inimigos*/
            //    #region Step d.
            //    // Check for new basketball condition
            //    TimeSpan timePassed = gameTime.TotalGameTime;
            //    timePassed = timePassed.Subtract(mCreationTimeStamp);
            //    if (timePassed.TotalMilliseconds > kBballMSecInterval)
            //    {
            //        mCreationTimeStamp = gameTime.TotalGameTime;
            //        BasketBall b = new BasketBall();
            //        mTotalBBallCreated++;
            //        mBBallList.Add(b);
            //    }
            //    #endregion Step d.

            //    /*Verifica se ganhou ou perdeu*/
            //    #region Step e.
            //    // Check for winning condition ...
            //    if (mScore > kWinScore)
            //        mFinal = new TexturedPrimitive("Winner",
            //        new Vector2(75, 50), new Vector2(30, 20));
            //    else if (mScore < kLossScore)
            //        mFinal = new TexturedPrimitive("Looser",
            //        new Vector2(75, 50), new Vector2(30, 20));
            //    #endregion Step e.
            //}
            /*Desenha o personagem e as bolas de basket*/

            #region Select which primitive to work on
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
                mWorkPrim = mBall;
            else if (InputWrapper.Buttons.B == ButtonState.Pressed)
                mWorkPrim = mUWBLogo;
            #endregion
            #region Update the work primitive
            float rotation = 0;
            if (InputWrapper.Buttons.X == ButtonState.Pressed)
                rotation = MathHelper.ToRadians(1f); // 1 degree pre-press
            else if (InputWrapper.Buttons.Y == ButtonState.Pressed)
                rotation = MathHelper.ToRadians(-1f); // 1 degree pre-press
            mWorkPrim.Update(
            InputWrapper.ThumbSticks.Left,
            InputWrapper.ThumbSticks.Right,
            rotation);
            #endregion
        }

       
        public void DrawGame()
        {
            //mHero.Draw();
            //foreach (BasketBall b in mBBallList)
            //    b.Draw();
            //if (null != mFinal)
            //    mFinal.Draw();
            //// Drawn last to always show up on top
            //FontSupport.PrintStatus("Status: " +
            //"Score=" + mScore +
            //" Basketball: Generated( " + mTotalBBallCreated +
            //") Collected(" + mBBallHit + ") Missed(" + mBBallMissed + ")",
            //null);
            mBall.Draw();
            FontSupport.PrintStatusAt(
mBall.mPosition,
mBall.RoateAngleInRadian.ToString(),
Color.Red);
            mUWBLogo.Draw();
            FontSupport.PrintStatusAt(
            mUWBLogo.mPosition,
            mUWBLogo.Position.ToString(),
            Color.Black);
            FontSupport.PrintStatus(
            "A-Soccer B-Logo LeftThumb:Move RightThumb:Scale X/Y:Rotate",
            null);
        }
    }
    }

