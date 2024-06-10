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
    class Muerte_animacion
    {

        Texture2D textura;
        Rectangle rectanguloOrigen;
        Rectangle rectanguloDestino;
        int numFrames;
        int frameActual = 0;
        int frameActual2 = 3;
        int count = 0;
        float temporizador = 0f;
        float intervalo = 1000f / 5f;
        float intervalo2 = 1000f / 2f;
        float intervalo3 = 1000f / 15f;
        int spriteAncho;
        int spriteAlto;
        Vector2 pos;
        public Vector2 Pos
        {
            get { return this.pos; }
            set { this.pos = value; }

        }
        public int SpriteAncho
        {
            get { return this.spriteAncho; }
            set { this.spriteAncho = value; }
        }
        public int SpriteAlto
        {
            get { return this.spriteAlto; }
        }
        public Muerte_animacion(ContentManager Content, string nombre, int numFrames, int spriteAlto, int spriteAncho, Vector2 pos)
        {
            this.pos = pos;
            this.textura = Content.Load<Texture2D>(nombre);
            this.numFrames = numFrames;
            this.spriteAncho = spriteAncho;
            this.spriteAlto = spriteAlto;
            //pos = new Vector2(50,50);
        }

        public void fuego_animacion(GameTime gameTime, Vector2 pos)
        {
            this.pos = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo)
            {
                frameActual++;
                if (frameActual > numFrames - 1)
                {
                    frameActual = 0;
                }
                if (temporizador == count)
                {
                    frameActual = 4;
                }
                temporizador = 0f;
            }

        }
       
        public void fuego_animacion1(GameTime gameTime, Vector2 pos)
        {
            this.pos = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo)
            {
                if (frameActual < 2)
                {
                    frameActual++;
                }

                temporizador = 0f;
            }


        }
        public void fuego_animacion3(GameTime gameTime, Vector2 pos)
        {
            this.pos = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (temporizador > intervalo2)
            {
                if (frameActual2 > -1  )
                {
                    frameActual2--;
                }
                temporizador = 0f;
            }
        }

        public void fuego_animacion2(GameTime gameTime, Vector2 pos)
        {
            this.pos = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo)
            {
                frameActual++;

                temporizador = 0f;
            }


        }
        public void fuego_animacion4(GameTime gameTime, Vector2 pos)
        {
            this.pos = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo)
            {

                frameActual++;


                temporizador = 0f;
            }
        }
             public void fuego_animacion5(GameTime gameTime, Vector2 pos)
        {
            this.pos = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo3)
            {
                
                    frameActual++;
                

                temporizador = 0f;
            }



        }
        public void contador(int contar)
        {
            contar = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rectanguloOrigen = new Rectangle(this.frameActual * this.spriteAncho, 0, this.spriteAncho, this.spriteAlto);
            rectanguloDestino = new Rectangle((int)Pos.X + 0, (int)Pos.Y + 0, spriteAncho, spriteAlto);
            spriteBatch.Draw(textura, rectanguloDestino, rectanguloOrigen, Color.White);
        }

    }


}
