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
    class domo
    {
        enemigo_animacion dom, dominactivo, anim;
        enum state { izquierda, derecha };
        public bool activo = true;
        
        int timer;
        Vector2 posicion;
        int contador = 0;
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }

        public domo(ContentManager Content, Vector2 posicion)
        {
            Random r = new Random();
            this.posicion = posicion;
            dom = new enemigo_animacion(Content, "Imagenes/Mago/domo", 5, 75, 400 / 5, posicion);
            dominactivo = new enemigo_animacion(Content, "Imagenes/Mago/domo_inactivo", 5, 75, 400 / 5, posicion);
            anim = dom;
        }
        public void Domo(GameTime gameTime)
        {
            timer++;
            if (timer < 500)
            {
                activo = true;

            }
            if (timer > 500)
            {
                activo = false;
            }
            if (timer == 750)
            {
                timer = 0;
            }
            if (activo == true)
            {
                dom.animacion_enemigo(gameTime, posicion);
                anim = dom;
            }
            if (activo == false)
            {
                dominactivo.animacion_enemigo(gameTime, posicion);
                anim = dominactivo;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
        }
    }
}
