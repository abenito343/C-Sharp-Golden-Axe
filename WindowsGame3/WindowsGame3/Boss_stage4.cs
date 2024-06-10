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
    class Boss_stage4
    {

        int count = 0;
        int time = 0;
        int vida1 = 0;
        int vida2 = 0;
        int vida3 = 500;
        BoundingBox bgolden8, bgolden,bgolden9,bgolden2;
        Disparo disparo;
        List<Disparo> listaDisparo = new List<Disparo>();
        List<Disparo> listaDisparo2 = new List<Disparo>();
        Vector2 posicion, posicion_shoot;
        enemigo_animacion right, left, down, up, anim;
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

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
        public int Vida3
        {
            get { return this.vida3; }
            set { this.vida3 = value; }
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
        public Boss_stage4(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            left = new enemigo_animacion(Content, "Imagenes/Boss2/second_boss", 3, 48, 196 / 3, posicion);
            right = new enemigo_animacion(Content, "Imagenes/Boss2/second_boss(2)", 3, 48, 196 / 3, posicion);
            down = new enemigo_animacion(Content, "Imagenes/Boss2/second_boss(2)", 3, 48, 196 / 3, posicion);
            up = new enemigo_animacion(Content, "Imagenes/Boss2/second_boss", 3, 48, 196 / 3, posicion);
            anim = up;
        }
        public void Right(GameTime gameTime)
        {

            if (anim == left)
            {
                posicion.X -= 1;
                left.animacion_enemigo_ataque(gameTime, posicion);
                anim = left;
            }
            if (anim == right)
            {
                posicion.X += 1;
                right.animacion_enemigo_ataque(gameTime, posicion);
                anim = right;
            }
            if (anim == down)
            {
                posicion.Y += 1;
                down.animacion_enemigo_ataque(gameTime, posicion);
                anim = down;
            }
            if (anim == up)
            {

                posicion.Y -= 1;
                up.animacion_enemigo_ataque(gameTime, posicion);
                anim = up;


            }
            if (posicion.X == 700 && posicion.Y == 0)
            {
                anim = left;
                left.Posicion = posicion;
            }
            if (posicion.X == 40 && posicion.Y == 0)
            {
                anim = down;
                down.Posicion = posicion;
            }
            if (posicion.X == 40 && posicion.Y == 170)
            {
                anim = right;
                right.Posicion = posicion;
            }
            if (posicion.X == 700 && posicion.Y == 170)
            {
                anim = up;
                up.Posicion = posicion;
            }


        }
        public void Disparo(GameTime gameTime, ContentManager Content)
        {

            if ((posicion.X == 700 && posicion.Y == 0) || (posicion.X == 40 && posicion.Y == 0) || (posicion.X == 40 && posicion.Y == 170) || (posicion.X == 700 && posicion.Y == 170) || (posicion.X == 40 && posicion.Y == 170 / 2) || (posicion.X == 700 && posicion.Y == 170/ 2))
            {
                if (count < 50)
                {
                    disparo = new Disparo(Content, "Imagenes/Boss2/Fire2", 4, 40, 99 / 4, posicion);
                    listaDisparo.Add(disparo);
                    disparo = new Disparo(Content, "Imagenes/Boss2/Fire2(1)", 4, 40, 99 / 4, posicion);
                    listaDisparo2.Add(disparo);

                }
                time = 0;

            }
            foreach (Disparo cl in listaDisparo)
            {
                cl.animacion_disparo(gameTime);
                bgolden8 = new BoundingBox(new Vector3(cl.Posicion.X, cl.Posicion.Y, 0), new Vector3(cl.Posicion.X + 30, cl.Posicion.Y +20, 0));
                if (bgolden.Intersects(bgolden8))
                {
                    vida1 = 1;
                    listaDisparo.Remove(cl);
                  


                    break;
                }
                if (bgolden2.Intersects(bgolden8))
                {
                    vida2 = 1;
                    listaDisparo.Remove(cl);



                    break;
                }
            }
            foreach (Disparo ch in listaDisparo2)
            {
                ch.animacion_disparo3(gameTime);
                bgolden9 = new BoundingBox(new Vector3(ch.Posicion.X, ch.Posicion.Y, 0), new Vector3(ch.Posicion.X + 30, ch.Posicion.Y + 20, 0));
                if (bgolden.Intersects(bgolden9))
                {
                    vida1 = 1;
                    listaDisparo2.Remove(ch);
   
                    break;
                }
                if (bgolden2.Intersects(bgolden9))
                {
                    vida3 = 1;
                    listaDisparo2.Remove(ch);

                    break;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
            foreach (Disparo cl in listaDisparo)
            {
                cl.Draw(spriteBatch);
            }
            foreach (Disparo ch in listaDisparo2)
            {
                ch.Draw(spriteBatch);
            }
        }
    }
}
