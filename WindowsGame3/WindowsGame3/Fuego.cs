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
    class Fuego
    {
        
        animacion_fuego fuego, explosion, anim;
        enum State {fuego1,explosion1};
        int timer;
        Vector2 pos;
        int finalY;
        int numcount;
        public Vector2 Pos
        {
            get { return this.pos; }
            set { this.pos = value; }

        }
        public Fuego(ContentManager Content,int count,int tipofuego,Vector2 pos)
        {
            Random r = new Random();
            finalY = r.Next(375, 540);
            this.pos = pos;
            numcount = tipofuego;
            if (tipofuego == 1)
            {
                fuego = new animacion_fuego(Content, "Imagenes/fuego2", 3, 24, 93 / 3, pos);
                explosion = new animacion_fuego(Content, "Imagenes/bang", 3, 24, 130 / 3, pos);
            }
            else if (tipofuego== 2)
            {
                fuego = new animacion_fuego(Content, "Imagenes/Boss3/fuego2_stage5", 3, 24, 93 / 3, pos);
                explosion = new animacion_fuego(Content, "Imagenes/Boss3/explosion_stage5", 3, 24, 130 / 3, pos);
            }
         
            anim = fuego;
        } 
        public void caida(GameTime gameTime)
        {
            if (pos.Y <= finalY)
            {
                fuego.fuego_animacion(gameTime, pos);
                pos.Y += 5;
                anim = fuego;
            }
        }
        public void stand(GameTime gameTime)
        {
            if (pos.Y > finalY)
            {
                Random r = new Random();
                timer++;
                fuego.fuego_animacion(gameTime, pos);          
                anim = fuego;
                
            }
     
        }
        public void boom(GameTime gameTime)
        {
            
            int contador = 200;
            if (timer >= contador)
            {
                explosion.fuego_animacion1(gameTime, pos);
                anim = explosion;
            }
            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
        }

    }
}
