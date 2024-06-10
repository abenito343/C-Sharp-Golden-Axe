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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random r = new Random();
        //--------------------------------------------------
        List<enemigo> listaEnemigos = new List<enemigo>();
        List<enemigoA> listaEnemigosA = new List<enemigoA>();
        List<enemigoB> listaEnemigosB = new List<enemigoB>();
        List<enemigoC> listaEnemigosC = new List<enemigoC>();
        List<enemigoD> listaEnemigosD = new List<enemigoD>();
        List<Jinete> jinetes = new List<Jinete>();
        List<Fuego> listaFuego = new List<Fuego>();
        List<fuego_area> Fuego_area = new List<fuego_area>();
        //--------------------------------------------------
        float Time = 0f;

        private SoundEffect temaflema,song1,song2,song3,song4,song5,song6;
     

        int screenWidth = 800;
        int screenHeight = 600;
        Menu Boton, Boton2,Boton3,Boton4;
        int hola = 0;
        int hola1 = 0;
        int hola2 = 0;
        int hola3 = 0;
        int hola5 = 0;
        int fire = 0;
        int tiempo;
        int tiempo1;
        int tiempo2;
        int tiempo3;
        int tiempo4;
        int tiempo5;
        int contador;
        int matados;
        int cifra;
        int cargando;
        int cargando2;
        int nivel1 = 1;
        int nivel2 = 0;
        int nivel3 = 0;
        int nivel4 = 0;
        int nivel5 = 0;
        int juegoganado = 0;

        int cambionivel = 0;
        int murio = 0;
       
        

        int oknivel2 = 2;
        int contadornivel2;
        int oknivel5 =2 ;
        int contadornivel5;



        int reproducir;
        int reproducir2;


        int muerto3;
        int contador3;
        int muerto4;
        int contador4;
        int muerto5;
        int contador5;

        int muerto6;
        int contador6;
        int muerto7;
        int contador7;
     

        int pega;
        int pega2;
        int pega3;
        int aparicionfuego = 150;
        int aparicion = 200;
        int aparicion2 = 310;
        int aparicion3 = 500;
        int aparicion4 = 300;
        int aparicion5 = 450;
        Fuego explosion;
        enemigo enemigo;
        enemigoA enemigoa;
        enemigoB enemigob;
        enemigoC enemigoc;

        Dragon_stage4 dragon1, dragon2, dragon3, dragon4, dragon5, dragon6, dragon7;
        Boss_stage4 Boss;
        Player player, player2;

        SpriteFont georgia;
        Vector2 p1scorePos;
        Vector2 p2scorePos;
        Vector2 p3scorePos;
        Vector2 p4scorePos;
        Vector2 p5scorePos;
        Vector2 p1vidaPos;
        Vector2 p2vidaPos;
        enemigoD enemigod;
        Guardian guardian, guardian2;
        Mago mago;
        Muerte muerte,muerte2,muerte3,muerte4,muerte5,muerte6,muerte7;
        domo Domo;
        warps_cod vortice, vortice2;
        //-------------------------------
       int stage_conteo5;
        Jinete jinete;
        fuego_area fuegoarea;
        Skulls skull;
        Skulls skull1;
        Boss3 boss3;
        Dragon_stage5 dragon_stage5;
        int aparicionjinete = 700;
        int hola6 = 0;
        int tiempo6;
        int aparicionfuegoverde = 425;
        int hola7 = 0;
        int tiempo7;
        int gameover;
        int perdiste;




        BoundingBox bgolden3, bgolden4, bgolden5, bgolden6, bgolden7, bgolden8, bgolden9, bgolden10,bgolden11,bgolden12,bgolden13,bgolden14,bgolden15,bgolden16;
        public BoundingBox bgolden, bgolden2;

        Stage_cod lvl, lvl2, lvl3,lvl4,lvl5;
        enum GameState
        {
            MainMenu,
            Play,
            Loading,
            Exit,
            GameOver,
        }
        GameState CurrentGameState = GameState.MainMenu;
        Texture2D HP, HP2, HP_bar, score, score2, load, fondo2, fondo4,fondo5,ganado,fondo3;

        Vector2 pos3 = new Vector2(10, 10);
     
        Vector2 pmuerte = new Vector2(50, 0);
        Vector2 p2muerte = new Vector2(50, 42);

        Texture2D fondo;
        TimeSpan Timer = TimeSpan.Zero;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 1280;
            graphics.PreferredBackBufferWidth = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }
        protected override void Initialize()
        {

            base.Initialize();

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            HP = Content.Load<Texture2D>("Imagenes/enano_hp");
            HP2 = Content.Load<Texture2D>("Imagenes/enano_hp2");
            HP_bar = Content.Load<Texture2D>("Imagenes/health_bar");
            fondo = Content.Load<Texture2D>("Imagenes/fondo_prueba2");
            fondo3 = Content.Load<Texture2D>("Imagenes/fondopuerta");
            fondo2 = Content.Load<Texture2D>("Imagenes/fondo_stage2");
            fondo4 = Content.Load<Texture2D>("Imagenes/fondo_stage4");
            score = Content.Load<Texture2D>("Imagenes/score/score");
            fondo5 = Content.Load<Texture2D>("Imagenes/fondostage5(1)");
            load = Content.Load<Texture2D>("Imagenes/loading_game");
            score2 = Content.Load<Texture2D>("Imagenes/score/score2");

            ganado = Content.Load<Texture2D>("Imagenes/juegoganado");

            player = new Player(Content, 1, new Vector2(100, 50), 0.99f);
            player2 = new Player(Content, 2, new Vector2(100, 100), 0.99f);
            IsMouseVisible = true;
            guardian = new Guardian(Content, new Vector2(700, -55));
            guardian2 = new Guardian(Content, new Vector2(700, 110));
            dragon1 = new Dragon_stage4(Content, new Vector2(90, -155));
            dragon2 = new Dragon_stage4(Content, new Vector2(180, -155));
            dragon3 = new Dragon_stage4(Content, new Vector2(270, -155));
            dragon4 = new Dragon_stage4(Content, new Vector2(360, -155));
            dragon5 = new Dragon_stage4(Content, new Vector2(450, -155));
            dragon6 = new Dragon_stage4(Content, new Vector2(540, -155));
            dragon7 = new Dragon_stage4(Content, new Vector2(630, -155));
            //--------------------------------------
            boss3 = new Boss3(Content, new Vector2(700, 60));
            dragon_stage5 = new Dragon_stage5(Content, new Vector2(1100, -375));
            skull = new Skulls(Content, new Vector2(140, -150));
            skull1 = new Skulls(Content, new Vector2(610, -150));

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
            Boss = new Boss_stage4(Content, new Vector2(700, 70));
            boss3 = new Boss3(Content, new Vector2(700, 70));
            Boton = new Menu(Content.Load<Texture2D>("Imagenes/health_bar"), graphics.GraphicsDevice);
            Boton.setposition(new Vector2(532, 200));
            Boton2 = new Menu(Content.Load<Texture2D>("Imagenes/health_bar"), graphics.GraphicsDevice);
            Boton2.setposition(new Vector2(532, 376));
            Boton3 = new Menu(Content.Load<Texture2D>("Imagenes/health_bar"), graphics.GraphicsDevice);
            Boton3.setposition(new Vector2(50, 367));
            Boton4 = new Menu(Content.Load<Texture2D>("Imagenes/health_bar"), graphics.GraphicsDevice);
            Boton4.setposition(new Vector2(50, 490));
            lvl = new Stage_cod(Content, 1, new Vector2(210, 0));
            vortice = new warps_cod(Content, new Vector2(750, -30));
            lvl2 = new Stage_cod(Content, 2, new Vector2(210, 0));
            lvl3 = new Stage_cod(Content, 3, new Vector2(210, 0));
            vortice2 = new warps_cod(Content, new Vector2(750, 110));
            Domo = new domo(Content, new Vector2(580, 40));
            guardian = new Guardian(Content, new Vector2(700, -55));
            guardian2 = new Guardian(Content, new Vector2(700, 110));
            mago = new Mago(Content, new Vector2(700, 70));
            
          

            lvl4 = new Stage_cod(Content, 4, new Vector2(210, 0));
            lvl5 = new Stage_cod(Content, 5, new Vector2(210, 0));


       
  
   
     temaflema = Content.Load<SoundEffect>("Sonidos/solocaminando");
     song1 = Content.Load<SoundEffect>("Sonidos/11");
     song2 = Content.Load<SoundEffect>("Sonidos/solocaminando");
     song3 = Content.Load<SoundEffect>("Sonidos/solocaminando");
     song4 = Content.Load<SoundEffect>("Sonidos/solocaminando");
     song5 = Content.Load<SoundEffect>("Sonidos/solocaminando");
     song6 = Content.Load<SoundEffect>("Sonidos/solocaminando"); 



            georgia = Content.Load<SpriteFont>("georgiaFont");

            p1scorePos.X = 640;
            p1scorePos.Y = 8;

            p2scorePos.X = 640;
            p2scorePos.Y = 50;

            p3scorePos.X = 250;
            p3scorePos.Y = 50;

            p4scorePos.X = 250;
            p4scorePos.Y = 20;

            p5scorePos.X = 320;
            p5scorePos.Y = 20;

            p1vidaPos.X = 50;
            p1vidaPos.Y = 8;

            p2vidaPos.X = 50;
            p2vidaPos.Y = 50;
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (reproducir < 10)
                reproducir++;
            if (reproducir == 1)
            {
                song1.Play();
            }

           
            if (cargando == 1)
            {
                cargando2--;
                player.cargando1(gameTime);
                player2.cargando2(gameTime);
            }
            if (cargando2 == 0)
            {
                cargando = 0;
            }

            if (matados == 10)
            {
                if (nivel1 == 1)
                {
                    cargando = 1;
                    cargando2 = 100;
                }
                nivel1 = 0;
                if (cargando == 0)
                {
                    nivel2 = 1;

                }
            }
            if (matados == 11)
            {
                if (nivel2 == 1)
                {
                    cargando = 1;
                    cargando2 = 100;
                }
                nivel2 = 0;
                if (cargando == 0)
                {
                    nivel5 = 1;
                }
            }
            
            
            if (matados == 16)
            {
                if (nivel5 == 1)
                {
                    cargando = 1;
                    cargando2 = 100;
                }
                nivel5 = 0;
                if (cargando == 0)
                {
                    nivel3 = 1;
                }
            }

            if (matados == 17)
            {
                if (nivel3 == 1)
                {
                    cargando = 1;
                    cargando2 = 100;
                }
                nivel3 = 0;
                if (cargando == 0)
                {
                    nivel4 = 1;
                }
            }
         
            





            if (player.vida1 <= 0)
            {
                player.Colision3(gameTime);

               /* if(player.Derecha == 1)
                muerte.eleva(gameTime);

                if (player.Izquierda == 1)*/

                if (murio != 1)
                {
                    if (nivel1 == 1)
                    {
                        cambionivel = 11;
                    }
                    if (nivel2 == 1)
                    {
                        cambionivel = 12;
                    }
                    if (nivel3 == 1)
                    {
                        cambionivel = 13;
                    }
                    if (nivel4 == 1)
                    {
                        cambionivel = 14;
                    }
                    if (nivel5 == 1)
                    {
                        cambionivel = 15;
                    }
                }
                murio = 1;
                
                    muerte.eleva(gameTime);

            }

            if (player2.vida1 <= 0)
            {
                if (murio != 1)
                {
                    if (nivel1 == 1)
                    {
                        cambionivel = 21;
                    }
                    if (nivel2 == 1)
                    {
                        cambionivel = 22;
                    }
                    if (nivel3 == 1)
                    {
                        cambionivel = 23;
                    }
                    if (nivel4 == 1)
                    {
                        cambionivel = 24;
                    }
                    if (nivel5 == 1)
                    {
                        cambionivel = 25;
                    }
                }
                murio = 1;


                player2.Colision3(gameTime);
                muerte2.eleva4(gameTime);
            }

            



            bgolden = new BoundingBox(new Vector3(player.Pos.X, player.Pos.Y, 0), new Vector3(player.Pos.X + 30, player.Pos.Y + 50, 0));
            bgolden2 = new BoundingBox(new Vector3(player2.Pos.X, player2.Pos.Y, 0), new Vector3(player2.Pos.X + 30, player2.Pos.Y + 50, 0));
            player.atacando = false;
            player2.atacando = false;



            if (bgolden.Intersects(bgolden2))
            {
                if (player2.moviendose == true && player.Pos.X > player2.Pos.X)
                {
                    //player2.Pos.X -= 4;
                    player2.Colision1(gameTime);
                }


                if (player2.moviendose == true && player.Pos.X < player2.Pos.X)
                {
                    //player2.Pos.X += 4;
                    player2.Colision2(gameTime);
                }

                if (player.moviendose == true && player.Pos.X < player2.Pos.X)
                {
                    //player.Pos.X -= 4;
                    player.Colision1(gameTime);
                }
                if (player.moviendose == true && player.Pos.X > player2.Pos.X)
                {
                    //player.Pos.X += 4;
                    player.Colision2(gameTime);
                }
               
            }

            if (gameover == 1) {

                Boton.Click = false;
                CurrentGameState = GameState.GameOver;
            }
            pega++;
            KeyboardState keystate;

            keystate = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (Boton.Click == true)
                        CurrentGameState = GameState.Loading;
                    Boton.Update(mouse);

                    if (Boton2.Click == true)
                        CurrentGameState = GameState.Exit;
                    Boton2.Update(mouse);
                    if (CurrentGameState == GameState.Exit)
                    {
                        this.Exit();

                        
                    }
                    break;

            }
            if (CurrentGameState == GameState.Loading)
            {
                cifra++;
                if (cifra > 200)
                {
                    CurrentGameState = GameState.Play;
                    cifra = 0;
                }
            }
            if (CurrentGameState == GameState.GameOver)
            {
                if (Boton3.Click == true)
                {

                  
                    
                    CurrentGameState = GameState.MainMenu;
                    gameover = 0;
                    perdiste = 0;
                    juegoganado = 0;
                    nivel1 = 1;
                    player.vida1 = 100;
                    player2.vida1 = 100;
                    player.cargando1(gameTime);
                    player2.cargando1(gameTime);
                  
                   
                }

                Boton3.Update(mouse);

                if (Boton4.Click == true)
                    CurrentGameState = GameState.Exit;
                Boton4.Update(mouse);
                if (CurrentGameState == GameState.Exit)
                {
                    this.Exit();
                }
            }
            if (CurrentGameState == GameState.Play)
            {
                Time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                lvl.caida(gameTime);

                if (reproducir < 10)
                    reproducir++;
                if (reproducir == 1)
                {
                    temaflema.Play();
                }

                if (player.vida1 <= 0 && player2.vida1 <=0)
                {
                    perdiste = 1;
                    gameover = 1;
                }
                if (matados > 17)
                {

                    nivel4 = 0;

                    juegoganado = 1;
                    gameover = 1;
                    Boton.Click = false;


                }
                if (player.vida1 > 0)
                {
                    muerte = new Muerte(Content, 0, new Vector2(player.Pos.X, player.Pos.Y + 375));


                  if (oknivel2 != 0 && oknivel5 != 0)
                   {
                        if (keystate.IsKeyDown(Keys.Up))
                        {
                           
                            player.Up(gameTime);
                            player.moviendose = true;
                        }
                        else if (keystate.IsKeyDown(Keys.Down))
                        {
                            player.Down(gameTime);
                            player.moviendose = true;
                        }
                        else if (keystate.IsKeyDown(Keys.LeftControl))
                        {
                            player.Attack(gameTime);
                           
                        }

                        else if (keystate.IsKeyDown(Keys.Left))
                        {
                            player.Left(gameTime);
                            player.moviendose = true;
                        }
                        else if (keystate.IsKeyDown(Keys.Right))
                        {
                            player.Right(gameTime);
                            player.moviendose = true;
                        }
                        else
                        {
                            if (!player.atacando)
                            {
                                player.Stand(gameTime);
                                player.moviendose = false;
                            }

                       }
                    }
                }
                if (player2.vida1 > 0)

                {
                    muerte2 = new Muerte(Content, 0, new Vector2(player2.Pos.X, player2.Pos.Y +375));
                    if (oknivel2 != 0 && oknivel5 != 0)
                   {
                        if (keystate.IsKeyDown(Keys.W))
                        {
                            player2.Up(gameTime);
                            player2.moviendose = true;
                        }
                        else if (keystate.IsKeyDown(Keys.S))
                        {
                            player2.Down(gameTime);
                            player2.moviendose = true;
                        }
                        else if (keystate.IsKeyDown(Keys.Space))
                        {
                            player2.Attack(gameTime);
                      
                        }
                        else if (keystate.IsKeyDown(Keys.A))
                        {
                            player2.Left(gameTime);
                            player2.moviendose = true;
                        }
                        else if (keystate.IsKeyDown(Keys.D))
                        {
                            player2.Right(gameTime);
                            player2.moviendose = true;


                        }
                        else
                        {
                            if (!player2.atacando)
                            {
                                player2.Stand(gameTime);
                                player2.moviendose = false;
                            }
                        }
                    }
                }

                if (player.Pos.Y < player2.Pos.Y)
                {
                    player.pospner(0.1f);
                    player2.pospner(0);
                }
                else
                {
                    player.pospner(0);
                    player2.pospner(0.1f);
                }

                if (nivel5 == 1) {

                    

                    lvl3.caida(gameTime);

                    Random r = new Random();

                    tiempo++;
                    if (tiempo >= aparicion)
                    {
                        if (hola < 5)
                        {
                            enemigo = new enemigo(Content, hola++, new Vector2(800, r.Next(0, 160)), 0.11f);
                            enemigo.Pos = new Vector2(800, r.Next(20, 100));
                            listaEnemigos.Add(enemigo);
                        }
                        tiempo = 0;
                    }
                    foreach (enemigo enemi in listaEnemigos)
                    {
                        enemi.Right(gameTime);
                        muerte7 = new Muerte(Content, 0, new Vector2(enemi.Pos.X, enemi.Pos.Y + 375));
                        bgolden3 = new BoundingBox(new Vector3(enemi.Pos.X, enemi.Pos.Y, 0), new Vector3(enemi.Pos.X + 30, enemi.Pos.Y + 20, 0));
                        if (bgolden.Intersects(bgolden3))
                        {
                            contador++;
                            pega2++;
                            if (pega2 > 100 && player.vida1 != 0)
                            {
                                player.vida1--;
                                pega2 = 0;
                            }
                            if (player.Pos.X > enemi.Pos.X)
                            {
                                //player2.Pos.X -= 4;
                                enemi.Colision1(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player.score1 = player.score1 + 50;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;


                            }
                            if (player.Pos.X < enemi.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                enemi.Colision2(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player.score1 = player.score1 + 50;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.moviendose == true && player.Pos.X < enemi.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player.Colision1(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player.score1 = player.score1 + 50;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.moviendose == true && player.Pos.X > enemi.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player.Colision2(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player.score1 = player.score1 + 50;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;


                            }
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        //--------------------------------------------------------------------------------------------------------------------
                        if (bgolden2.Intersects(bgolden3))
                        {
                            pega3++;
                            if (pega3 > 100 && player2.vida1 != 0)
                            {
                                player2.vida1--;
                                pega3 = 0;
                            }
                            if (player2.Pos.X > enemi.Pos.X)
                            {
                                enemi.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player2.score1 = player2.score1 + 50;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;


                            }
                            if (player2.Pos.X < enemi.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                enemi.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player2.score1 = player2.score1 + 50;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X < enemi.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player2.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player2.score1 = player2.score1 + 50;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X > enemi.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player2.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto7 = 1;
                                    listaEnemigos.Remove(enemi);
                                    player2.score1 = player2.score1 + 50;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;


                            }
                            player2.moviendose = false;
                            player2.atacando = false;
                        }

                    }
                    if (muerto7 == 1)
                    {
                        muerte7.eleva6(gameTime);
                        contador7++;

                        if (contador7 == 50)
                        {
                            muerto7 = 0;
                            contador7 = 0;
                        }
                    }
                    //----------------------------------------------------------------------------------------------------------------------------------
                    Random x = new Random();


                    tiempo1++;
                    if (tiempo1 >= aparicion2)
                    {
                        if (hola1 < 5)
                        {
                            enemigoa = new enemigoA(Content, hola1++, new Vector2(800, x.Next(0, 160)));
                            enemigoa.Pos = new Vector2(800, x.Next(20, 100));
                            listaEnemigosA.Add(enemigoa);
                        }
                        tiempo1 = 0;
                    }
                    foreach (enemigoA enemiA in listaEnemigosA)
                    {
                        enemiA.Right(gameTime);
                        muerte6 = new Muerte(Content, 0, new Vector2(enemiA.Pos.X, enemiA.Pos.Y + 375));

                        bgolden4 = new BoundingBox(new Vector3(enemiA.Pos.X, enemiA.Pos.Y, 0), new Vector3(enemiA.Pos.X + 30, enemiA.Pos.Y + 20, 0));
                        if (bgolden.Intersects(bgolden4))
                        {
                            contador++;
                            if (pega2 > 100 && player.vida1 != 0)
                            {
                                player.vida1--;
                                pega2 = 0;

                            }

                            if (player.Pos.X > enemiA.Pos.X)
                            {
                                //player2.Pos.X -= 4;
                                enemiA.Colision1(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player.vida1 = player.vida1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;
                                pega2++;

                            }
                            if (player.Pos.X < enemiA.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                enemiA.Colision2(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player.vida1 = player.vida1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.moviendose == true && player.Pos.X < enemiA.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player.Colision1(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player.vida1 = player.vida1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.moviendose == true && player.Pos.X > enemiA.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player.Colision2(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player.vida1 = player.vida1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        //------------------------------------------------------------------------------------------------------------------------
                        if (bgolden2.Intersects(bgolden4))
                        {
                            if (pega3 > 100 && player2.vida1 != 0)
                            {
                                player2.vida1--;
                                pega3 = 0;

                            }

                            if (player2.Pos.X > enemiA.Pos.X)
                            {
                                //player2.Pos.X -= 4;
                                enemiA.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player2.vida1 = player2.vida1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;
                                pega2++;

                            }
                            if (player2.Pos.X < enemiA.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                enemiA.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player2.vida1 = player2.vida1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X < enemiA.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player2.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player2.vida1 = player2.vida1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X > enemiA.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player2.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto6 = 1;
                                    listaEnemigosA.Remove(enemiA);
                                    player2.vida1 = player2.vida1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            player2.moviendose = false;
                            player2.atacando = false;
                        }
                    }
                    if (muerto6 == 1)
                    {
                        muerte6.eleva6(gameTime);
                        contador6++;

                        if (contador6 == 50)
                        {
                            muerto6 = 0;
                            contador6 = 0;
                        }
                    }
                }


                if (nivel1 == 1)
                {
                   /* if (reproducir2 < 10)
                        reproducir2++;
                    if (reproducir2 == 1)
                    {
                        song2.Play();
                    }
                    */
                   
                    //------------------------------------------------------------------------------------------------------------------------------
                    Random z = new Random();


                    tiempo3++;
                    if (tiempo3 >= aparicion4)
                    {
                        if (hola2 < 1)
                        {
                            enemigob = new enemigoB(Content, hola2++, new Vector2(800, z.Next(0, 160)));
                            enemigob.Pos = new Vector2(800, z.Next(20, 100));
                            listaEnemigosB.Add(enemigob);
                        }
                        tiempo3 = 0;
                    }
                    foreach (enemigoB enemiB in listaEnemigosB)
                    {
                        enemiB.HK(gameTime);
                        enemiB.Disparo(gameTime, Content);
                        muerte5 = new Muerte(Content, 0, new Vector2(enemiB.Pos.X, enemiB.Pos.Y + 375));
                        bgolden5 = new BoundingBox(new Vector3(enemiB.Pos.X+0, enemiB.Pos.Y, 0), new Vector3(enemiB.Pos.X + 30, enemiB.Pos.Y + 30, 0));
                        enemiB.Bgolden = bgolden;
                        enemiB.Bgolden2 = bgolden2;
                        if (enemiB.Vida1 == 1)
                        {
                            player.vida1 = player.vida1 - 10;
                            enemiB.Vida1 = 0;
                        }
                        if (enemiB.Vida2 == 1)
                        {
                            player2.vida1 = player2.vida1 - 10;
                            enemiB.Vida2 = 0;
                        }

                        if (bgolden.Intersects(bgolden5))
                        {
                            contador++;
                            pega2++;
                            if (pega2 > 100 && player.vida1 != 0)
                            {
                                player.vida1--;
                                pega2 = 0;

                            }

                            if (player.Pos.X < enemiB.Pos.X)
                            {
                                //player2.Pos.X -= 4;
                                player.Colision1(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto5 = 1;
                                    listaEnemigosB.Remove(enemiB);
                                    player.score1 = player.score1 + 1;
                                    matados++;
                                    hola2--;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                           
                        
                            if (player.moviendose == true && player.Pos.X < enemiB.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player.Colision1(gameTime);
                                enemiB.Colision2(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto5 = 1;
                                    listaEnemigosB.Remove(enemiB);
                                    player.score1 = player.score1 + 1;
                                    matados++;
                                    hola2--;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;



                            }
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        //---------------------------------------------------------------------------------------------------------
                        if (bgolden2.Intersects(bgolden5))
                        {
                            pega3++;
                            if (pega3 > 100 && player2.vida1 != 0)
                            {
                                player2.vida1--;
                                pega3 = 0;

                            }

                            if (player2.Pos.X > enemiB.Pos.X)
                            {
                                //player2.Pos.X -= 4;
                                enemiB.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto5 = 1;
                                    listaEnemigosB.Remove(enemiB);
                                    player2.score1 = player2.score1 + 1;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.Pos.X < enemiB.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                enemiB.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto5 = 1;
                                    listaEnemigosB.Remove(enemiB);
                                    player2.score1 = player2.score1 + 1;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X < enemiB.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player2.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto5 = 1;
                                    listaEnemigosB.Remove(enemiB);
                                    player2.score1 = player2.score1 + 1;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;


                            }
                            if (player2.moviendose == true && player2.Pos.X > enemiB.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player2.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto5 = 1;
                                    listaEnemigosB.Remove(enemiB);
                                    player2.score1 = player2.score1 + 1;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;



                            }
                            player2.moviendose = false;
                            player2.atacando = false;

                        }
                       
                    }
                    if (muerto5 == 1)
                    {
                        muerte5.eleva3(gameTime);
                        contador5++;

                        if (contador5 == 50)
                        {
                            muerto5 = 0;
                            contador5 = 0;
                        }
                    }
                    //------------------------------------------------------------------------------------------------------------------------------
                    Random k = new Random();


                    tiempo4++;
                    if (tiempo4 >= aparicion3)
                    {

                        if (hola3 < 50)
                        {
                            enemigoc = new enemigoC(Content, hola3++, new Vector2(800, k.Next(0, 160)));
                            enemigoc.Pos = new Vector2(800, k.Next(20, 100));
                            listaEnemigosC.Add(enemigoc);
                        }

                        tiempo4 = 0;
                    }
                   
                    foreach (enemigoC enemiC in listaEnemigosC)
                    {
                        enemiC.kh(gameTime);

                        muerte3 = new Muerte(Content, 0, new Vector2(enemiC.Pos.X, enemiC.Pos.Y+375 ));

                        

                        bgolden6 = new BoundingBox(new Vector3(enemiC.Pos.X, enemiC.Pos.Y, 0), new Vector3(enemiC.Pos.X + 30, enemiC.Pos.Y + 20, 0));
                        if (bgolden.Intersects(bgolden6))
                        {
                            contador++;
                            pega2++;
                            if (pega2 > 10 && player.vida1 != 0)
                            {
                                player.vida1--;
                                pega2 = 0;

                            }
                            if (player.Pos.X > enemiC.Pos.X)
                            {
                                //player2.Pos.X -= 4;
                                enemiC.Colision1(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto3 = 1;
                                   
                                    listaEnemigosC.Remove(enemiC);
                                    player.score1 = player.score1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;


                            }
                            if (player.Pos.X < enemiC.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                enemiC.Colision2(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto3 = 1;
                                    
                                    listaEnemigosC.Remove(enemiC);
                                    player.score1 = player.score1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;


                            }
                            if (player.moviendose == true && player.Pos.X < enemiC.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player.Colision1(gameTime);
                               
                                if (player.atacando == true)
                                {
                                    muerto3 = 1;
                                   
                                    listaEnemigosC.Remove(enemiC);
                                    player.score1 = player.score1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.moviendose == true && player.Pos.X > enemiC.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player.Colision2(gameTime);
                                
                                if (player.atacando == true)
                                {
                                    muerto3 = 1;
                                    
                                    listaEnemigosC.Remove(enemiC);
                                    player.score1 = player.score1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;


                            }
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        if (bgolden2.Intersects(bgolden6))
                        {
                            contador++;
                            pega3++;
                            if (pega3 > 10 && player2.vida1 != 0)
                            {
                                player2.vida1--;
                                pega3 = 0;

                            }
                            if (player2.Pos.X > enemiC.Pos.X)
                            {
                                //player2.Pos.X -= 4;
                                enemiC.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto3 = 1;
                                    listaEnemigosC.Remove(enemiC);
                                    player2.score1 = player2.score1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;


                            }
                            if (player2.Pos.X < enemiC.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                enemiC.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto3 = 1;
                                    listaEnemigosC.Remove(enemiC);
                                    player2.score1 = player2.score1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;


                            }
                            if (player2.moviendose == true && player2.Pos.X < enemiC.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player2.Colision1(gameTime);

                                if (player2.atacando == true)
                                {
                                    muerto3 = 1;
                                    listaEnemigosC.Remove(enemiC);
                                    player2.score1 = player2.score1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X > enemiC.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player2.Colision2(gameTime);

                                if (player2.atacando == true)
                                {
                                    muerto3 = 1;
                                    listaEnemigosC.Remove(enemiC);
                                    player2.score1 = player2.score1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;


                            }
                            player2.moviendose = false;
                            player2.atacando = false;
                        }

                    }

                    if (muerto3 == 1)
                    {
                        muerte3.eleva3(gameTime);
                        contador3++;

                        if (contador3 == 50)
                        {
                            muerto3 = 0;
                            contador3 = 0;
                        }
                    }
                    //------------------------------------------------------------------------------------------------------------------------------
                    Random h = new Random();


                    tiempo5++;
                    if (tiempo5 >= aparicion5)
                    {

                        if (hola5 < 4)
                        {
                            enemigod = new enemigoD(Content, hola5++, new Vector2(800, h.Next(0, 160)));
                            listaEnemigosD.Add(enemigod);
                        }

                        tiempo5 = 0;
                    }
                    foreach (enemigoD enemiD in listaEnemigosD)
                    {
                        enemiD.RK(gameTime);
                        bgolden8 = new BoundingBox(new Vector3(enemiD.Pos.X, enemiD.Pos.Y, 0), new Vector3(enemiD.Pos.X + 30, enemiD.Pos.Y + 20, 0));
                        muerte4 = new Muerte(Content, 0, new Vector2(enemiD.Pos.X, enemiD.Pos.Y + 375));
                        if (bgolden.Intersects(bgolden8))
                        {
                            contador++;
                            pega2++;
                            if (pega2 > 10 && player.vida1 != 0)
                            {
                                player.vida1--;
                                pega2 = 0;

                            }
                            if (player.Pos.X > enemiD.Pos.X)
                            {
                                if (enemiD.Atacando == 0)
                                enemiD.Colision1(gameTime);

                                if (player.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player.score1 = player.score1 + 25;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.Pos.X < enemiD.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                if(enemiD.Atacando ==0)
                                enemiD.Colision2(gameTime);

                                if (player.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player.score1 = player.score1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.moviendose == true && player.Pos.X < enemiD.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player.Colision1(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player.score1 = player.score1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if (player.moviendose == true && player.Pos.X > enemiD.Pos.X)
                            {
                                //player.Pos.X += 4;

                                player.Colision2(gameTime);
                                if (player.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player.score1 = player.score1 + 10;
                                    matados++;
                                    player.atacando = false;
                                    break;
                                } player.atacando = false;

                            }
                            if ( player.Pos.X < enemiD.Pos.X && enemiD.Atacando ==1)
                            {

                                player.vida1 = player.vida1 - 1/2;

                            }
                            if ( player.Pos.X > enemiD.Pos.X && enemiD.Atacando == 1)
                            {
                                player.vida1 = player.vida1 - 1/2;
                            }
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        if (bgolden2.Intersects(bgolden8))
                        {
                            contador++;
                            pega3++;
                            if (pega3 > 10 && player2.vida1 != 0)
                            {
                                player2.vida1--;
                                pega3 = 0;

                            }
                            if (player2.Pos.X > enemiD.Pos.X)
                            {
                                if (enemiD.Atacando == 0)
                                    enemiD.Colision1(gameTime);

                                if (player2.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player2.score1 = player2.score1 + 25;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.Pos.X < enemiD.Pos.X)
                            {
                                //player2.Pos.X += 4;
                                if (enemiD.Atacando == 0)
                                    enemiD.Colision2(gameTime);

                                if (player2.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player2.score1 = player2.score1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X < enemiD.Pos.X)
                            {
                                //player.Pos.X -= 4;
                                player2.Colision1(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player2.score1 = player2.score1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X > enemiD.Pos.X)
                            {
                                //player.Pos.X += 4;

                                player2.Colision2(gameTime);
                                if (player2.atacando == true)
                                {
                                    muerto4 = 1;
                                    listaEnemigosD.Remove(enemiD);
                                    player2.score1 = player2.score1 + 10;
                                    matados++;
                                    player2.atacando = false;
                                    break;
                                } player2.atacando = false;

                            }
                            if (player2.moviendose == true && player2.Pos.X < enemiD.Pos.X && enemiD.Atacando == 1)
                            {

                                player2.vida1 = player2.vida1 - 10;

                            }
                            if (player2.moviendose == true && player2.Pos.X > enemiD.Pos.X && enemiD.Atacando == 1)
                            {
                                player2.vida1 = player2.vida1 - 10;
                            }
                            player2.moviendose = false;
                            player2.atacando = false;
                        }
                        
                    }
                    if (muerto4 == 1)
                    {
                        muerte4.eleva3(gameTime);
                        contador4++;

                        if (contador4 == 50)
                        {
                            muerto4 = 0;
                            contador4 = 0;
                        }
                    }
                    //-------------------------------------------------------------------------------------------------------------------
                    Random W = new Random();

                    tiempo2++;
                    if (tiempo2 >= aparicionfuego)
                    {
                        if (fire < 50000000)
                        {
                            explosion = new Fuego(Content, fire++,1, new Vector2(W.Next(0, 750), 0));

                            listaFuego.Add(explosion);
                        }
                        tiempo2 = 0;
                    }
                    foreach (Fuego Boom in listaFuego)
                    {
                        bgolden7 = new BoundingBox(new Vector3(Boom.Pos.X, Boom.Pos.Y - 375, 0), new Vector3(Boom.Pos.X, Boom.Pos.Y - 355, 0));
                        if (bgolden.Intersects(bgolden7))
                        {
                            player.vida1 = player.vida1 - 10;
                            listaFuego.Remove(Boom);
                            break;
                        }
                        if (bgolden2.Intersects(bgolden7))
                        {
                            player2.vida1 = player2.vida1 - 10;
                            listaFuego.Remove(Boom);
                            break;
                        }
                        Boom.caida(gameTime);
                        Boom.stand(gameTime);
                        Boom.boom(gameTime);
                    }
                }
                //-----------------------
                if (nivel2 == 1)
                {


                    contadornivel2++;
                    if (contadornivel2 > 250)
                    {
                        oknivel2 = 1;
                    }
                    else {
                        oknivel2 = 0;
                    }

                    bgolden9 = new BoundingBox(new Vector3(guardian.Pos.X, guardian.Pos.Y, 0), new Vector3(guardian.Pos.X + 30, guardian.Pos.Y + 50, 0));
                    bgolden10 = new BoundingBox(new Vector3(Domo.Pos.X, Domo.Pos.Y, 0), new Vector3(Domo.Pos.X + 60, Domo.Pos.Y + 35, 0));
                    bgolden11 = new BoundingBox(new Vector3(guardian2.Pos.X, guardian2.Pos.Y, 0), new Vector3(guardian2.Pos.X + 30, guardian2.Pos.Y + 50, 0));
                    bgolden12 = new BoundingBox(new Vector3(Domo.Pos.X-15, Domo.Pos.Y-5, 0), new Vector3(Domo.Pos.X + 60, Domo.Pos.Y + 70, 0));
                    if (mago.Vida2 > 0)
                    {
                        if (bgolden.Intersects(bgolden10))
                        {
                            contador++;

                            if (player.Pos.X > mago.Posicion.X)
                            {
                               

                                if (player.atacando == true)
                                {
                                    mago.Vida2--;
                                    player.atacando = false;

                                } player.atacando = false;


                            }
                            if (player.Pos.X < mago.Posicion.X)
                            {
                               
                                if (player.atacando == true)
                                {

                                    mago.Vida2--;
                                    player.atacando = false;
                                    ;
                                } player.atacando = false;


                            }
                           
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        if (bgolden2.Intersects(bgolden10))
                        {
                            if (player2.Pos.X > mago.Posicion.X)
                            {
                                

                                if (player2.atacando == true)
                                {
                                    mago.Vida2--;
                                    player2.atacando = false;

                                } player2.atacando = false;


                            }
                            if (player2.Pos.X < mago.Posicion.X)
                            {
                                
                                if (player2.atacando == true)
                                {

                                    mago.Vida2--;
                                    player2.atacando = false;
                                    ;
                                } player2.atacando = false;


                            }
                           
                            player2.moviendose = false;
                            player2.atacando = false;
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------------

                    if (bgolden.Intersects(bgolden9))
                    {
                        contador++;
                        pega2++;
                        if (pega2 > 10 && player.vida1 != 0)
                        {
                            player.vida1--;
                            pega2 = 0;

                        }

                        if (player.Pos.X > guardian.Pos.X)
                        {
                            player.Colision2(gameTime);
                            if (player.atacando == true)
                            {
                                player.atacando = false;

                            } player.atacando = false;

                        }
                        if (player.Pos.X < guardian.Pos.X)
                        {
                            
                            player.Colision1(gameTime);
                            if (player.atacando == true)
                            {


                                player.atacando = false;

                            } player.atacando = false;

                        }
                        if (player.moviendose == true && player.Pos.X < guardian.Pos.X)
                        {
                            player.Colision1(gameTime);
                            player.Colision1(gameTime);
                            if (player.atacando == true)
                            {


                                player.atacando = false;

                            } player.atacando = false;
                        }
                        if (player.moviendose == true && player.Pos.X > guardian.Pos.X)
                        {
                            player.Colision2(gameTime);
                            player.Colision2(gameTime);
                            if (player.atacando == true)
                            {


                                player.atacando = false;

                            } player.atacando = false;
                        }


                        if (player.Pos.X < guardian.Pos.X && guardian.Atacando == 1)
                        {

                            player.vida1 = player.vida1 - 10;

                        }
                        if (player.Pos.X > guardian.Pos.X && guardian.Atacando == 1)
                        {
                            player.vida1 = player.vida1 - 10;
                        }
                        player.moviendose = false;
                        player.atacando = false;
                    }

                    //------
                    if (bgolden2.Intersects(bgolden9))
                    {

                        pega3++;
                        if (pega3 > 10 && player2.vida1 != 0)
                        {
                            player2.vida1--;
                            pega3 = 0;

                        }

                        if (player2.Pos.X > guardian.Pos.X)
                        {
                            player2.Colision2(gameTime);
                            
                        }
                        if (player2.Pos.X < guardian.Pos.X)
                        {

                            player2.Colision1(gameTime);
                          

                        }
                        if (player2.moviendose == true && player2.Pos.X < guardian.Pos.X)
                        {
                            player2.Colision1(gameTime);
                            player2.Colision1(gameTime);
                          
                        }
                        if (player2.moviendose == true && player2.Pos.X > guardian.Pos.X)
                        {
                            player2.Colision2(gameTime);
                            player2.Colision2(gameTime);
                          
                        }
                        if (player2.Pos.X < guardian.Pos.X && guardian.Atacando == 1)
                        {

                            player2.vida1 = player2.vida1 - 10;

                        }
                        if (player2.Pos.X > guardian.Pos.X && guardian.Atacando == 1)
                        {
                            player2.vida1 = player2.vida1 - 10;
                        }
                        player2.moviendose = false;
                        player2.atacando = false;
                    }
                    //-------------------------------------------------------------------------------------------------

                    if (bgolden.Intersects(bgolden11))
                    {
                        contador++;
                        pega2++;
                        if (pega2 > 10 && player.vida1 != 0)
                        {
                            player.vida1--;
                            pega2 = 0;

                        }
                        if (player.Pos.X > guardian2.Pos.X)
                        {
                            player.Colision2(gameTime);
                            if (player.atacando == true)
                            {


                                player.atacando = false;

                            } player.atacando = false;


                        }
                        if (player.Pos.X < guardian2.Pos.X)
                        {
                            player.Colision1(gameTime);
                            if (player.atacando == true)
                            {
                                player.atacando = false;

                            } player.atacando = false;

                        }
                        if (player.moviendose == true && player.Pos.X < guardian2.Pos.X)
                        {
                            player.Colision1(gameTime);
                            player.Colision1(gameTime);
                            if (player.atacando == true)
                            {


                                player.atacando = false;

                            } player.atacando = false;

                        }
                        if (player.moviendose == true && player.Pos.X > guardian2.Pos.X)
                        {
                            //player.Pos.X += 4;
                            player.Colision2(gameTime);
                            player.Colision2(gameTime);
                            if (player.atacando == true)
                            {


                                player.atacando = false;

                            } player.atacando = false;



                        }
                        if (player.Pos.X < guardian2.Pos.X && guardian2.Atacando == 1)
                        {

                            player.vida1 = player.vida1 - 10;

                        }
                        if (player.Pos.X > guardian2.Pos.X && guardian2.Atacando == 1)
                        {
                            player.vida1 = player.vida1 - 10;
                        }
                        player.moviendose = false;
                        player.atacando = false;

                    }


                        if (bgolden2.Intersects(bgolden11))
                        {
                            pega3++;
                            if (pega3 > 10 && player2.vida1 != 0)
                            {
                                player2.vida1--;
                                pega3 = 0;

                            }
                            if (player2.Pos.X > guardian2.Pos.X)
                            {
                                player2.Colision2(gameTime);
                          

                            }
                            if (player2.Pos.X < guardian2.Pos.X)
                            {
                                player2.Colision1(gameTime);
                              
                            }
                            if (player2.moviendose == true && player2.Pos.X < guardian2.Pos.X)
                            {
                                player2.Colision1(gameTime);
                                player2.Colision1(gameTime);
                               
                            
                            }
                            if (player2.moviendose == true && player2.Pos.X > guardian2.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player2.Colision2(gameTime);
                                player2.Colision2(gameTime);
                  

                            }
                            if (player2.Pos.X < guardian2.Pos.X && guardian2.Atacando == 1)
                            {

                                player2.vida1 = player2.vida1 - 10;

                            }
                            if (player2.Pos.X > guardian2.Pos.X && guardian2.Atacando == 1)
                            {
                                player2.vida1 = player2.vida1 - 10;
                            }
                            player2.moviendose = false;
                            player2.atacando = false;

                        }
                    //--------------------------------------------------------------------------------------------------------------------
                    if (Domo.activo == true)
                    {
                        if (bgolden.Intersects(bgolden12))
                        {
                            contador++;
                            pega2++;
                            if (pega2 > 10 && player.vida1 != 0)
                            {
                                player.vida1--;
                                pega2 = 0;
                            }

                            if (player.Pos.X < Domo.Pos.X)
                            {
                                player.Colision5(gameTime);
                            }
                            if (player.Pos.X > Domo.Pos.X)
                            {
                                player.Colision4(gameTime);
                            }
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        if (bgolden2.Intersects(bgolden12))
                        {
                            pega3++;
                            if (pega3 > 10 && player2.vida1 != 0)
                            {
                                player2.vida1--;
                                pega3 = 0;
                            }

                            if (player2.Pos.X < Domo.Pos.X)
                            {
                                player2.Colision5(gameTime);
                            }
                            if (/*player2.moviendose == true &&*/ player2.Pos.X > Domo.Pos.X)
                            {
                                player2.Colision4(gameTime);
                            }
                            player2.moviendose = false;
                            player2.atacando = false;
                        }
                    }
                    mago.Bgolden = bgolden;
                    mago.Bgolden2 = bgolden2;
                    if (mago.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        mago.Vida1 = 0;
                    }
                    if (mago.Vida3 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        mago.Vida3 = 0;
                    }
                    if (mago.Vida2 == 0)
                    {
                        player.score1 = player.score1 + 200;
                        player2.score1 = player2.score1 + 200;
                        matados++;
                        mago.Vida2 = -1;
                    }


                    Time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    Domo.Domo(gameTime);

                    if (mago.Vida2 > 0)
                    {
                        mago.Right(gameTime);
                        mago.Disparo(gameTime, Content);

                    }

                    vortice.vacio_timer(gameTime);
                    vortice2.vacio_timer(gameTime);


                    guardian.Right(gameTime);

                    guardian2.Right2(gameTime);

                    lvl2.caida(gameTime);
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                if (nivel3 == 1)
                {
                    
                    lvl4.caida(gameTime);

                    Time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (Boss.Vida3 > 0)
                    {
                        Boss.Right(gameTime);
                        Boss.Disparo(gameTime, Content);
                    }
                    dragon1.Disparo(gameTime, Content);
                    dragon2.Disparo2(gameTime, Content);
                    dragon3.Disparo(gameTime, Content);
                    dragon4.Disparo2(gameTime, Content);
                    dragon5.Disparo(gameTime, Content);
                    dragon6.Disparo2(gameTime, Content);
                    dragon7.Disparo(gameTime, Content);

                    if (Boss.Vida3 == 0)
                    {
                        player.score1 = player.score1 + 100;
                        player2.score1 = player2.score1 + 100;
                        matados++;
                        Boss.Vida3 = -1;
                    }
                    if (Boss.Vida3 > 0)
                    {
                        bgolden13 = new BoundingBox(new Vector3(Boss.Pos.X, Boss.Pos.Y, 0), new Vector3(Boss.Pos.X + 30, Boss.Pos.Y + 30, 0));
                        if (bgolden.Intersects(bgolden13))
                        {
                            contador++;
                            if (player.Pos.X > Boss.Pos.X)
                            {
                                // guardian2.Colision1(gameTime);
                                if (player.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player.atacando = false;

                                } player.atacando = false;
                            }
                            if (player.Pos.X < Boss.Pos.X)
                            {
                                //  guardian2.Colision2(gameTime);
                                if (player.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player.atacando = false;

                                } player.atacando = false;
                            }
                            if (player.moviendose == true && player.Pos.X < Boss.Pos.X)
                            {
                                player.Colision1(gameTime);
                                if (player.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player.atacando = false;

                                } player.atacando = false;
                            }
                            if (player.moviendose == true && player.Pos.X > Boss.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player.Colision2(gameTime);
                                if (player.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player.atacando = false;

                                } player.atacando = false;
                            }
                            player.moviendose = false;
                            player.atacando = false;
                        }
                        if (bgolden2.Intersects(bgolden13))
                        {
                            contador++;
                            if (player2.Pos.X > Boss.Pos.X)
                            {
                                // guardian2.Colision1(gameTime);
                                if (player2.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player2.atacando = false;

                                } player2.atacando = false;
                            }
                            if (player2.Pos.X < Boss.Pos.X)
                            {
                                //  guardian2.Colision2(gameTime);
                                if (player2.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player2.atacando = false;

                                } player2.atacando = false;
                            }
                            if (player2.moviendose == true && player2.Pos.X < Boss.Pos.X)
                            {
                                player2.Colision1(gameTime);
                                if (player2.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player2.atacando = false;

                                } player2.atacando = false;
                            }
                            if (player2.moviendose == true && player2.Pos.X > Boss.Pos.X)
                            {
                                //player.Pos.X += 4;
                                player2.Colision2(gameTime);
                                if (player2.atacando == true)
                                {

                                    Boss.Vida3--;
                                    player2.atacando = false;

                                } player2.atacando = false;
                            }
                            player2.moviendose = false;
                            player2.atacando = false;
                        }
                    }


                    Boss.Bgolden = bgolden;
                    Boss.Bgolden2 = bgolden2;
                    if (Boss.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        Boss.Vida1 = 0;
                    }
                    if (Boss.Vida2 == 1)
                    {
                        player2.vida1 = player.vida1 - 10;
                        Boss.Vida2 = 0;
                    }




                    dragon1.Bgolden = bgolden;
                    if (dragon1.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        dragon1.Vida1 = 0;
                    }

                    dragon1.Bgolden2 = bgolden2;
                    if (dragon1.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon1.Vida2 = 0;
                    }

                    dragon2.Bgolden = bgolden;
                    if (dragon2.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        dragon2.Vida1 = 0;
                    }
                    dragon2.Bgolden2 = bgolden2;
                    if (dragon2.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon2.Vida2 = 0;
                    }
                    dragon3.Bgolden = bgolden;
                    if (dragon3.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        dragon3.Vida1 = 0;
                    }
                    dragon3.Bgolden2 = bgolden2;
                    if (dragon3.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon3.Vida2 = 0;
                    }
                    dragon4.Bgolden = bgolden;
                    if (dragon4.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        dragon4.Vida1 = 0;
                    }
                    dragon4.Bgolden2 = bgolden2;
                    if (dragon4.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon4.Vida2 = 0;
                    }
                    dragon5.Bgolden = bgolden;
                    if (dragon5.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        dragon5.Vida1 = 0;
                    }
                    dragon5.Bgolden2 = bgolden2;
                    if (dragon5.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon5.Vida2 = 0;
                    }
                    dragon6.Bgolden = bgolden;
                    if (dragon6.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        dragon6.Vida1 = 0;
                    }
                    dragon6.Bgolden2 = bgolden2;
                    if (dragon6.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon6.Vida2 = 0;
                    }
                    dragon7.Bgolden = bgolden;
                    if (dragon7.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        dragon7.Vida1 = 0;
                    }
                   dragon7.Bgolden2 = bgolden2;
                    if (dragon7.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon7.Vida2 = 0;
                    }



                }


                //*-------------------------------------------------------------------------------------------------------------------------------------------------
                if (nivel4 == 1)
                {
                    
                    contadornivel5++;
                    if (contadornivel5 > 250)
                    {
                        oknivel5 = 1;
                    }
                    else
                    {
                        oknivel5 = 0;
                    }


                    lvl5.caida(gameTime);
                    stage_conteo5++;
                    if (stage_conteo5 > 250)
                    {
                        boss3.movimientos(gameTime);
                        dragon_stage5.movimientos(gameTime);
                        dragon_stage5.Fuego(gameTime, Content);
                        skull.movimientos(gameTime);
                        skull1.movimientos(gameTime);
                        skull.Disparo(gameTime, Content);
                        skull1.Disparo2(gameTime, Content);

                        
                        if (boss3.Vida3 == 0)
                        {
                            player.score1 = player.score1 + 100;
                            player2.score1 = player2.score1 + 100;
                            matados++;
                            boss3.Vida3 = -1;
                        }
                        if (boss3.Vida3 > 0)
                        {
                            bgolden16 = new BoundingBox(new Vector3(boss3.Pos.X, boss3.Pos.Y, 0), new Vector3(boss3.Pos.X + 30, boss3.Pos.Y + 20, 0));
                            if (bgolden.Intersects(bgolden16))
                            {
                                pega2++;
                                pega2++;
                                if (pega2 > 10 && player.vida1 != 0)
                                {
                                    player.vida1--;
                                    pega2 = 0;
                                }
                                if(boss3.Volando ==0){
                                if (player.Pos.X > boss3.Pos.X)
                                {
                                    
                                    if (player.atacando == true)
                                    {

                                        boss3.Vida3--;
                                        player.atacando = false;

                                    } player.atacando = false;
                                }
                                if (player.Pos.X < boss3.Pos.X)
                                {
                                    
                                    if (player.atacando == true)
                                    {

                                        boss3.Vida3--;
                                        player.atacando = false;

                                    } player.atacando = false;
                                }
                                if (player.moviendose == true && player.Pos.X < boss3.Pos.X)
                                {
                                    player.Colision1(gameTime);
                                    if (player.atacando == true)
                                    {
                                        boss3.Vida3--;
                                        player.atacando = false;

                                    } player.atacando = false;
                                }
                                if (player.moviendose == true && player.Pos.X > boss3.Pos.X)
                                {
                                    //player.Pos.X += 4;
                                    player.Colision2(gameTime);
                                    if (player.atacando == true)
                                    {

                                        boss3.Vida3--;
                                        player.atacando = false;

                                    } player.atacando = false;
                                }
                                player.moviendose = false;
                                player.atacando = false;
                            }
                                if (boss3.Volando == 1)
                                {
                                    if (player.Pos.X > boss3.Pos.X)
                                    {
                                        player.Colision1(gameTime);
                                       
                                    }
                                    if (player.Pos.X < boss3.Pos.X)
                                    {
                                        player.Colision2(gameTime);
                                    }
                                    if (player.moviendose == true && player.Pos.X < boss3.Pos.X)
                                    {
                                        player.Colision1(gameTime);
                                        player.Colision1(gameTime);
                                      
                                    }
                                    if (player.moviendose == true && player.Pos.X > boss3.Pos.X)
                                    {
                                        
                                        player.Colision2(gameTime);
                                        player.Colision2(gameTime);
                                      
                                    }
                                    player.moviendose = false;
                                    player.atacando = false;
                                }
                            }
                            if (bgolden2.Intersects(bgolden16))
                            {
                                pega3++;
                                pega3++;
                                if (pega3 > 10 && player2.vida1 != 0)
                                {
                                    player2.vida1--;
                                    pega3 = 0;
                                }
                                if (boss3.Volando == 0)
                                {
                                    if (player2.Pos.X > boss3.Pos.X)
                                    {

                                        if (player2.atacando == true)
                                        {

                                            boss3.Vida3--;
                                            player2.atacando = false;

                                        } player2.atacando = false;
                                    }
                                    if (player2.Pos.X < boss3.Pos.X)
                                    {

                                        if (player2.atacando == true)
                                        {

                                            boss3.Vida3--;
                                            player2.atacando = false;

                                        } player2.atacando = false;
                                    }
                                    if (player2.moviendose == true && player2.Pos.X < boss3.Pos.X)
                                    {
                                        player2.Colision1(gameTime);
                                        if (player2.atacando == true)
                                        {
                                            boss3.Vida3--;
                                            player2.atacando = false;

                                        } player2.atacando = false;
                                    }
                                    if (player2.moviendose == true && player2.Pos.X > boss3.Pos.X)
                                    {
                                        //player.Pos.X += 4;
                                        player2.Colision2(gameTime);
                                        if (player2.atacando == true)
                                        {

                                            boss3.Vida3--;
                                            player2.atacando = false;

                                        } player2.atacando = false;
                                    }
                                    player2.moviendose = false;
                                    player2.atacando = false;
                                }
                                if (boss3.Volando == 1)
                                {
                                    if (player2.Pos.X > boss3.Pos.X)
                                    {
                                        player2.Colision1(gameTime);

                                    }
                                    if (player2.Pos.X < boss3.Pos.X)
                                    {
                                        player2.Colision2(gameTime);
                                    }
                                    if (player2.moviendose == true && player2.Pos.X < boss3.Pos.X)
                                    {
                                        player2.Colision1(gameTime);
                                        player2.Colision1(gameTime);

                                    }
                                    if (player2.moviendose == true && player2.Pos.X > boss3.Pos.X)
                                    {

                                        player2.Colision2(gameTime);
                                        player2.Colision2(gameTime);

                                    }
                                    player2.moviendose = false;
                                    player2.atacando = false;
                                }
                            }
                        }





                    dragon_stage5.Bgolden = bgolden;
                    if (dragon_stage5.Vida1 == 1)
                        {
                            player.vida1 = player.vida1 - 10;
                            dragon_stage5.Vida1 = 0;
                        }

                    dragon_stage5.Bgolden2 = bgolden2;
                    if (dragon_stage5.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        dragon_stage5.Vida2 = 0;
                    }
                    skull1.Bgolden = bgolden;
                    if (skull1.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        skull1.Vida1 = 0;
                    }
                    skull1.Bgolden2 = bgolden2;
                    if (skull1.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        skull1.Vida2 = 0;
                    }
                    skull.Bgolden = bgolden;
                    if (skull.Vida1 == 1)
                    {
                        player.vida1 = player.vida1 - 10;
                        skull.Vida1 = 0;
                    }
                    skull.Bgolden2 = bgolden2;
                    if (skull.Vida2 == 1)
                    {
                        player2.vida1 = player2.vida1 - 10;
                        skull.Vida2 = 0;
                    }


                        Random h = new Random();


                        tiempo6++;
                        if (tiempo6 >= aparicionjinete)
                        {

                            if (hola6 < 4)
                            {
                                jinete = new Jinete(Content, new Vector2(800, h.Next(0, 160)));
                                jinetes.Add(jinete);
                            }

                            tiempo6 = 0;
                        }

                        Random k = new Random();
                        tiempo7++;
                        if (tiempo7 >= aparicionfuegoverde)
                        {

                            if (hola7 < 4)
                            {
                                fuegoarea = new fuego_area(Content, new Vector2(k.Next(0, 750), k.Next(0, 180)));
                                Fuego_area.Add(fuegoarea);
                            }

                            tiempo7 = 0;
                        }
                        foreach (fuego_area fa in Fuego_area)
                        {
                            fa.estado(gameTime);
                            bgolden15 = new BoundingBox(new Vector3(fa.Pos.X, fa.Pos.Y, 0), new Vector3(fa.Pos.X + 30, fa.Pos.Y + 20, 0));
                            if (bgolden.Intersects(bgolden15))
                            {
                                player.vida1 = player.vida1 - 10;
                                Fuego_area.Remove(fa);
                                break;
                               
                            }

                            if (bgolden2.Intersects(bgolden15))
                            {
                                player2.vida1 = player2.vida1 - 10;
                                Fuego_area.Remove(fa);
                                break;

                            }
                        }
                        foreach (Jinete jine in jinetes)
                        {
                            jine.Right(gameTime);
                            bgolden14 = new BoundingBox(new Vector3(jine.Pos.X, jine.Pos.Y, 0), new Vector3(jine.Pos.X + 30, jine.Pos.Y + 20, 0));
                            if (bgolden.Intersects(bgolden14))
                            {
                                contador++;
                                pega2++;
                                if (pega2 > 10 && player.vida1 != 0)
                                {
                                    player.vida1--;
                                    pega2 = 0;

                                }
                                if (player.Pos.X > jine.Pos.X)
                                {
                                    jine.Colision1(gameTime);
                                    player.Colision1(gameTime);
                                    player.atacando = false;


                                }
                                if (player.Pos.X < jine.Pos.X)
                                {
                                    jine.Colision2(gameTime);
                                    player.Colision2(gameTime);
                                    player.atacando = false;


                                }
                                if (player.moviendose == true && player.Pos.X < jine.Pos.X)
                                {
                                    player.Colision6(gameTime);
                                   player.atacando = false;

                                }
                                if (player.moviendose == true && player.Pos.X > jine.Pos.X)
                                {
                                    player.Colision7(gameTime);
                                     player.atacando = false;


                                }
                                player.moviendose = false;
                                player.atacando = false;
                            }
                            if (bgolden2.Intersects(bgolden14))
                            {
                               
                                pega3++;
                                if (pega3 > 10 && player2.vida1 != 0)
                                {
                                    player2.vida1--;
                                    pega3 = 0;

                                }
                                if (player2.Pos.X > jine.Pos.X)
                                {
                                    jine.Colision1(gameTime);
                                    player2.atacando = false;


                                }
                                if (player2.Pos.X < jine.Pos.X)
                                {
                                    jine.Colision2(gameTime);
                                    player2.atacando = false;


                                }
                                if (player2.moviendose == true && player2.Pos.X < jine.Pos.X)
                                {
                                    player2.Colision1(gameTime);
                                    player2.atacando = false;

                                }
                                if (player2.moviendose == true && player2.Pos.X > jine.Pos.X)
                                {
                                    player2.Colision2(gameTime);
                                    player2.atacando = false;


                                }
                                player2.moviendose = false;
                                player2.atacando = false;
                            }
                        }


                    }
                }

                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            KeyboardState keystate;
            keystate = Keyboard.GetState();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            switch (CurrentGameState)
            {
                case GameState.GameOver:

                    if (perdiste == 1)
                    {
                        spriteBatch.Draw(Content.Load<Texture2D>("Imagenes/gameover3"), new Rectangle(0, 0, screenWidth, screenHeight), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);
                        spriteBatch.Draw(score, new Rectangle((int)pos3.X + 600, 10, 25, 25), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.3f);
                        spriteBatch.Draw(score2, new Rectangle((int)pos3.X + 600, 50, 25, 25), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.3f);
                    }
                    if (juegoganado == 1)
                    {
                        spriteBatch.Draw(Content.Load<Texture2D>("Imagenes/juego_ganado2"), new Rectangle(0, 0, screenWidth, screenHeight), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);

                    }
                  
                   
                        spriteBatch.DrawString(georgia, "Score:" + (player.score1+player.vida1).ToString(), p1scorePos, Color.White);
                        spriteBatch.DrawString(georgia, "Score:" + (player2.score1 + player2.vida1).ToString(), p2scorePos, Color.White);

                    Boton3.Draw(spriteBatch);
                  //  Boton4.Draw(spriteBatch);
                    break;

                case GameState.MainMenu:

                    spriteBatch.Draw(Content.Load<Texture2D>("Imagenes/system_menu"), new Rectangle(0, 0, screenWidth, screenHeight), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);
                    Boton.Draw(spriteBatch);
                    Boton2.Draw(spriteBatch);
                    break;
                case GameState.Loading:
                    spriteBatch.Draw(load, new Rectangle((int)player.Pos2.X + 0, 0, 800, 600), Color.White);
                    break;

                case GameState.Play:

                    if (cargando == 1)
                    {
                        if(juegoganado == 0)
                        spriteBatch.Draw(load, new Rectangle(0, 0, 800, 600), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0);

                        if (juegoganado == 1)
                        {
                            spriteBatch.Draw(ganado, new Rectangle((int)player.Pos2.X + 0, 0, 800, 600), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);

                        }

                    }

                    if (cargando == 0)
                    {
                        spriteBatch.Draw(HP, new Rectangle((int)pos3.X + 0, 0, 40, 40), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.9f);
                        spriteBatch.Draw(HP2, new Rectangle((int)pos3.X + 0, 40, 40, 40), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.5f);
                        spriteBatch.Draw(score, new Rectangle((int)pos3.X + 600, 10, 25, 25), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.3f);
                        spriteBatch.Draw(score2, new Rectangle((int)pos3.X + 600, 50, 25, 25), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 0.3f);
                        spriteBatch.DrawString(georgia, "Score:" + player.score1.ToString(), p1scorePos, Color.Black);
                        spriteBatch.DrawString(georgia, "Score:" + player2.score1.ToString(), p2scorePos, Color.Black);
                        
                        spriteBatch.DrawString(georgia, "Nota:", p4scorePos, Color.Yellow);
                        if(nivel1 == 1)
                            spriteBatch.DrawString(georgia, "Mata 10 enemigos" , p5scorePos, Color.Yellow);
                        if (nivel2 == 1)
                            spriteBatch.DrawString(georgia, "Guardianes invencibles", p5scorePos, Color.Yellow);
                        if (nivel5 == 1)
                            spriteBatch.DrawString(georgia, "Azules score Verdes vida", p5scorePos, Color.Yellow);
                        if (nivel3 == 1)
                            spriteBatch.DrawString(georgia, "Jefe imparable", p5scorePos, Color.Yellow);
                        if (nivel4 == 1)
                            spriteBatch.DrawString(georgia, "Ya sabes ;)", p5scorePos, Color.Yellow);



                        if (player2.vida1 > 0)
                        {
                            player2.Draw(spriteBatch);
                            spriteBatch.DrawString(georgia, "HP:" + player2.vida1.ToString() + "%", p2vidaPos, Color.LawnGreen);
                        }

                        if (player.vida1 > 0)
                        {
                            player.Draw(spriteBatch);
                            spriteBatch.DrawString(georgia, "HP:" + player.vida1.ToString() + "%", p1vidaPos, Color.LawnGreen);
                        }
                        // spriteBatch.DrawString(georgia, vida2.ToString(), p2scorePos, Color.White);

                        if (player.vida1 <= 0)
                        {
                            spriteBatch.DrawString(georgia, "HAS MUERTO", pmuerte, Color.Red);
                           
                           

                        }
                        if (player2.vida1 <= 0)
                        {
                            spriteBatch.DrawString(georgia, "HAS MUERTO", p2muerte, Color.Red);
                           
                            
                        }

                        if (nivel5 == 1)
                        {
                            if (cambionivel == 25)
                            {
                                muerte2.Draw(spriteBatch);
                            }
                            if (cambionivel == 15)
                            {
                                muerte.Draw(spriteBatch);
                            }

                            spriteBatch.Draw(fondo3, new Rectangle((int)0, 0, 800, 600), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);
                            spriteBatch.DrawString(georgia, "Kills:" + matados.ToString(), p3scorePos, Color.Red);
                            lvl3.Draw(spriteBatch);

                            if (muerto6 == 1)
                            {
                                muerte6.Draw(spriteBatch);

                            }
                            if (muerto7 == 1)
                            {
                                muerte7.Draw(spriteBatch);

                            }
                            foreach (enemigo enemi in listaEnemigos)
                            {
                                enemi.Draw(spriteBatch);
                            }
                            foreach (enemigoA enemiA in listaEnemigosA)
                            {
                                enemiA.Draw(spriteBatch);
                            }
                        }

                        if (nivel1 == 1)
                        {

                            if (cambionivel == 21)
                            {
                                muerte2.Draw(spriteBatch);
                            }
                            if (cambionivel == 11)
                            {
                                muerte.Draw(spriteBatch);
                            }

                            spriteBatch.Draw(fondo, new Rectangle((int)0, 0, 2000, 600), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);
                            spriteBatch.DrawString(georgia, "Kills:" + matados.ToString(), p3scorePos, Color.Red);
                            lvl.Draw(spriteBatch);

                            if (muerto3 == 1)
                            {
                                muerte3.Draw(spriteBatch);
                                
                            }
                            if (muerto4 == 1)
                            {
                                muerte4.Draw(spriteBatch);

                            }
                            if (muerto5 == 1)
                            {
                                muerte5.Draw(spriteBatch);

                            }
                          
                            foreach (enemigoB enemiB in listaEnemigosB)
                            {
                                enemiB.Draw(spriteBatch);
                            }
                            foreach (enemigoC enemiC in listaEnemigosC)
                            {                               
                                enemiC.Draw(spriteBatch);
                                
                                
                            }
                            foreach (enemigoD enemiD in listaEnemigosD)
                            {
                                enemiD.Draw(spriteBatch);
                            }
                            foreach (Fuego Boom in listaFuego)
                            {
                                Boom.Draw(spriteBatch);
                            }
                        }

                        if (nivel2 == 1)
                        {

                            if (cambionivel == 22)
                            {
                                muerte2.Draw(spriteBatch);
                            }
                            if (cambionivel == 12)
                            {
                                muerte.Draw(spriteBatch);
                            }
                                
                            spriteBatch.Draw(fondo2, new Rectangle((int)player.Pos2.X + 0, 0, 800, 600), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);
                            spriteBatch.DrawString(georgia, "HP BOSS:" + mago.Vida2.ToString(), p3scorePos, Color.Red);
                            

                            lvl2.Draw(spriteBatch);

                            vortice.Draw(spriteBatch);
                            vortice2.Draw(spriteBatch);

                            if (mago.Vida2 > 0)
                            {
                                mago.Draw(spriteBatch);
                                Domo.Draw(spriteBatch);
                            }

                            guardian.Draw(spriteBatch);

                            guardian2.Draw(spriteBatch);
                        }
                        if (nivel3 == 1)
                        {
                            if (cambionivel == 23)
                            {
                                muerte2.Draw(spriteBatch);
                            }
                            if (cambionivel == 13)
                            {
                                muerte.Draw(spriteBatch);
                            }
                            spriteBatch.Draw(fondo4, new Rectangle((int)player.Pos2.X + 0, 0, 800, 600), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);
                            
                            spriteBatch.DrawString(georgia, "HP BOSS:" + Boss.Vida3.ToString(), p3scorePos, Color.Red);
                            lvl4.Draw(spriteBatch);
                            dragon1.Draw(spriteBatch);
                            dragon2.Draw(spriteBatch);
                            dragon3.Draw(spriteBatch);
                            dragon4.Draw(spriteBatch);
                            dragon5.Draw(spriteBatch);
                            dragon6.Draw(spriteBatch);
                            dragon7.Draw(spriteBatch);

                            if (Boss.Vida3 > 0)
                                Boss.Draw(spriteBatch);
                        }
                        if (nivel4 == 1)
                        {
                            if (cambionivel == 24)
                            {
                                muerte2.Draw(spriteBatch);
                            }
                            if (cambionivel == 14)
                            {
                                muerte.Draw(spriteBatch);
                            }

                            spriteBatch.Draw(fondo5, new Rectangle((int)player.Pos2.X + 0, 0, 800, 600), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), SpriteEffects.None, 1);
                            spriteBatch.DrawString(georgia, "HP BOSS:" + boss3.Vida3.ToString(), p3scorePos, Color.Red);
                            lvl5.Draw(spriteBatch);
                            player.Draw(spriteBatch);
                            player2.Draw(spriteBatch);
                            boss3.Draw(spriteBatch);
                            dragon_stage5.Draw(spriteBatch);
                            skull.Draw(spriteBatch);
                            skull1.Draw(spriteBatch);
                            foreach (Jinete jine in jinetes)
                            {
                                jine.Draw(spriteBatch);
                            }
                            foreach (fuego_area fa in Fuego_area)
                            {
                                fa.Draw(spriteBatch);

                            }
                        }
                        
                    }
                    break;
                case GameState.Exit:
                    break;

            }
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
