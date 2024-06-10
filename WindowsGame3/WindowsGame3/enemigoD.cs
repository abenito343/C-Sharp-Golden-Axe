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
    class enemigoD
    {
        int contador = 0;
        enemigo_animacion right, left, anim, attack, attack2;
        enum state { izquierda, derecha };
        Vector2 posicion;
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
        public enemigoD(ContentManager Content, int numenemigo, Vector2 posicion)
        {

            this.posicion = posicion;
            right = new enemigo_animacion(Content, "Imagenes/enemigoD", 4, 65, 210 / 4, posicion);
            left = new enemigo_animacion(Content, "Imagenes/enemigoD(1)", 4, 65, 210 / 4, posicion);
            attack = new enemigo_animacion(Content, "Imagenes/enemigoD_attack", 5, 65, 321 / 5, posicion);
            attack2 = new enemigo_animacion(Content, "Imagenes/enemigoD_attack(2)", 5, 65, 321 / 5, posicion);
            anim = right;


        }
        public void RK(GameTime gameTime)
        {

            if (posicion.X == 399 && anim != left)
            {
                contador++;


                if (contador < 60)
                {
                    attack.animacion_enemigo_ataque(gameTime, posicion);
                    anim = attack;
                    atacando = 1;
                }

                else if (contador > 60)
                {
                    atacando = 0;
                    posicion.X = 398;
                    contador = 0;
                    anim = right;
                }
            }
            else if (posicion.X == 700 && anim != left)
            {
                contador++;


                if (contador < 60)
                {
                    attack.animacion_enemigo_ataque(gameTime, posicion);
                    anim = attack;
                    atacando = 1;
                }

                else if (contador > 60)
                {
                    atacando = 0;
                    posicion.X = 699;
                    contador = 0;
                    anim = right;
                }
            }
            else if (posicion.X == 198 && anim != left)
            {
                contador++;


                if (contador < 60)
                {
                    attack.animacion_enemigo_ataque(gameTime, posicion);
                    anim = attack;
                    atacando = 1;
                }

                else if (contador > 60)
                {
                    atacando = 0;
                    posicion.X = 197;
                    contador = 0;
                    anim = right;
                }
            }
            else if (posicion.X == 200 && anim != right)
            {
                contador++;


                if (contador < 60)
                {
                    attack2.animacion_enemigo_ataque(gameTime, posicion);
                    anim = attack2;
                    atacando = 1;
                }

                else if (contador > 60)
                {
                    atacando = 0;
                    posicion.X = 201;
                    contador = 0;
                    anim = left;
                }
            }
            else if (posicion.X == 401 && anim != right)
            {
                contador++;


                if (contador < 60)
                {
                   
                    attack2.animacion_enemigo_ataque(gameTime, posicion);
                    anim = attack2;
                    atacando = 1;
                }

                else if (contador > 60)
                {
                    atacando = 0;
                    posicion.X = 402;
                    contador = 0;
                    anim = left;
                }
            }
            else if (posicion.X == 602 && anim != right)
            {
                contador++;


                if (contador < 60)
                {
                    attack2.animacion_enemigo_ataque(gameTime, posicion);
                    anim = attack2;
                    atacando = 1;
                }

                else if (contador > 60)
                {
                    atacando = 0;
                    posicion.X = 604;
                    contador = 0;
                    anim = left;
                }
            }

            else if (posicion.X <= 0)
            {
                atacando = 0;
                posicion.X = 0;
                anim = left;
            }
            else if (posicion.X >= 800)
            {
                atacando = 0;
                posicion.X = 800;
                anim = right;
            }
            if (anim == right)
            {
                atacando = 0;
                posicion.X -= 4;
                right.animacion_enemigo(gameTime, posicion);
            }
            else if (anim == left)
            {
                atacando = 0;
                posicion.X += 4;
                left.animacion_enemigo(gameTime, posicion);
            }
        }
        public void Colision1(GameTime gametime)
        {
            posicion.X -= 4;
        }
        public void Colision2(GameTime gametime)
        {
            posicion.X += 4;
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            anim.Draw(spriteBatch);

        }
    }
}

