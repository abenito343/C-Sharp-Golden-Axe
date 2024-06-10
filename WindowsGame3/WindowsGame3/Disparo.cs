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
    class Disparo
    {
        Texture2D textura;
        Rectangle rectanguloOrigen;
        Rectangle rectanguloDestino;
        int numFrames;
        int frameActual = 0;
        float temporizador = 0f;
        float intervalo = 1000f / 12f;

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
        public Disparo(ContentManager Content, string nombre, int numFrames, int spriteAlto, int spriteAncho, Vector2 posicion)
        {
            this.posicion = posicion;
            this.textura = Content.Load<Texture2D>(nombre);
            this.numFrames = numFrames;
            this.spriteAncho = spriteAncho;
            this.spriteAlto = spriteAlto;

        }
        public void animacion_disparo(GameTime gameTime)
        {
            this.posicion.X -= 2;
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
        public void animacion_disparo2(GameTime gameTime)
        {

            this.posicion.Y += 3;
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
        public void animacion_disparoSkull(GameTime gameTime)
        {

            this.posicion.Y += 2;
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
        public void animacion_disparo3(GameTime gameTime)
        {
            this.posicion.X += 2;
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
        //--------------------------------------------------------------------------- Dragon stage 5 
        /*   public void animacion_disparo_dragon(GameTime gameTime)
           {

               if (this.posicion.Y <= 50)
               {
                   this.posicion.Y += 2;
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

           }   
      public void animacion_disparo_quieto(GameTime gameTime)
           {
               if (timer < 200)
               {
                   if (this.posicion.Y > 50)
                   {
                       timer++;
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
               }
           }
      public void animacion_disparo_explosion(GameTime gameTime)
      {
          if (timer >= 200)
          {
              temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

              if (temporizador > intervalo)
              {
                  frameActual++;
                  timer = 0;
                  temporizador = 0f;
              }
          }
      }*/

        public void Draw(SpriteBatch spriteBatch)
        {
            rectanguloOrigen = new Rectangle(this.frameActual * this.spriteAncho, 0, this.spriteAncho, this.spriteAlto);
            rectanguloDestino = new Rectangle((int)Posicion.X + 0, (int)Posicion.Y + 375, spriteAncho, spriteAlto);
            spriteBatch.Draw(textura, rectanguloDestino, rectanguloOrigen, Color.White);
        }

    }
}
