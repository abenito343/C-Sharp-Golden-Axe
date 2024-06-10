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
    class enemigoC
    {
        enemigo_animacion right,
            anim;
       
        enum state { izquierda, derecha };
        Vector2 posicion;
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }

      public enemigoC(ContentManager Content, int numenemigo, Vector2 posicion)
      {
          Random x = new Random();
          this.posicion = posicion;
          right = new enemigo_animacion(Content, "Imagenes/esqueleto/esqueleto", 3, 62, 163 / 3, posicion);
          anim = right;       
      }
      public void Colision1(GameTime gametime)
      {
         
          posicion.X -= 3;
      }
      public void Colision2(GameTime gametime)
      {
         
          posicion.X += 3;
      }
      public void kh(GameTime gameTime)
      {

          anim = right;
          posicion.X -= 3;
          right.animacion_enemigo(gameTime, posicion);
      }
        
        public void Draw (SpriteBatch spriteBatch)
        {
            
            anim.Draw(spriteBatch);
          
        }
    }
}
