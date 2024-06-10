using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace WindowsGame3
{
    class personaje_animacion
    {

        Texture2D textura;
        Rectangle rectanguloOrigen;
        Rectangle rectanguloDestino;
        int numFrames;
        int frameActual = 0;
        float temporizador = 0f;
        float intervalo = 1000f / 10f;
        float intervalo2 = 1000f / 5f;
        int spriteAncho;
        int spriteAlto;
        Vector2 pos;
        float zpospner;
        public bool terminoAnimacion;
        public Vector2 Pos

        {
            get { return this.pos; }
            set { this.pos = value; }

        }
        public float Zpospner
        {
            get { return this.zpospner; }
            set { this.zpospner = value; }

        }

        public float x
        {
            get { return this.pos.X; }
            set { this.pos.X = value; }

        }
        public float y
        {
            get { return this.pos.Y; }
            set { this.pos.Y = value; }

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
        public personaje_animacion(ContentManager Content, string nombre, int numFrames, int spriteAlto, int spriteAncho, Vector2 pos )
        {
            terminoAnimacion = false;
            this.pos = pos;
            this.textura = Content.Load<Texture2D>(nombre);
            this.numFrames = numFrames;
            this.spriteAncho = spriteAncho;
            this.spriteAlto = spriteAlto;
            //pos = new Vector2(50,50);
        }

        public void animacion_player(GameTime gameTime, Vector2 pos, float zpospner)
        {
           
            this.pos = pos;
            this.zpospner = zpospner;
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (temporizador > intervalo)
            {
                frameActual++;
                if (frameActual > numFrames - 1)
                {
                    frameActual = 0;
                    terminoAnimacion = true;
                }
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
            rectanguloDestino = new Rectangle((int)Pos.X + 0, (int)Pos.Y + 375, spriteAncho, spriteAlto);
            spriteBatch.Draw(textura, rectanguloDestino, rectanguloOrigen, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, Zpospner);
        }

    }


}


