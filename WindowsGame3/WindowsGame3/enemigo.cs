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
    class enemigo
    {

        enemigo_animacion right, left, anim;
        enum state { izquierda, derecha };
        public bool moviendose = false;
        Vector2 posicion;
        float zpospner;
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
        public float Zpospner
        {
            get { return this.zpospner; }
            set { this.zpospner = value; }

        }
        public enemigo(ContentManager Content, int numenemigo, Vector2 posicion, float zpospner)
        {
            this.zpospner = zpospner;
            Random r = new Random();
            this.posicion = posicion;
            right = new enemigo_animacion(Content, "Imagenes/enemigo1", 3, 37, 149 / 3, posicion);
            left = new enemigo_animacion(Content, "Imagenes/enemigo12", 3, 37, 149 / 3, posicion);
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

        public void pospner(float z)
        {
            zpospner = z;
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
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            anim.Draw(spriteBatch);

        }
    }
}
