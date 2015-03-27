using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Maps
{
    class Camera
    {
        private Matrix transform; //Defines a Matrix
        public Matrix Transform // Getter for the defined Matrix
        {
            get { return transform; }
        }
        private Vector2 centre; //(X,Y) 
        private Viewport viewport; //Defines the window in which we see everything.
        public Camera(Viewport newViewPort) //Setter for the viewport object.
        {
            viewport = newViewPort;
        }
        public void Update(Vector2 position, int xOffset, int yOffset) //Player.position, map.width, map.height
        {
            if (position.X < viewport.Width / 2)
                centre.X = viewport.Width / 2;
            else if (position.X > xOffset - (viewport.Width / 2))
                centre.X = xOffset - (viewport.Width / 2);
            else
                centre.X = position.X;
            if (position.Y < viewport.Height / 2)
                centre.Y = viewport.Height / 2;
            else if (position.Y > yOffset - (viewport.Height / 2))
                centre.Y = yOffset - (viewport.Height / 2);
            else
                centre.Y = position.Y;
            transform = Matrix.CreateTranslation(new Vector3(-centre.X + (viewport.Width / 2), -centre.Y + (viewport.Height / 2), 0));
        }

    }
    
}
