using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        public int speed_left = 4; //velocidade do projetil
        public int speed_top = 4;
        public int point = 0;  //Pontos 




        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide(); // Hide the cursor

            this.FormBorderStyle = FormBorderStyle.None;// remover qualquer borda
            this.TopMost = true;                     //Bring
            this.Bounds = Screen.PrimaryScreen.Bounds; //Make in fulscrren

            racket.Top = playgeound.Bottom - (playgeound.Bottom / 10); // indica posição da quete





        }
        private void timer1_Tick(object sender, EventArgs e)
        { 
            racket.Left = Cursor.Position.X - (racket.Width / 2); //Marca o centro da racket a posição do cursor

            ball.Left += speed_left; //Mover projetil
            ball.Top += speed_top;

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right) //Colisção da racket

            {
                speed_top += 2; 
                speed_left += 2;
                speed_top = -speed_top; //muda a direção
                point += 1;
                speed_left = (speed_left > 0) ? speed_left + 2 : speed_left - 2;

            }
            
            if (ball.Left <= playgeound.Left)
            {
                speed_left = -speed_left;

            }
            if (ball.Right >= playgeound.Right)
            {
                speed_left = -speed_left;
            }

            if (ball.Top <= playgeound.Top)
            {
                speed_top = -speed_top;
            }

            if (ball.Bottom >= playgeound.Bottom)
            {
                timer1.Enabled = false;   //Bola fora -> para game

            }
        }

     

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                { this.Close(); } //Press Escape to Quit
            }
        }

      
    }
}