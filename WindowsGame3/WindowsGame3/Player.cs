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
    class Player
    {
      
        personaje_animacion right, left, attack, stand, stand1, attack1, animActiva;      
        Vector2 pos, pos2;
        float zpospner;
        enum State { izquierda, derecha };
         State estado;

        int playerNum;

        int derecha = 0;
        int izquierda = 1;

        public int score1, score2, vida1,estado3;


        public bool moviendose = false;
        public bool atacando = false;




        public float Zpospner
        {
            get { return this.zpospner; }
            set { this.zpospner = value; }

        }
        public int Derecha
        {
            get { return this.derecha; }
            set { this.derecha = value; }

        }
        public int Izquierda
        {
            get { return this.izquierda; }
            set { this.izquierda = value; }

        }
        public Vector2 Pos
        {
            get { return this.pos; }
            set { this.pos = value; }

        }
        public Vector2 Pos2
        {
            get { return this.pos2; }
            set { this.pos2 = value; }

        }
        public Player(ContentManager Content, int numPlayer, Vector2 pos, float zpospner)
        {
            this.pos = pos;
            this.zpospner = zpospner;
            score1 = 0;
           
            estado3 = 0;

            vida1 = 100;

            playerNum = numPlayer;
            if (numPlayer == 1)
            {
                attack1 = new personaje_animacion(Content, "Imagenes/enano_attack(1)", 3, 75, 240 / 3,pos);
                right = new personaje_animacion(Content, "Imagenes/enano_run", 4, 69, 51, pos);
                left = new personaje_animacion(Content, "Imagenes/enano_run(1)", 4, 69, 56, pos);
                attack = new personaje_animacion(Content, "Imagenes/enano_attack", 3, 69, (225 / 3), pos);
                stand = new personaje_animacion(Content, "Imagenes/enano_stand", 1, 70, 67, pos);
                stand1 = new personaje_animacion(Content, "Imagenes/enano_stand(1)", 1, 70, 67, pos);
                animActiva = right;
            }
            else if (numPlayer == 2)
            {
                attack1 = new personaje_animacion(Content, "Imagenes/enano_attack2(1)", 3, 75, 240 / 3, pos);
                right = new personaje_animacion(Content, "Imagenes/enano_run2", 4, 69, 51, pos);
                left = new personaje_animacion(Content, "Imagenes/enano_run(1)2", 4, 69, 56, pos);
                attack = new personaje_animacion(Content, "Imagenes/enano_attack2", 3, 69, (225 / 3), pos);
                stand = new personaje_animacion(Content, "Imagenes/enano_stand2(2)", 1, 70, 67, pos);
                stand1 = new personaje_animacion(Content, "Imagenes/enano_stand2", 1, 70, 67, pos);
            }
        }

        

        public void Colision1(GameTime gametime)
        {
            pos.X -= 5;
        }
        public void Colision2(GameTime gametime)
        {
            pos.X += 5;
        }
        public void Colision5(GameTime gametime)
        {
            pos.X -= 30;
        }

        public void Colision4(GameTime gametime)
        {
            pos.X += 30;
        }
        public void Colision6(GameTime gametime)
        {
            pos.X -= 5/2;
        }

        public void Colision7(GameTime gametime)
        {
            pos.X += 5/2;
        }
        public void retro(GameTime gametime)
        {
            pos.X = 0;
        }
        public void cargando1(GameTime gametime)
        {
            pos.X = 100;
            pos.Y = 0;
        }
        public void cargando2(GameTime gametime)
        {
            pos.X = 100;
            pos.Y = 50;
        }

        public void Colision3(GameTime gametime)
        {
            pos.X = -888; ;
            pos.Y = -888;
        }
        public void pospner(float z)
        {
            zpospner = z;
        }

        public void Left2(GameTime gameTime)
        {
            if (pos.X > 0)
                pos.X -= 5;
            if (estado == State.derecha)
            {
                stand.animacion_player(gameTime, pos, zpospner);
                animActiva = stand;
                estado3 = 0;
            }
            else
            {
                if (estado == State.izquierda)
                {
                    estado3 = 1;
                    stand1.animacion_player(gameTime, pos, zpospner);
                    animActiva = stand1;
                }
            }
        }



        public void Right2(GameTime gameTime)
        {
            estado = State.derecha;
            right.animacion_player(gameTime, pos, zpospner);
            animActiva = right;
            moviendose = true;
            estado3 = 0;
        }
        public void Right3(GameTime gameTime)
        {
            estado = State.derecha;
                pos.X += 5;
            right.animacion_player(gameTime, pos, zpospner);
            animActiva = right;
            moviendose = true;
            estado3 = 0;
        }

        public void Right(GameTime gameTime)
        {
            atacando = false;
            moviendose = true;
            estado = State.derecha;
            if (pos.X < 750)
                pos.X += 5;
            right.animacion_player(gameTime, pos, zpospner);
            animActiva = right;

        }
        public void Left(GameTime gameTime)
        {
            atacando = false;
            moviendose = true;

            estado = State.izquierda;
            if (pos.X > 0)
                pos.X -= 5;
            left.animacion_player(gameTime, pos, zpospner);
            animActiva = left;
        }
        public void Up(GameTime gameTime)
        {
            atacando = false;
            moviendose = true;
            if (pos.Y > -20)
                pos.Y -= 5;

            if (estado == State.derecha)
            {
                right.animacion_player(gameTime, pos, zpospner);
                animActiva = right;
            }
            if ((estado == State.derecha) && (animActiva == stand))
            {
                left.animacion_player(gameTime, pos, zpospner);
                animActiva = right;
            }
            else
            {
                if (estado == State.izquierda)
                {
                    left.animacion_player(gameTime, pos, zpospner);
                    animActiva = left;
                }
                if ((estado == State.izquierda) && (animActiva == stand1))
                {
                    left.animacion_player(gameTime, pos, zpospner);
                    animActiva = left;
                }
            }

        }
        public void Down(GameTime gameTime)
        {
            atacando = false;
            moviendose = true;
            if (pos.Y < 160)
                pos.Y += 5;
            if (estado == State.derecha)
            {
                right.animacion_player(gameTime, pos, zpospner);
                animActiva = right;
            }
            if ((estado == State.derecha) && (animActiva == stand))
            {
                left.animacion_player(gameTime, pos, zpospner);
                animActiva = right;
            }
            else
            {
                if (estado == State.izquierda)
                {
                    left.animacion_player(gameTime, pos, zpospner);
                    animActiva = left;
                }
                if ((estado == State.izquierda) && (animActiva == stand1))
                {
                    left.animacion_player(gameTime, pos, zpospner);
                    animActiva = left;
                }
            }

        }
        public void Stand(GameTime gameTime)
        {
            atacando = false;
            if (estado == State.derecha)
            {
                stand.animacion_player(gameTime, pos, zpospner);
                animActiva = stand;
            }
            else
            {
                if (estado == State.izquierda)
                {
                    stand1.animacion_player(gameTime, pos, zpospner);
                    animActiva = stand1;
                }
            }
        }


        public void AnimacionAttack(GameTime gameTime)
        {
            if (atacando == true)
            {
                if (estado == State.derecha)
                {
                    attack.animacion_player(gameTime, pos, zpospner);
                }
                else if (estado == State.izquierda)
                {
                    attack1.animacion_player(gameTime, pos, zpospner);
                }
            }
        }


        public void Attack(GameTime gameTime)
        {
            atacando = true;
            if (estado == State.derecha)
            {

                attack.animacion_player(gameTime, pos, zpospner);
                animActiva = attack;
                animActiva.terminoAnimacion = false;

            }
            else
            {
                if (estado == State.izquierda)
                {
                    attack1.animacion_player(gameTime, pos, zpospner);
                    animActiva = attack1;
                    animActiva.terminoAnimacion = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (animActiva.Equals(attack1) || animActiva.Equals(attack))
            {
                if (animActiva.terminoAnimacion)
                {
                    if (estado == State.derecha)
                    {
                        stand.Pos = animActiva.Pos;
                        animActiva = stand;
                    }
                    else if (estado == State.izquierda)
                    {
                        stand1.Pos = animActiva.Pos;
                        animActiva = stand1;
                    }

                }
            }
            animActiva.Draw(spriteBatch);
        }



    }
}
