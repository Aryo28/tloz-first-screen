using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGTheGame
{
    public partial class Game : Form
    {

       

        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;
        int speed = 10;
        int contador = 0;
        int contidle = 0;
        int contabajo = 0;
        int contarriba = 0;
        int score = 0;
        int enemyVel1 = 8;
        int enemyVel2 = 5;
        int enemyVel3 = 15;
        int enemyVel4 = 7;
        int vida = 3;
        int vida2 = 0;
        string orientacion = "DERECHA";
        public static string mensaje= "";

        EndScreen EndScreen = new EndScreen();

        Image[] link = new Image[6];
        Image[] link00 = new Image[1];
        Image[] idle1 = new Image[3];
        Image[] abajo = new Image[7];
        Image[] arriba = new Image[7];
        public Game()
        {
            InitializeComponent();

            idle1[0] = OGTheGame.Properties.Resources.Capa_2;
            idle1[1] = OGTheGame.Properties.Resources.Capa_3;
            idle1[2] = OGTheGame.Properties.Resources.Capa_4;

            abajo[0] = OGTheGame.Properties.Resources.down;
            abajo[1] = OGTheGame.Properties.Resources.down0;
            abajo[2] = OGTheGame.Properties.Resources.down1;
            abajo[3] = OGTheGame.Properties.Resources.down2;
            abajo[4] = OGTheGame.Properties.Resources.down3;
            abajo[5] = OGTheGame.Properties.Resources.down4;
            abajo[6] = OGTheGame.Properties.Resources.down5;

            arriba[0] = OGTheGame.Properties.Resources.up0;
            arriba[1] = OGTheGame.Properties.Resources.up1;
            arriba[2] = OGTheGame.Properties.Resources.up2;
            arriba[3] = OGTheGame.Properties.Resources.up3;
            arriba[4] = OGTheGame.Properties.Resources.up4;
            arriba[5] = OGTheGame.Properties.Resources.up5;
            arriba[6] = OGTheGame.Properties.Resources.up6;


            link[0] = OGTheGame.Properties.Resources.link0;
            link[1] = OGTheGame.Properties.Resources.link1;
            link[2] = OGTheGame.Properties.Resources.link2;
            link[3] = OGTheGame.Properties.Resources.link3;
            link[4] = OGTheGame.Properties.Resources.link4;
            link[5] = OGTheGame.Properties.Resources.link5;


            link00[0] = OGTheGame.Properties.Resources.link00;

           

        }
        private void movimiento()
        {
            if (contador == 5)
            {
                contador = -1;
            }
            contador++;

        }


        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                ELidle.Stop();
                timerdown.Stop();
                timerup.Stop();
                left = true;


            }

            if (e.KeyCode == Keys.Right)
            {
                ELidle.Stop();
                timerdown.Stop();
                timerup.Stop();
                right = true;

            }

            if (e.KeyCode == Keys.Up)
            {
                ELidle.Stop();
                timerdown.Stop();
                timerup.Start();
                up = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                timerdown.Start();
                ELidle.Stop();
                timerup.Stop();
                down = true;

            }
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {

                left = false;
                pictureBox1.Image = OGTheGame.Properties.Resources.link00;

            }

            if (e.KeyCode == Keys.Right)
            {
                pictureBox1.Image = OGTheGame.Properties.Resources.link0;
                ELidle.Start();
                right = false;

            }

            if (e.KeyCode == Keys.Up)
            {
                timerup.Stop();
                pictureBox1.Image = OGTheGame.Properties.Resources.up;
                up = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                timerdown.Stop();
                pictureBox1.Image = OGTheGame.Properties.Resources.down;
                down = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)//timer principal
        {

            if (left == true && pictureBox1.Left > 0)//mover izquierda
            {

                pictureBox1.Left -= speed;
                pictureBox1.Image = link[contador];
                movimiento();

                if (orientacion == "DERECHA")
                {
                    linkgiro();
                    orientacion = "IZQUIERDA";
                }
            }
            if (right == true)//mover derecha
            {
                pictureBox1.Left += speed;
                pictureBox1.Image = link[contador];
                movimiento();

                if (orientacion == "IZQUIERDA")
                {
                    linkgiro();
                    orientacion = "DERECHA";
                }
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))//colision 
            {
                pictureBox1.Left -= speed;
            }
            if (up == true)
            {
                pictureBox1.Top -= speed;
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds))//colision
            {
                pictureBox1.Left += speed;
            }

            if (down == true)
            {
                pictureBox1.Top += speed;
            }

            foreach (Control x in this.Controls)//colision paredes izq
            {
                if (x is PictureBox && x.Tag == "wall_izq")
                {
                    if (pictureBox1.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox1.Left -= speed;
                    }
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "wall_der")//colision paredes der
                {
                    if (pictureBox1.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox1.Left += speed;
                    }
                }
            }


            foreach (Control x in this.Controls)//colision paredes abajo
            {
                if (x is PictureBox && x.Tag == "wall_down")
                {
                    if (pictureBox1.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox1.Top += speed;
                    }
                }
            }


            foreach (Control x in this.Controls)//colision paredes arriba
            {
                if (x is PictureBox && x.Tag == "wall_up")
                {
                    if (pictureBox1.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox1.Top -= speed;
                    }
                }
            }


            foreach (Control x in this.Controls)//para juntar rupias +1
            {
                if (x is PictureBox && x.Tag == "rupia")
                {
                    if (pictureBox1.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        score++;
                        x.Visible = false;
                    }
                }
            }

            foreach (Control x in this.Controls)//rupia azul +5
            {
                if (x is PictureBox && x.Tag == "b_rupia")
                {
                    if (pictureBox1.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        score += 5;
                        x.Visible = false;
                    }
                }
            }



         

            if (pictureBox1.Top > 340) //transicion en la escalera
            {
                pictureBox1.Top -= 340;
            }

            if (pictureBox1.Top < 0)//transicion escalera
            {
                pictureBox1.Top += 320;
            }

            //asignar velocidad y patron de movimiento a enemigos
            //Estan desactivados porque se traba con todos los desplazamientos

            enemy1.Top += enemyVel1;
             enemy2.Left -= enemyVel2;
             enemy3.Top += enemyVel3;
             enemy4.Left += enemyVel4;
             
             if (enemy1.Top < 137 || enemy1.Top > 251)
             {
                 enemyVel1 = -enemyVel1;
             }

             if (enemy2.Left <163  || enemy2.Left > 296)
             {
                 enemyVel2 = -enemyVel2;
             }

             if(enemy3.Top <67 || enemy3.Top >248)//bien

             {
                 enemyVel3 = -enemyVel3;
             }
             
            if(enemy4.Left <790 || enemy4.Left >928)//bien

             {
                 enemyVel4 = -enemyVel4;
             }

           

            label2.Text = Convert.ToString(score);
            mensaje = label2.Text;


            
            

            //cuando recibes daño los corazones se van vaciando

            if ( vida == 2)
            {
                heart3.Image = OGTheGame.Properties.Resources.nolife;
            }

            if( vida == 1)
            {
                heart2.Image = OGTheGame.Properties.Resources.nolife;
            }

            if (vida == 0)
            {
                heart1.Image = OGTheGame.Properties.Resources.nolife;
                Gameover();

               
            }
         
            if (pictureBox1.Bounds.IntersectsWith(exit.Bounds))//llegar a la meta
            {
                Gameover();
                               
            }

        }

        private void linkgiro()//funcion girar imagen
        {
            link[0].RotateFlip(RotateFlipType.Rotate180FlipY);
            link[1].RotateFlip(RotateFlipType.Rotate180FlipY);
            link[2].RotateFlip(RotateFlipType.Rotate180FlipY);
            link[3].RotateFlip(RotateFlipType.Rotate180FlipY);
            link[4].RotateFlip(RotateFlipType.Rotate180FlipY);
            link[5].RotateFlip(RotateFlipType.Rotate180FlipY);
        }


        private void ELidle_Tick(object sender, EventArgs e)//animacion idle
        {
            pictureBox1.Image = idle1[contidle];
            if (contidle == 2)
            {
                contidle = -1;

            }
            contidle++;
        }

        private void Form1_Load(object sender, EventArgs e)//load
        {

            
            ELidle.Start();
            timer1.Start();
            timerdown.Stop();
            timerup.Stop();
            Perf_Frames.Start();
            pictureBox1.BringToFront();

        }

        private void timerdown_Tick(object sender, EventArgs e)//animacion hacia abajo
        {
            pictureBox1.Image = abajo[contabajo];
            if (contabajo == 5)
            {
                contabajo = -1;
            }
            contabajo++;
        }

        private void timerup_Tick(object sender, EventArgs e)//animacion hacia arriba
        {
            pictureBox1.Image = arriba[contarriba];
            if (contarriba == 6)
            {
                contarriba = -1;
            }
            contarriba++;
        }

        private void Gameover()//funcion para acabar juego
        {
            ELidle.Stop();
            timerdown.Stop();
            timerup.Stop();
            timer1.Stop();
            EndScreen.Show();

            this.Hide();
            
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Perf_Frames_Tick(object sender, EventArgs e)//timer para ser invencible despues te perder 1 punto de vida
        {
            foreach (Control x in this.Controls)// daño de enemigos
            {
                if (x is PictureBox && x.Tag == "enemy")
                {
                    if (pictureBox1.Bounds.IntersectsWith(x.Bounds))
                    {
                        vida--;
                        vida2++;

                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void x(object sender, EventArgs e)
        {

        }
    }



}
