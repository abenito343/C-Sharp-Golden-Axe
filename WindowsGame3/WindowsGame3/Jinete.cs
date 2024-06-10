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
    class Jinete
    {
        enemigo_animacion right, anim;
        Vector2 posicion;
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
        public void Colision1(GameTime gametime)
        {
            posicion.X -= 2;
        }
        public void Colision2(GameTime gametime)
        {
            posicion.X += 2;
        }
        public Jinete(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            right = new enemigo_animacion(Content, "Imagenes/Boss3/jinete", 3, 70, 165 / 3, posicion);
            anim = right;
        }
        public void Right(GameTime gameTime)
        {
            if (anim == right)
            {
                right.animacion_enemigo(gameTime, posicion);
                posicion.X -= 4;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
        }
    }
}
