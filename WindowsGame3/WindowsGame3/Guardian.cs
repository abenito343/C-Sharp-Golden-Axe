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
    class Guardian
    {
        int timer;
        enemigo_animacion right, left, ataque, ataque1, up, down, anim;
        enum state { izquierda, derecha };
        
        Vector2 posicion;
        int contador = 0;
        int atacando = 0;
        public int Atacando
        {
            get { return this.atacando; }
            set { this.atacando = value; }
        }
        
        public Vector2 Pos
        {
            get { return this.posicion; }
            set { this.posicion = value; }

        }
       
        public Guardian(ContentManager Content, Vector2 posicion)
        {
            Random r = new Random();
            this.posicion = posicion;
            right = new enemigo_animacion(Content, "Imagenes/Guardian/Guardian(1)", 3, 98, 252 / 4, posicion);
            left = new enemigo_animacion(Content, "Imagenes/Guardian/Guardian", 3, 98, 252 / 4, posicion);
            up = new enemigo_animacion(Content, "Imagenes/Guardian/Guardian", 3, 98, 252 / 4, posicion);
            down = new enemigo_animacion(Content, "Imagenes/Guardian/Guardian", 3, 98, 252 / 4, posicion);
            ataque = new enemigo_animacion(Content, "Imagenes/Guardian/Guardian_atacar(1)", 2, 103, 210 / 2, posicion);
            ataque1 = new enemigo_animacion(Content, "Imagenes/Guardian/Guardian_atacar", 2, 103, 225 / 2, posicion);
            anim = left;


        }
        public void Colision1(GameTime gametime)
        {
            posicion.X --;
        }
        public void Colision2(GameTime gametime)
        {
            posicion.X ++;
        }
        public void Right(GameTime gameTime)
        {
            timer++;
            if (timer > 250)
            {
                if (anim == left)
                {
                    atacando = 0;
                    posicion.X--;
                    left.animacion_enemigo_ataque(gameTime, posicion);
                    anim = left;
                }
                if (anim == right)
                {
                    atacando = 0;
                    posicion.X++;
                    right.animacion_enemigo_ataque(gameTime, posicion);
                    anim = right;
                }
                if (anim == down)
                {
                    atacando = 0;
                    posicion.Y++;
                    down.animacion_enemigo_ataque(gameTime, posicion);
                    anim = down;
                }
                if (anim == up)
                {
                    atacando = 0;
                    posicion.Y--;
                    up.animacion_enemigo_ataque(gameTime, posicion);
                    anim = up;
                }

                if (posicion.X == 50)
                {
                    atacando = 0;
                    right.Posicion = posicion;
                    anim = right;

                }

                if (posicion.X == 405 && anim != right)
                {
                    atacando = 0;
                    down.Posicion = posicion;
                    anim = down;
                }

                if (posicion.X >= 750 && posicion.Y == 110 && anim != left)
                {
                    atacando = 0;
                    up.Posicion = posicion;
                    anim = up;
                }
                if (posicion.X == 750 && posicion.Y == -55 && anim != right && anim != left && anim != down)
                {
                    atacando = 0;
                    left.Posicion = posicion;
                    anim = left;
                }
                if (posicion.X == 550 && posicion.Y == -55 && anim != right)
                {
                    contador++;
                    if (contador < 30)
                    {
                        atacando = 1;
                        ataque1.animacion_enemigo_ataque1(gameTime, posicion);
                        anim = ataque1;
                    }
                    else
                    {
                        atacando = 0;
                        anim = left;
                        contador = 0;
                        posicion.X = 549;

                    }
                }

                if (posicion.X == 405 && posicion.Y == 110 && anim != right)
                {
                    contador++;
                    if (contador < 30)
                    {
                        atacando = 1;
                        ataque1.animacion_enemigo_ataque1(gameTime, posicion);
                        anim = ataque1;
                    }
                    else
                    {
                        atacando = 0;
                        anim = left;
                        contador = 0;
                        posicion.X = 404;

                    }
                }
                if (posicion.X == 154 && posicion.Y == 110 && anim != right)
                {
                    contador++;
                    if (contador < 30)
                    {
                        atacando = 1;
                        ataque1.animacion_enemigo_ataque1(gameTime, posicion);
                        anim = ataque1;
                    }
                    else
                    {
                        atacando = 0;
                        anim = left;
                        contador = 0;
                        posicion.X = 153;

                    }

                }


            }


        }
        public void Right2(GameTime gameTime)
        {
            timer++;
            if (timer > 250)
            {

                if (anim == left)
                {
                    atacando = 0;
                    posicion.X--;
                    left.animacion_enemigo_ataque(gameTime, posicion);
                    anim = left;
                }
                if (anim == right)
                {
                    atacando = 0;
                    posicion.X++;
                    right.animacion_enemigo_ataque(gameTime, posicion);
                    anim = right;
                }
                if (anim == down)
                {
                    atacando = 0;
                    posicion.Y++;
                    down.animacion_enemigo_ataque(gameTime, posicion);
                    anim = down;
                }
                if (anim == up)
                {
                    atacando = 0;
                    posicion.Y--;
                    up.animacion_enemigo_ataque(gameTime, posicion);
                    anim = up;
                }
                if (posicion.X == 50)
                {
                    atacando = 0;
                    right.Posicion = posicion;
                    anim = right;

                }
                if (posicion.X == 305 && anim != right)
                {
                    atacando = 0;
                    up.Posicion = posicion;
                    anim = up;
                }
                if (posicion.X >= 705 && posicion.Y == -55 && anim != left)
                {
                    atacando = 0;
                    down.Posicion = posicion;
                    anim = down;
                }
                if (posicion.X == 705 && posicion.Y == 110 && anim != right && anim != left && anim != up)
                {
                    atacando = 0;
                    left.Posicion = posicion;
                    anim = left;
                }
                if (posicion.X == 550 && posicion.Y == 110 && anim != right)
                {
                    
                    contador++;
                    if (contador < 30)
                    {
                        atacando = 1;
                        ataque1.animacion_enemigo_ataque1(gameTime, posicion);
                        anim = ataque1;
                    }
                    else
                    {
                        atacando = 0;
                        anim = left;
                        contador = 0;
                        posicion.X = 549;

                    }
                }

                if (posicion.X == 305 && posicion.Y == -55 && anim != right)
                {
                    contador++;
                    if (contador < 30)
                    {
                        atacando = 1;
                        ataque1.animacion_enemigo_ataque1(gameTime, posicion);
                        anim = ataque1;
                    }
                    else
                    {
                        atacando = 0;
                        anim = left;
                        contador = 0;
                        posicion.X = 304;

                    }
                }
                if (posicion.X == 154 && posicion.Y == -55 && anim != right)
                {
                    contador++;
                    if (contador < 30)
                    {
                        atacando = 1;
                        ataque1.animacion_enemigo_ataque1(gameTime, posicion);
                        anim = ataque1;
                    }
                    else
                    {
                        atacando = 0;
                        anim = left;
                        contador = 0;
                        posicion.X = 153;

                    }

                }

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            anim.Draw(spriteBatch);

        }
    }
}
