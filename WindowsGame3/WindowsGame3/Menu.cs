using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace WindowsGame3
{
    class Menu
    {
        Texture2D textura;
        Vector2 posicion;
        Rectangle rectangulo;
        Color color = new Color (0,0,0,0);
        public Vector2 Size;
        public Menu(Texture2D texture, GraphicsDevice graphics)
        {
            textura = texture  ;
            Size = new Vector2(155, 35);
        }
        bool abajo;
        public bool Click;
        public void Update(MouseState Mouse)
        {
            rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, (int)Size.X, (int)Size.Y);
            Rectangle rectangulomouse = new Rectangle(Mouse.X,Mouse.Y,1,1);
            if (rectangulomouse.Intersects(rectangulo))
            {
                
                if (color.A == 126) abajo = false;
                if(color.A == 0)abajo= true;
                if (abajo) color.A += 3; else color.A -= 3;
                if (Mouse.LeftButton == ButtonState.Pressed) Click = true;
            }
            else if(color.A < 126)
            {
                color.A += 3;
                Click = false;
            }
        }
            public void setposition(Vector2 posicion2)
            {
                posicion = posicion2;
            }
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(textura, rectangulo, color);
            }
        }
        
    }

