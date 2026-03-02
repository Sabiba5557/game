using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gaming
{
    public partial class Form1 : Form
    {
        bool goUp, goDown, goLeft, goRight, isGameOver;
        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostx, pinkGhosty;

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void yellowghost_Click(object sender, EventArgs e)
        {

        }

        private void redghost_Click(object sender, EventArgs e)
        {

        }

        private void pacman_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
if(e.KeyCode==Keys.Up)//when the up key is pressed,pacman will move up
            {
                goUp = true;

            }
if(e.KeyCode==Keys.Down)//when the down key is pressed,pacman will move down
            {
                goDown = true;
            }
if(e.KeyCode==Keys.Left)
            {
                goLeft = true;
            }
if(e.KeyCode==Keys.Right)
            {
                goRight = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)//when the key is released ,pacman will stop moving in that direction
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp =false;

            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(e.KeyCode==Keys.Enter && isGameOver==true)//when the game is over and the enter key is pressed,the game will reset
            {
                resetGame();
            }
        }

        private void mainGameTimer(object sender, EventArgs e)//this is the main game loop
        {
            txtScore.Text = "Score: " + score;//update the score text
            if (goLeft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;//change the image of pacman to left when moving left

            }
            if (goRight == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;

            }
            if (goDown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;

            }
            if (goUp == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }
            if (pacman.Left < -10)//when pacman goes out of the left boundary,it will appear on the right boundary
            {
                pacman.Left = 520;

            }
            if (pacman.Left > 520)
            {
                pacman.Left = -10;
            }
            if (pacman.Top < -10)
            {
                pacman.Top = 550;

            }
            if (pacman.Top > 550)
            {
                pacman.Top = 0;
            }
            foreach (Control x in this.Controls)
            {
                if ((string)x.Tag == "coin" && x.Visible == true)//when pacman intersects with a coin,the score will increase by 1 and the coin will disappear
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        x.Visible = false;
                    }
                }
                if ((string)x.Tag == "wall")//when pacman intersects with a wall,the game will end and show a lose message
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameOver("You lose!");
                    }
                    if(pinkghost.Bounds.IntersectsWith(x.Bounds))
                    {
                        pinkGhostx = -pinkGhostx;
                    }

                }
                if ((string)x.Tag == "ghost")
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds)) 
                    {
                        gameOver("You lose!");
                    }
                }
            }
  

            //ghost movement
            redghost.Left += redGhostSpeed;
            if(redghost.Bounds.IntersectsWith(pictureBox3.Bounds) || redghost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }
            yellowghost.Left += yellowGhostSpeed;
            if (yellowghost.Bounds.IntersectsWith(pictureBox1.Bounds) || yellowghost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }
            pinkghost.Left -= pinkGhostx;
            pinkghost.Top -= pinkGhosty;
            if(pinkghost.Top<0 || pinkghost.Top>550)
            {
                pinkGhosty = -pinkGhosty;
            }
            if (pinkghost.Left< 0 || pinkghost.Left > 550)           
                {
                pinkGhostx = -pinkGhostx;
            }


            if (score==73)
            {
                gameOver("You win!");
            }
        }
        private void resetGame()
        {
            txtScore.Text = "Score: 0";
            score = 0;
            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostx = 5;
            pinkGhosty = 5;
            playerSpeed = 8;
            isGameOver = false;
            pacman.Left = 31;
            pacman.Top = 46;
            redghost.Left =201;
            redghost.Top = 109;
            yellowghost.Left = 424;
            yellowghost.Top = 425;
            pinkghost.Left = 525;
            pinkghost.Top = 235;
            foreach(Control x in this.Controls)//make all coins visible again when the game is reset
            {
                if(x is PictureBox)
                {
                    x.Visible = true;

                }
            }
            gameTimer.Start();
               

        }
        private void gameOver(string message)//whether you win or lose,this will end the game and show a message
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text ="Score: "+score+ Environment.NewLine + message;
        }
    }
}
