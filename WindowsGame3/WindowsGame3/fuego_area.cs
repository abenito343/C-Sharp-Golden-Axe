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
    class fuego_area
    {
        int timer;
        enemigo_animacion anim;
        Vector2 posicion;
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
        public fuego_area(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            anim = new enemigo_animacion(Content, "Imagenes/Boss3/green_fire2", 7, 35, 364 / 7, posicion);
        }
        public void estado(GameTime gameTime)
        {
            timer++;
            if (timer <= 400)
            {
                anim.animacion_enemigo(gameTime, posicion);
            }
            else
            {
                anim.animacion_fuego_final(gameTime, posicion);
            }


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
        }
    }
}
