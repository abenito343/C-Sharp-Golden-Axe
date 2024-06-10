
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
    class Mago
    {
        Vector2 posicion;
        Disparo disparo;
        BoundingBox bgolden8, bgolden,bgolden2;
        int contador = 0;
        int vida1 = 0;
        int vida2 = 250;
        int vida3 = 0;
        public Vector2 Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
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
        public int Vida3
        {
            get { return this.vida3; }
            set { this.vida3 = value; }
        }
        public int Vida2
        {
            get { return this.vida2; }
            set { this.vida2 = value; }
        }

        int time;
        int tiempo;
        int count = 0;
        List<Disparo> listaDisparo = new List<Disparo>();
        enemigo_animacion right, left, anim, down, up;
        public Mago(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            right = new enemigo_animacion(Content, "Imagenes/Mago/mago_walk(2)", 4, 45, 125 / 4, posicion);
            left = new enemigo_animacion(Content, "Imagenes/Mago/mago_walk", 4, 45, 125 / 4, posicion);
            down = new enemigo_animacion(Content, "Imagenes/Mago/mago_walk(2)", 4, 45, 125 / 4, posicion);
            up = new enemigo_animacion(Content, "Imagenes/Mago/mago_walk", 4, 45, 125 / 4, posicion);
            anim = left;
        }

        public void Colision1(GameTime gametime)
        {
            posicion.X -= 1;
        }
        public void Colision2(GameTime gametime)
        {
            posicion.X += 1;
        }
        public void Right(GameTime gameTime)
        {
            

            contador++;
            if (contador > 250)
            {
                if (anim == left && posicion.X > 605)
                {
                    posicion.X--;
                    left.animacion_enemigo(gameTime, posicion);
                }
            }
        }
        public void Disparo(GameTime gameTime, ContentManager Content)
        {

            if (posicion.X == 605)
            {
                time++;
                if (time == 350)
                {
                    if (count < 500)
                        disparo = new Disparo(Content, "Imagenes/Mago/mago_disparo", 4, 45, 240 / 4, posicion);
                    listaDisparo.Add(disparo);
                    time = 0;
                    tiempo = 0;
                }
                foreach (Disparo cl in listaDisparo)
                {
                    cl.animacion_disparo(gameTime);
                    bgolden8 = new BoundingBox(new Vector3(cl.Posicion.X, cl.Posicion.Y, 0), new Vector3(cl.Posicion.X + 30, cl.Posicion.Y + 20, 0));
                    if (bgolden.Intersects(bgolden8))
                    {

                        listaDisparo.Remove(cl);
                        vida1 = 1;


                        break;
                    }
                    if (bgolden2.Intersects(bgolden8))
                    {

                        listaDisparo.Remove(cl);
                        vida3 = 1;


                        break;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Disparo cl in listaDisparo)
            {
                cl.Draw(spriteBatch);
            }
            anim.Draw(spriteBatch);

        }
    }
}