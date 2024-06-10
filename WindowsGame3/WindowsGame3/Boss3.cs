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
    class Boss3
    {
        enemigo_animacion left, attack, anim;
        Vector2 posicion;
        int vida3 = 750;
        int contador;
        int volando = 0;
        public int Vida3
        {
            get { return this.vida3; }
            set { this.vida3 = value; }
        }
        public int Volando
        {
            get { return this.volando; }
            set { this.volando = value; }
        }

        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
        public Boss3(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            left = new enemigo_animacion(Content, "Imagenes/Boss3/death-adder(1)", 3, 71, 230 / 3, posicion);
            attack = new enemigo_animacion(Content, "Imagenes/Boss3/death-adder-attack", 1, 59, 140, posicion);
            anim = left;
        }
        public void Colision1(GameTime gametime)
        {

            posicion.X -= 5;
        }
        public void Colision2(GameTime gametime)
        {

            posicion.X += 5;
        }
        public void movimientos(GameTime gameTime)
        {
            contador++;
            if (anim == left)
            {
                posicion.X -= 2;
                left.animacion_enemigo2(gameTime, posicion);
                volando = 0;
            }
            if (anim == attack)
            {
                posicion.X -= 6;
                attack.animacion_enemigo2(gameTime, posicion);
                volando = 1;
            }
            if (posicion.X >= 700 && anim != attack)
            {
                left.Posicion = posicion;
                anim = left;
            }
            if (posicion.X <= -200)
            {
                posicion.Y = 45;
                posicion.X = 900;
                left.Posicion = posicion;
                anim = left;
            }
            if (contador > 600 && posicion.X == 900)
            {
                posicion.Y = 135;

                anim = attack;
                attack.Posicion = posicion;
            }
            if (contador > 900 && posicion.X == 900)
            {
                posicion.Y = 20;
                anim = attack;
                contador = 0;
                attack.Posicion = posicion;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);

        }
    }
}
