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
    class enemigo_animacion
    {
        Texture2D textura;
        Rectangle rectanguloOrigen;
        Rectangle rectanguloDestino;
        int numFrames;
        int frameActual = 0;
        float temporizador = 0f;
        float intervalo = 1000f / 10f;
        float intervalo1 = 1000f / 6f;
        float intervalo2 = 1000f / 4f;
        float intervalo3 = 1000f / 5f;
        int spriteAncho;
        int spriteAlto;
        Vector2 posicion;
        public Vector2 Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
        public float x
        {
            get { return this.posicion.X; }
            set { this.posicion.X = value; }

        }
        public float y
        {
            get { return this.posicion.Y; }
            set { this.posicion.Y = value; }

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
        public enemigo_animacion(ContentManager Content, string nombre, int numFrames, int spriteAlto, int spriteAncho, Vector2 posicion)
        {
            this.posicion = posicion;
            this.textura = Content.Load<Texture2D>(nombre);
            this.numFrames = numFrames;
            this.spriteAncho = spriteAncho;
            this.spriteAlto = spriteAlto;
            //pos = new Vector2(50,50);
        }

        public void animacion_enemigo(GameTime gameTime, Vector2 pos)
        {
            this.posicion = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo)
            {
                frameActual++;
                if (frameActual > numFrames - 1)
                {
                    frameActual = 0;
                }
                temporizador = 0f;
            }

        }
        public void animacion_enemigo_ataque(GameTime gameTime, Vector2 pos)
        {
            this.posicion = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo1)
            {
                frameActual++;
                if (frameActual > numFrames - 1)
                {
                    frameActual = 0;
                }
                temporizador = 0f;
            }

        }
        public void animacion_enemigo_ataque1(GameTime gameTime, Vector2 pos)
        {
            this.posicion = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo2)
            {
                frameActual++;
                if (frameActual > numFrames - 1)
                {
                    frameActual = 0;
                }
                temporizador = 0f;
            }
        }
        public void animacion_fuego_final(GameTime gameTime, Vector2 pos)
        {
            this.posicion = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo)
            {
                frameActual--;
            }

        }
        public void animacion_enemigo2(GameTime gameTime, Vector2 pos)
        {
            this.posicion = pos;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo3)
            {
                frameActual++;
                if (frameActual > numFrames - 1)
                {
                    frameActual = 0;
                }
                temporizador = 0f;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rectanguloOrigen = new Rectangle(this.frameActual * this.spriteAncho, 0, this.spriteAncho, this.spriteAlto);
            rectanguloDestino = new Rectangle((int)Posicion.X + 0, (int)Posicion.Y +375, spriteAncho, spriteAlto);
            
            spriteBatch.Draw(textura, rectanguloDestino, rectanguloOrigen , Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.2f);
        }

    }


}