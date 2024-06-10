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
    class enemigoB
    {
        List<Disparo> listaDisparo = new List<Disparo>();
        enemigo_animacion right, left, anim;
        Disparo fire;
        BoundingBox bgolden8,bgolden,bgolden2;
        enum asd { subida, caida };
        asd dragon;
        int count = 0;
        int time = 0;
        int vida1 = 0;
        int vida2= 0;
        enum state { izquierda, derecha };
        Vector2 pos, pos2;

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



        public Vector2 Pos
        {
            get { return this.pos; }
            set { this.pos = value; }

        }
      public enemigoB(ContentManager Content, int numenemigo, Vector2 pos)
      {
          Random x = new Random();
          this.pos = pos;
          pos2 = pos;
          right = new enemigo_animacion(Content, "Imagenes/dragon", 4, 75, 335 / 4, pos);
          left = new enemigo_animacion(Content, "Imagenes/dragon(2)", 2, 75, 240 / 2, pos);
          
          anim = right;
          dragon = asd.subida;
          
      }
      public void Colision1(GameTime gametime)
      {
          if(Pos.X <730)
          pos.X -= 5;
      }
      public void Colision2(GameTime gametime)
      {
          if(Pos.X <730)
          pos.X += 5;
      }
      public void HK(GameTime gameTime)
      {


          if (pos.X != 720)
          {
              right.animacion_enemigo(gameTime, pos);
              pos.X -= 1;
              anim = right;
          }
          else
          {
              if (pos.Y > 0 && dragon == asd.subida)
              {
                  right.animacion_enemigo(gameTime, pos);
                  anim = right;
                  pos.Y -= 1;

              }
              else if (pos.Y >= 160)
              {
                  dragon = asd.subida;
                  right.animacion_enemigo(gameTime, pos);
                  anim = right;
                  pos.Y -= 1;

              }
              else
              {
                  dragon = asd.caida;
                  anim = right;
                  pos.Y += 1;
                  right.animacion_enemigo(gameTime, pos);
              }
          
          }
        
      
    }
    public void Disparo(GameTime gameTime, ContentManager Content)
         {
             time++;
             
             if (time == 250)
             {
                 if (count < 50)
                 {
                     fire = new Disparo(Content, "Imagenes/fire", 1, 25, 25,pos);
                     listaDisparo.Add(fire);

                 }
                 time = 0;
                
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
                     vida2 = 1;


                     break;
                 }

             } 
         }

      public void Draw (SpriteBatch spriteBatch)
        {
            foreach (Disparo cl in listaDisparo)
            {
                cl.Draw(spriteBatch);
            }
            anim.Draw(spriteBatch);
          
        }
    }
}
