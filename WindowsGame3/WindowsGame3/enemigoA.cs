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
    class enemigoA
    {
        enemigo_animacion right, left, anim;
        int finalY;
        int finaly;
        enum state { izquierda, derecha };
        Vector2 posicion;
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
      public enemigoA(ContentManager Content, int numenemigo, Vector2 posicion)
      {
          Random x = new Random();
          finalY = x.Next(20, 60);
          finaly = x.Next(30, 100);
          this.posicion = posicion;
          right = new enemigo_animacion(Content, "Imagenes/enemigo2", 3, 37, 149 / 3, posicion);
          left = new enemigo_animacion(Content, "Imagenes/enemigo2(1)", 3, 37, 149 / 3, posicion);
          anim = right;
         
          

      }
      public void Colision1(GameTime gametime)
      {
          posicion.X -= 10;
      }
      public void Colision2(GameTime gametime)
      {
          posicion.X += 10;
      }
      public void Right(GameTime gameTime)
      {

          if (posicion.X != 0 && anim == right)
          {
              right.animacion_enemigo(gameTime, posicion);
              anim = right;
              posicion.X -= 10;        
          }
          else if (posicion.X >= 785)
          {

              right.animacion_enemigo(gameTime, posicion);
              posicion.X -= 10;
              anim = right;
          }
          else
          {
              anim = left;
              posicion.X += 10;
              left.animacion_enemigo(gameTime, posicion);
          }
          if (posicion.X == 0)
          {
              posicion.Y += finalY;
          }
          else if (posicion.X == 785)
          {
              posicion.Y -= finaly;
          }
          if (posicion.Y < 0)
          {
              posicion.Y = 50;
          }
          else if (posicion.Y > 180)
          {
              posicion.Y = 50;
          }

      }
    
        public void Draw (SpriteBatch spriteBatch)
        {
            
            anim.Draw(spriteBatch);
          
        }
    }
}
