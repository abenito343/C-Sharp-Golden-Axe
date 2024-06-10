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
    class Dragon_stage5
    {
        enemigo_animacion right, left, anim;
        int fire;
        Fuego explosion;
        BoundingBox bgolden8, bgolden,bgolden2;
        List<Disparo> listaDisparo = new List<Disparo>();
        List<Fuego> listaFuego = new List<Fuego>();
        int timer;
        int vida1;
        int vida2;
        Vector2 posicion, posicion_fuego;
        public BoundingBox Bgolden
        {
            get { return this.bgolden; }
            set { this.bgolden = value; }
        }
        public BoundingBox Bgolden2
        {
            get { return this.bgolden2; }
            set { this.bgolden2 = value; }
        }

        public int Vida1
        {
            get { return this.vida1; }
            set { this.vida1 = value; }
        }
        public int Vida2
        {
            get { return this.vida2; }
            set { this.vida2 = value; }
        }

        public Dragon_stage5(ContentManager Content, Vector2 posicion)
        {

            this.posicion = posicion;
            right = new enemigo_animacion(Content, "Imagenes/Boss3/Dragon2", 5, 140, 823 / 5, posicion);
            left = new enemigo_animacion(Content, "Imagenes/Boss3/Dragon2(1)", 5, 140, 823 / 5, posicion);


            anim = left;

        }
        public void movimientos(GameTime gameTime)
        {
            if (anim == left)
            {
                posicion.X -= 3;
                left.animacion_enemigo_ataque(gameTime, posicion);
            }
            if (anim == right)
            {
                posicion.X += 3;
                right.animacion_enemigo_ataque(gameTime, posicion);
            }
            if (posicion.X >= 700)
            {
                left.Posicion = posicion;
                anim = left;
            }
            if (posicion.X <= 0)
            {
                right.Posicion = posicion;
                anim = right;
            }
        }
        public void Fuego(GameTime gameTime, ContentManager Content)
        {

            if (anim == right)
            {
                posicion_fuego = new Vector2(posicion.X + 145, posicion.Y + 430);
            }
            if (anim == left)
            {
                posicion_fuego = new Vector2(posicion.X, posicion.Y + 430);
            }


            if (posicion.X <= 800)
            {
                timer++;
                if (timer >= 125)
                {
                    if (fire < 500000)
                    {
                        explosion = new Fuego(Content, fire++,2, posicion_fuego);
                        listaFuego.Add(explosion);
                        timer = 0;
                    }
                }
            }
            foreach (Fuego Boom in listaFuego)
            {
                Boom.caida(gameTime);
                Boom.stand(gameTime);
                Boom.boom(gameTime);
                bgolden8 = new BoundingBox(new Vector3(Boom.Pos.X, Boom.Pos.Y -375, 0), new Vector3(Boom.Pos.X + 30, Boom.Pos.Y  -355, 0));
                if (bgolden.Intersects(bgolden8))
                {
                    listaFuego.Remove(Boom);
                    vida1 = 1;

                    break;
                }
                if (bgolden2.Intersects(bgolden8))
                {
                    listaFuego.Remove(Boom);
                    vida2 = 1;

                    break;
                }


            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
            foreach (Fuego Boom in listaFuego)
            {
                Boom.Draw(spriteBatch);
            }

        }
    }
}

