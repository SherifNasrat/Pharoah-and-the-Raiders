﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Maps
{
    class Player
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(64, 384);
        private Vector2 velocity;
        private Rectangle rectangle;
        private bool hasjumped = false;
        public Vector2 Position
        {
            get { return position; }
        }
        public Player() { }
        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Player");

        }
        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            Input(gameTime);
            if (velocity.Y < 10)
                velocity.Y += 0.4f;
         
        }
        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else if (Keyboard.GetState().IsKeyDown(Keys.A)) 
            velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else
            velocity.X = 0f;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasjumped == false)
            {
                position.Y -= 7f;
                velocity.Y = -11f;
                hasjumped = true;
            }
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasjumped = false;
            }
            if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width-2;
            }
            if(rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X+ newRectangle.Width+2;
            }
            if (rectangle.TouchBottomOf(newRectangle))
                velocity.Y = 1f;
            if (position.X < 0)
                position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0)
                velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
