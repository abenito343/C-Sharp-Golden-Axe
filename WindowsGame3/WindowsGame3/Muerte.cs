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
    class Muerte
    {

        Muerte_animacion fuego,  anim,fuego2,fuego3, fuego4,fuego5;
        enum State { fuego1 };
        int timer;
        Vector2 pos;
        int finalY;
        public Vector2 Pos
        {
            get { return this.pos; }
            set { this.pos = value; }

        }
        public Muerte(ContentManager Content, int count, Vector2 pos)
        {
            Random r = new Random();
            finalY = r.Next(300, 465);
            this.pos = pos;
            fuego = new Muerte_animacion(Content, "Imagenes/death2", 3, 61, 276/3, pos);

            fuego2 = new Muerte_animacion(Content, "Imagenes/death2(1)", 3, 61, 276 / 3, pos);

            fuego4 = new Muerte_animacion(Content, "Imagenes/death_Player2(2)", 3, 61, 276 / 3, pos);

            fuego5 = new Muerte_animacion(Content, "Imagenes/death_Player2(1)", 3, 61, 276 / 3, pos);



            fuego3 = new Muerte_animacion(Content, "Imagenes/death(1)", 3, 40, 150 / 3, pos);

            anim = fuego3;
            
        }
        public void eleva(GameTime gameTime)
        {
            
                fuego.fuego_animacion1(gameTime, pos);
           
              
                anim = fuego;
            
        }
        public void eleva2(GameTime gameTime)
        {

            fuego2.fuego_animacion3(gameTime, pos);


            anim = fuego2;

        }
        public void eleva4(GameTime gameTime)
        {

            fuego5.fuego_animacion1(gameTime, pos);


            anim = fuego5;

        }
        public void eleva5(GameTime gameTime)
        {

            fuego4.fuego_animacion3(gameTime, pos);


            anim = fuego4;

        }
        public void eleva3(GameTime gameTime)
        {

            fuego3.fuego_animacion4(gameTime, pos);

            anim = fuego3;

        }
        public void eleva6(GameTime gameTime)
        {

            fuego3.fuego_animacion4(gameTime, pos);

            anim = fuego3;

        }
     
       
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
        }

    }
}
