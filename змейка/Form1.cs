using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace змейка
{
    public partial class Form1 : Form
    {
        private PictureBox[] snake = new PictureBox[400];
        private int rI, rJ;
        private PictureBox fruit;
        private int dirX, dirY;
        private int _width = 900;
        private int _height = 800;
        private int _sizeofSides = 40;
        private int score = 0;
        private Label labelScore;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Snake";
            _generateMap();
            timer.Tick += new EventHandler(_update);
            timer.Interval = 200;
            timer.Start();
            this.KeyDown += new KeyEventHandler(OKP);
            this.Width = _width;
            this.Height = _height;
            dirX = 1;
            dirY = 0;
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(_sizeofSides, _sizeofSides);
            _generateFruit();
            snake[0] = new PictureBox();
            snake[0].Location = new Point(201, 201);
            snake[0].Size = new Size(_sizeofSides-1, _sizeofSides-1);
            snake[0].BackColor = Color.Red;
            labelScore = new Label();
            this.Controls.Add(snake[0]);
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(810,10);
            this.Controls.Add(labelScore);


        }
        private void _eatitself()
        {
            try
            {
            for(int _i =1; _i < score;_i++)
            {
                if (snake[0].Location == snake[_i].Location)
                {
                    for(int _j = _i; _j <= score;_j++)
                        this.Controls.Remove(snake[_j]);
                    score = score + (score - _i + 1);
                }
            }
            }
            catch (Exception)
            {
                for (int _i = 1; _i < score; _i++)
                {
                    
                }
            }
           
        }
        private void _checkBorders()
        {
            if (snake[0].Location.X <0)
            {
                for(int _i = 1;_i<= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                dirX = 1;
                labelScore.Text = "Score:" + score;
            }
            if (snake[0].Location.X > _height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                dirX = -1;
                labelScore.Text = "Score:" + score;
            }
            if (snake[0].Location.Y < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                dirY = 1;
                labelScore.Text = "Score:" + score;
            }
            if (snake[0].Location.Y > _height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                score = 0;
                dirY = -1;
                labelScore.Text = "Score:" + score;
            }

        }
        private void _generateFruit()
        {
            Random r = new Random();
            rI = r.Next(0, _height - _sizeofSides);
            int tempI = rI % _sizeofSides;
            rI -= tempI;
            rJ = r.Next(0, _height - _sizeofSides);
            int tempJ = rJ % _sizeofSides;
            rJ -= tempJ;
            rI++;
            rJ++;
            fruit.Location = new Point(rI,rJ);
            this.Controls.Add(fruit);
        }
        private void _moveSnake()
        {
            for (int i = score; i >= 1; i--) 
            {
                snake[i].Location = snake[i - 1].Location;
            }
           snake[0].Location =  new Point(snake[0].Location.X + dirX * _sizeofSides, snake[0].Location.Y + dirY * _sizeofSides);
            _eatitself();
        }
        private void _update(object myobject,EventArgs eventArgs)
        {
            _checkBorders();
            _eatFruit();
            _moveSnake();
            //cube.Location = new Point(cube.Location.X +dirX*_sizeofSides, cube.Location.Y + dirY * _sizeofSides);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void _eatFruit()
        {
            if (snake[0].Location.X == rI && snake[0].Location.Y == rJ)
            {
                labelScore.Text = "Score: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + 40 * dirX, snake[score - 1].Location.Y - 40 * dirY);
                snake[score].Size = new Size(_sizeofSides-1, _sizeofSides-1);
                snake[score].BackColor = Color.Red;
                this.Controls.Add(snake[score]);
                _generateFruit();
            }
        }
        private void OKP(object sender, KeyEventArgs e)
        {
           switch(e.KeyCode.ToString())
            {
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;

                    break;
            }
        }
        private void _generateMap()
        {
            for(int i =0; i<_width/_sizeofSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, _sizeofSides*i);
                pic.Size = new Size(_width - 100,1);
                this.Controls.Add(pic);

            }
            for (int i = 0; i <= _height / _sizeofSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point( _sizeofSides * i,0);
                pic.Size = new Size(1,_width);
                this.Controls.Add(pic);

            }
        }
    }
}
