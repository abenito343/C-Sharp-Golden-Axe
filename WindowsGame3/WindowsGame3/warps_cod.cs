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
    class warps_cod
    {
        warps vacio;
        int timer;
        int contador = 250;
        Vector2 posicion;
        public warps_cod(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            vacio = new warps(Content, "Imagenes/warps", 10, 100, 400 / 10, posicion);
        }
        public void vacio_timer(GameTime gameTime)
        {

            timer++;
            if (timer < contador)
            {
                vacio.animacion_vortice(gameTime);
            }
            else
            {
                vacio.animacion_vortice2(gameTime);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            vacio.Draw(spriteBatch);
        }
    }
}
