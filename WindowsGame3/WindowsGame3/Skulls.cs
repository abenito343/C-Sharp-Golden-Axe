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
    class Skulls
    {
        enemigo_animacion right, left, anim;
        int count;
        int time;
        int tiempo;
        int vida1;
        int vida2;
        BoundingBox bgolden8, bgolden,bgolden9,bgolden2;
        Disparo disparo;
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
        List<Disparo> listaDisparo = new List<Disparo>();

        int timer;
        Vector2 posicion, posicion_shoot;
        public Skulls(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            right = new enemigo_animacion(Content, "Imagenes/Boss3/Skull", 3, 69, 131 / 3, posicion);
            left = new enemigo_animacion(Content, "Imagenes/Boss3/Skull", 3, 69, 131 / 3, posicion);
            anim = right;
        }
        public void movimientos(GameTime gameTime)
        {
            if (anim == right)
            {
                posicion.X++;
                right.animacion_enemigo(gameTime, posicion);
            }
            if (anim == left)
            {
                posicion.X--;
                left.animacion_enemigo(gameTime, posicion);
            }
            if (posicion.X >= 610)
            {
                left.animacion_enemigo(gameTime, posicion);
                left.Posicion = posicion;
                anim = left;
            }
            if (posicion.X <= 140)
            {
                left.Posicion = posicion;
                right.animacion_enemigo(gameTime, posicion);
                anim = right;
            }
        }
        public void Disparo(GameTime gameTime, ContentManager Content)
        {
            time++;
            posicion_shoot = new Vector2(posicion.X, posicion.Y + 45);
            if (time == 200)
            {
                if (count < 500)
                    disparo = new Disparo(Content, "Imagenes/Boss3/shoots_stage5", 6, 35, 210 / 6, posicion_shoot);
                listaDisparo.Add(disparo);
                time = 0;
            }
            foreach (Disparo cl2 in listaDisparo)
            {
                cl2.animacion_disparoSkull(gameTime);
                bgolden8 = new BoundingBox(new Vector3(cl2.Posicion.X, cl2.Posicion.Y , 0), new Vector3(cl2.Posicion.X + 30, cl2.Posicion.Y +20, 0));
                if (bgolden.Intersects(bgolden8))
                {
                    listaDisparo.Remove(cl2);
                    vida1 = 1;
                    break;
                }
                if (bgolden2.Intersects(bgolden8))
                {
                    listaDisparo.Remove(cl2);
                    vida2 = 1;
                    break;
                }
            }
        }
        public void Disparo2(GameTime gameTime, ContentManager Content)
        {
            tiempo++;
            if (tiempo >= 350)
            {
                time++;
                posicion_shoot = new Vector2(posicion.X, posicion.Y + 45);
                if (time == 200)
                {
                    if (count < 500)
                        disparo = new Disparo(Content, "Imagenes/Boss3/shoots_stage5", 6, 35, 210 / 6, posicion_shoot);
                    listaDisparo.Add(disparo);
                    time = 0;

                }
            }
            foreach (Disparo cl3 in listaDisparo)
            {
                cl3.animacion_disparoSkull(gameTime);
                bgolden8 = new BoundingBox(new Vector3(cl3.Posicion.X, cl3.Posicion.Y , 0), new Vector3(cl3.Posicion.X + 30, cl3.Posicion.Y +20, 0));
                if (bgolden.Intersects(bgolden8))
                {
                    listaDisparo.Remove(cl3);
                    vida1 = 1;
                    break;
                }
                if (bgolden2.Intersects(bgolden8))
                {
                    listaDisparo.Remove(cl3);
                    vida2 = 1;
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
        }
    }
}
