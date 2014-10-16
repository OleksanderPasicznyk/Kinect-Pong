using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridSandbox
{
    public partial class Form1 : Form
    {
        public PictureBox picBoxPlayer;
        public PictureBox picBoxBall;
        int gameScore = 0;
        public const int SCREEN_WIDTH = 1200;
        public const int SCREEN_HEIGHT = 800;

        Size playerSize = new Size(10, 200);
        Size sizeBall = new Size(10, 10);
        int ballSpeedX = 3;
        int ballSpeedY = 3;
        int scoreTimerInterval = 1000;
        //END Variables
        public Form1()
        {
            InitializeComponent();

            this.Text = "Kinect Pong";
            picBoxPlayer = new PictureBox();
            picBoxBall = new PictureBox();
           
            this.Width = SCREEN_WIDTH;
            this.Height = SCREEN_HEIGHT;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;

            Timer gameScorer = new Timer();
            gameScorer.Interval = scoreTimerInterval;
            gameScorer.Enabled = true;
            gameScorer.Tick += addScore;


            picBoxPlayer.Size = playerSize;
            picBoxPlayer.Location = new Point(0, ClientSize.Height / 4);
            picBoxPlayer.BackColor = Color.SteelBlue;
            this.Controls.Add(picBoxPlayer);

            picBoxBall.Size = sizeBall;
            picBoxBall.Location = new Point(ClientSize.Width / 2, ClientSize.Height / 2); //Ball starting position in middle of screen
            picBoxBall.BackColor = Color.WhiteSmoke;
            picBoxBall.Enabled = true;
            this.Controls.Add(picBoxBall);
            }

            private void addScore(Object source, EventArgs e)
            {
                gameScore += 1;
            }
　
            public Point moveBall(Point p)
            {
                if (intersectsWithPaddle(this.picBoxBall))
                {
                ballSpeedX *= -1;
                }
                if (p.X + ballSpeedX < 0)
                {
                    //endgame
                    Console.Write("Game Ended. Your Score:  " + gameScore);
                    this.Close();
                }
                if (p.X + ballSpeedX > ClientSize.Width)
                {
                ballSpeedX *= -1;
                }
                if (p.Y + ballSpeedY > ClientSize.Height || p.Y + ballSpeedY < 0)
                {
                ballSpeedY *= -1;
                }
                return new Point(p.X += ballSpeedX, p.Y += ballSpeedY);
            }
　
            private bool intersectsWithPaddle(PictureBox ball)
            {//fixed
                if (ball.Location.Y < picBoxPlayer.Location.Y + picBoxPlayer.Size.Height && ball.Location.Y + ball.Size.Height > picBoxPlayer.Location.Y)
                {
                    if (ball.Location.X < picBoxPlayer.Size.Width)
                        {
                        return true;
                        }
                }
                else{
                    return false;
                }
                return false;
            }
            private void Form1_Load(object sender, EventArgs e)
            {
　
            }
    }
}
