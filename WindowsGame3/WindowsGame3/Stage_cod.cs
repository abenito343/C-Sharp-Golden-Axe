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
    class Stage_cod
    {
        Stage_animacion nivel;
        int up;
        Vector2 pos;
        int timer = 0;
        public Stage_cod(ContentManager Content, int stage, Vector2 pos)
        {
            this.pos = pos;
            up = stage;
            if (stage == 1)
                nivel = new Stage_animacion(Content, "Imagenes/Stage1", 1, 189, 325, pos);
            else if (stage == 2)
                nivel = new Stage_animacion(Content, "Imagenes/Stage3", 1, 189, 325, pos);
            else if (stage == 3)
                nivel = new Stage_animacion(Content, "Imagenes/Stage23", 1, 189, 524, pos);
            else if (stage == 4)
                nivel = new Stage_animacion(Content, "Imagenes/Boss2/lvl_stage4", 1, 189, 325, pos);
            else if (stage == 5)
                nivel = new Stage_animacion(Content, "Imagenes/Boss3/Stage5", 1, 189, 325, pos);
            


        }
        public void caida(GameTime gameTime)
        {
            timer++;
            if (pos.Y <= 80)
            {
                pos.Y += 1;
                nivel.animacion_stage(gameTime, pos);
            }
            else if (pos.Y >= 80 && timer > 150)
            {
                pos.X += 5;
                nivel.animacion_stage(gameTime, pos);
            }
        }
        public void caida2(GameTime gameTime)
        {
            timer++;
            if (pos.Y <= 80)
            {
                pos.Y += 1;
                nivel.animacion_stage(gameTime, pos);
            }
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            nivel.Draw(spriteBatch);
        }

    }
}

