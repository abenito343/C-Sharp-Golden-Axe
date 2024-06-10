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
    class Dragon_stage4
    {
        int tiempo;
        int time = 0;
        int time2 = 0;
        int count = 0;
        int vida1 = 0;
        int vida2 = 0;
        BoundingBox bgolden8, bgolden,bgolden2;
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
        //------------------------------

        Disparo disparo;
        List<Disparo> listaDisparo = new List<Disparo>();
        enemigo_animacion anim;
        Vector2 posicion, posicion_shoot;

        public Dragon_stage4(ContentManager Content, Vector2 posicion)
        {
            this.posicion = posicion;
            anim = new enemigo_animacion(Content, "Imagenes/Boss2/Dragon_stage4", 4, 80, 360 / 4, posicion);
        }
        public void Disparo(GameTime gameTime, ContentManager Content)
        {
            time++;
            posicion_shoot = new Vector2(posicion.X + 20, posicion.Y + 20);
            if (time == 250)
            {
                if (count < 500)
                    disparo = new Disparo(Content, "Imagenes/Boss2/Dragon_shoot1", 6, 50, 300 / 6, posicion_shoot);
                listaDisparo.Add(disparo);
                time = 0;
                tiempo = 0;
            }
            foreach (Disparo cl in listaDisparo)
            {
                cl.animacion_disparo2(gameTime);
                bgolden8 = new BoundingBox(new Vector3(cl.Posicion.X, cl.Posicion.Y, 0), new Vector3(cl.Posicion.X + 30, cl.Posicion.Y +20, 0));
                if (bgolden.Intersects(bgolden8))
                {
                    listaDisparo.Remove(cl);
                    vida1 = 1;


                    break;
                }
                if (bgolden2.Intersects(bgolden8))
                {
                    listaDisparo.Remove(cl);
                    vida2 = 1;


                    break;
                }
            }
        }
        public void Disparo2(GameTime gameTime, ContentManager Content)
        {
            tiempo++;
            if (tiempo > 120)
            {
                time2++;
                posicion_shoot = new Vector2(posicion.X + 20, posicion.Y + 20);
                if (time2 == 250)
                {
                    if (count < 500)
                        disparo = new Disparo(Content, "Imagenes/Boss2/Dragon_shoot1", 6, 50, 300 / 6, posicion_shoot);
                    listaDisparo.Add(disparo);
                    time2 = 0;

                }
                foreach (Disparo cl in listaDisparo)
                {
                    cl.animacion_disparo2(gameTime);
                    cl.animacion_disparo2(gameTime);
                    bgolden8 = new BoundingBox(new Vector3(cl.Posicion.X, cl.Posicion.Y, 0), new Vector3(cl.Posicion.X + 30, cl.Posicion.Y +20, 0));
                    if (bgolden.Intersects(bgolden8))
                    {
                        listaDisparo.Remove(cl);
                        vida1 = 1;


                        break;
                    }
                    if (bgolden2.Intersects(bgolden8))
                    {
                        listaDisparo.Remove(cl);
                        vida2 = 1;


                        break;
                    }
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

