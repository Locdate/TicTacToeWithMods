using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace TicTacToe
{
    public partial class Game : Form
    {
        private int drawNumb = 0;
        private Random rnd = new Random();
        private List<Button> blueCardArr = new List<Button>();
        private List<Button> redCardArr = new List<Button>();
        public MainMenu menu;
        public Button[,] gameFieldMain = new Button[3, 3];
        public Image circle = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\Circle.png");
        public Image cross = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\Cross.png");
        public Image crossAndCircle = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\CircleAndCross.png");
        public List<Button> winList = new List<Button>();
        List<int> yCardPos = new List<int>();
        public bool queue;
        public bool daCardUsed = false;
        public bool sCardUsed = false;
        //private Button drunkennessCardPrefab = new Button();
        public Game()
        {
            int rand = rnd.Next(0,10);
            InitializeComponent();
            gameFieldMain[0, 0] = button1_1;
            gameFieldMain[0, 1] = button1_2;
            gameFieldMain[0, 2] = button1_3;
            gameFieldMain[1, 0] = button2_1;
            gameFieldMain[1, 1] = button2_2;
            gameFieldMain[1, 2] = button2_3;
            gameFieldMain[2, 0] = button3_1;
            gameFieldMain[2, 1] = button3_2;
            gameFieldMain[2, 2] = button3_3;
            QueueAI();
            AddButtonBehavior();
            tryAgainButton.Visible = false;
            backButton.Location = new Point(342, 377);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            yCardPos.Add(40);
            yCardPos.Add(155);
            yCardPos.Add(270);
            CreateStartCards();
        }

        public void CreateStartCards()
        {
            redCardArr.Clear();
            blueCardArr.Clear();

            for (int i = 0; i < 2; i++)
            {
                Button swordCardPrefab = new Button();
                Button doubleAgentCardPrefab = new Button();
                Button nukeCardPrefab = new Button();

                swordCardPrefab.Text = "";
                swordCardPrefab.Size = new Size(72, 92);
                swordCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\SlainCard.png");
                swordCardPrefab.Click += new System.EventHandler(SwordCardBehavior);

                doubleAgentCardPrefab.Text = "";
                doubleAgentCardPrefab.Size = new Size(72, 92);
                doubleAgentCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\DoubleAgentCard.png");
                doubleAgentCardPrefab.Click += new System.EventHandler(DoubleAgentCardBehavior);

                nukeCardPrefab.Text = "";
                nukeCardPrefab.Size = new Size(72, 92);
                nukeCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\NukeCard.png");
                nukeCardPrefab.Click += new System.EventHandler(NukeCardBehavior);

                int rand = rnd.Next(0, 12);

                if (rand >= 0 && rand <= 4)
                {
                    swordCardPrefab.Location = new Point(76, yCardPos[i]);
                    blueCardArr.Add(swordCardPrefab);
                    splitter1.Controls.Add(swordCardPrefab);
                }
                else if (rand > 4 && rand <= 8)
                {
                    doubleAgentCardPrefab.Location = new Point(76, yCardPos[i]);
                    blueCardArr.Add(doubleAgentCardPrefab);
                    splitter1.Controls.Add(doubleAgentCardPrefab);
                }
                else if (rand > 8 && rand <= 12)
                {
                    nukeCardPrefab.Location = new Point(76, yCardPos[i]);
                    blueCardArr.Add(nukeCardPrefab);
                    splitter1.Controls.Add(nukeCardPrefab);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                Button swordCardPrefab = new Button();
                Button doubleAgentCardPrefab = new Button();
                Button nukeCardPrefab = new Button();

                swordCardPrefab.Text = "";
                swordCardPrefab.Size = new Size(72, 92);
                swordCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\SlainCard.png");
                swordCardPrefab.Click += new System.EventHandler(SwordCardBehavior);

                doubleAgentCardPrefab.Text = "";
                doubleAgentCardPrefab.Size = new Size(72, 92);
                doubleAgentCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\DoubleAgentCard.png");
                doubleAgentCardPrefab.Click += new System.EventHandler(DoubleAgentCardBehavior);

                nukeCardPrefab.Text = "";
                nukeCardPrefab.Size = new Size(72, 92);
                nukeCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\NukeCard.png");
                nukeCardPrefab.Click += new System.EventHandler(NukeCardBehavior);

                int rand = rnd.Next(0, 12);

                if (rand >= 0 && rand <= 4)
                {
                    swordCardPrefab.Location = new Point(76, yCardPos[i]);
                    redCardArr.Add(swordCardPrefab);
                    splitter2.Controls.Add(swordCardPrefab);
                }
                else if (rand > 4 && rand <= 8)
                {
                    doubleAgentCardPrefab.Location = new Point(76, yCardPos[i]);
                    redCardArr.Add(doubleAgentCardPrefab);
                    splitter2.Controls.Add(doubleAgentCardPrefab);
                }
                else if (rand > 8 && rand <= 12)
                {
                    nukeCardPrefab.Location = new Point(76, yCardPos[i]);
                    redCardArr.Add(nukeCardPrefab);
                    splitter2.Controls.Add(nukeCardPrefab);
                }
            }
        }

        public void CreateRandomCards()
        {
            Button swordCardPrefab = new Button();
            Button doubleAgentCardPrefab = new Button();
            Button nukeCardPrefab = new Button();

            swordCardPrefab.Text = "";
            swordCardPrefab.Size = new Size(72, 92);
            swordCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\SlainCard.png");
            swordCardPrefab.Click += new System.EventHandler(SwordCardBehavior);

            doubleAgentCardPrefab.Text = "";
            doubleAgentCardPrefab.Size = new Size(72, 92);
            doubleAgentCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\DoubleAgentCard.png");
            doubleAgentCardPrefab.Click += new System.EventHandler(DoubleAgentCardBehavior);

            nukeCardPrefab.Text = "";
            nukeCardPrefab.Size = new Size(72, 92);
            nukeCardPrefab.Image = Image.FromFile("D:\\Programms\\TicTacToe\\TicTacToe\\NukeCard.png");
            nukeCardPrefab.Click += new System.EventHandler(NukeCardBehavior);

            if (queue)
            {
                int rand = rnd.Next(0, 12);
                if (rand >= 0 && rand <= 4)
                {
                    swordCardPrefab.Location = new Point(76, redCardArr.Last().Location.Y + 115);
                    redCardArr.Add(swordCardPrefab);
                    splitter2.Controls.Add(swordCardPrefab);
                }
                else if (rand > 4 && rand <= 8)
                {
                    doubleAgentCardPrefab.Location = new Point(76, redCardArr.Last().Location.Y + 115);
                    redCardArr.Add(doubleAgentCardPrefab);
                    splitter2.Controls.Add(doubleAgentCardPrefab);
                }
                else if (rand > 8 && rand <= 12)
                {
                    nukeCardPrefab.Location = new Point(76, redCardArr.Last().Location.Y + 115);
                    redCardArr.Add(nukeCardPrefab);
                    splitter2.Controls.Add(nukeCardPrefab);
                }
            }
            else if (!queue)
            {
                int rand = rnd.Next(0, 12);

                if (rand >= 0 && rand <= 4)
                {
                    swordCardPrefab.Location = new Point(76, blueCardArr.Last().Location.Y + 115);
                    blueCardArr.Add(swordCardPrefab);
                    splitter1.Controls.Add(swordCardPrefab);
                }
                else if (rand > 4 && rand <= 8)
                {
                    doubleAgentCardPrefab.Location = new Point(76, blueCardArr.Last().Location.Y + 115);
                    blueCardArr.Add(doubleAgentCardPrefab);
                    splitter1.Controls.Add(doubleAgentCardPrefab);
                }
                else if (rand > 8 && rand <= 12)
                {
                    nukeCardPrefab.Location = new Point(76, blueCardArr.Last().Location.Y + 115);
                    blueCardArr.Add(nukeCardPrefab);
                    splitter1.Controls.Add(nukeCardPrefab);
                }
            }
        }

        public void AddButtonBehavior()
        {
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++) 
                {
                    gameFieldMain[i, j].Click += new System.EventHandler(ChangeImage);
                }
            }
        }

        public void SwordCardBehavior(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            sCardUsed = true;
            if (!queue)
            {
                infoBar.Text = "<-BLUE USE DA CARD";
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    if (blueCardArr[i] == temp)
                    {
                        blueCardArr.RemoveAt(i);
                    }
                }
                splitter1.Controls.Remove(temp);
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    blueCardArr[i].Location = new Point(76, yCardPos[i]);
                }
            }
            else if (queue)
            {
                infoBar.Text = "RED USE DA CARD->";
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    if (redCardArr[i] == temp)
                    {
                        redCardArr.RemoveAt(i);
                    }
                }
                splitter2.Controls.Remove(temp);
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    redCardArr[i].Location = new Point(76, yCardPos[i]);
                }
            }
        }

        public void DoubleAgentCardBehavior(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            daCardUsed = true;
            if (!queue)
            {
                infoBar.Text = "<-BLUE USE DA CARD";
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    if (blueCardArr[i] == temp)
                    {
                        blueCardArr.RemoveAt(i);
                    }
                }
                splitter1.Controls.Remove(temp);
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    blueCardArr[i].Location = new Point(76, yCardPos[i]);
                }
                temp.Image = circle;
            }
            else if (queue)
            {
                infoBar.Text = "RED USE DA CARD->";
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    if (redCardArr[i] == temp)
                    {
                        redCardArr.RemoveAt(i);
                    }
                }
                splitter2.Controls.Remove(temp);
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    redCardArr[i].Location = new Point(76, yCardPos[i]);
                }
                temp.Image = cross;
            }
        }

        public void NukeCardBehavior(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameFieldMain[i, j].Image = null;
                }
            }
            if (!queue)
            {
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    if (blueCardArr[i] == temp)
                    {
                        blueCardArr.RemoveAt(i);
                    }
                }
                splitter1.Controls.Remove(temp);
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    blueCardArr[i].Location = new Point(76, yCardPos[i]);
                }
            }
            else if (queue)
            {
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    if (redCardArr[i] == temp)
                    {
                        redCardArr.RemoveAt(i);
                    }
                }
                splitter2.Controls.Remove(temp);
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    redCardArr[i].Location = new Point(76, yCardPos[i]);
                }
            }
        }

        public void ChangeImage(object sender, EventArgs e)
        {
            Button buffButton = (Button)sender;
            if (buffButton.Image != null && !daCardUsed && !sCardUsed)
            {
                return;
            }
            else if (queue)
            {
                infoBar.Text = "<-BLUE TURN!";
                if (daCardUsed)
                {
                    if (buffButton.Image != null)
                    {
                        buffButton.Image = crossAndCircle;
                    }
                    daCardUsed = false;
                }
                else
                {
                    buffButton.Image = cross;
                }
                if (sCardUsed)
                {
                    drawNumb--;
                    if (buffButton.Image != null)
                    {
                        buffButton.Image = null;
                    }
                    sCardUsed = false;
                }
                else
                {
                    buffButton.Image = cross;
                }
                drawNumb++;
                queue = false;
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    redCardArr[i].Enabled = false;
                }
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    blueCardArr[i].Enabled = true;
                }
                if (blueCardArr.Count < 3)
                {
                    CreateRandomCards();
                }
            }
            else if (!queue)
            {
                infoBar.Text = "RED TURN!->";
                if (daCardUsed)
                {
                    if (buffButton.Image != null)
                    {
                        buffButton.Image = crossAndCircle;
                        daCardUsed = false;
                    }
                }
                else
                {
                    buffButton.Image = circle;
                }
                if (sCardUsed)
                {
                    drawNumb--;
                    if (buffButton.Image != null)
                    {
                        buffButton.Image = null;
                    }
                    sCardUsed = false;
                }
                else
                {
                    buffButton.Image = circle;
                }
                drawNumb++;
                queue = true;
                for (int i = 0; i < redCardArr.Count; i++)
                {
                    redCardArr[i].Enabled = true;
                }
                for (int i = 0; i < blueCardArr.Count; i++)
                {
                    blueCardArr[i].Enabled = false;
                }
                if (redCardArr.Count < 3)
                {
                    CreateRandomCards();
                }
            }
            WinLoseSystem();
        }

        public void WinLoseSystem()
        {
            if (drawNumb >= 9)
            {
                infoBar.Text = "DRAW!";
                tryAgainButton.Visible = true;
                backButton.Location = new Point(275, 377);
                return;
            }
            for (int i = 0; i < 3; i++)
            {
                if ((gameFieldMain[i, 0].Image == circle || gameFieldMain[i, 0].Image == crossAndCircle) && (gameFieldMain[i, 0].Image == gameFieldMain[i, 1].Image || gameFieldMain[i, 1].Image == crossAndCircle) &&
                    ((gameFieldMain[i, 1].Image == gameFieldMain[i, 2].Image) || gameFieldMain[i, 2].Image == crossAndCircle) ||
                   (gameFieldMain[0, i].Image == circle && gameFieldMain[0, i].Image == gameFieldMain[1, i].Image && gameFieldMain[1, i].Image == gameFieldMain[2, i].Image))
                {
                    infoBar.Text = "BLUE WON!";
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            gameFieldMain[j, k].Enabled = false;   
                        }
                    }
                    tryAgainButton.Visible = true;
                    backButton.Location = new Point(275, 377);
                }
                if ((gameFieldMain[i, 0].Image == cross && gameFieldMain[i, 0].Image == gameFieldMain[i, 1].Image && gameFieldMain[i, 1].Image == gameFieldMain[i, 2].Image) ||
                        (gameFieldMain[0, i].Image == cross && gameFieldMain[0, i].Image == gameFieldMain[1, i].Image && gameFieldMain[1, i].Image == gameFieldMain[2, i].Image))
                {
                    infoBar.Text = "RED WON!";
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            gameFieldMain[j, k].Enabled = false;
                        }
                    }
                    tryAgainButton.Visible = true;
                    backButton.Location = new Point(275, 377);
                }
            }
            if ((gameFieldMain[0, 0].Image == circle && gameFieldMain[0, 0].Image == gameFieldMain[1, 1].Image && gameFieldMain[1, 1].Image == gameFieldMain[2, 2].Image) ||
                    (gameFieldMain[2, 0].Image == circle && gameFieldMain[2, 0].Image == gameFieldMain[1, 1].Image && gameFieldMain[1, 1].Image == gameFieldMain[0, 2].Image))
            {
                infoBar.Text = "BLUE WON!";
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        gameFieldMain[j, k].Enabled = false;
                    }
                }
                tryAgainButton.Visible = true;
                backButton.Location = new Point(275, 377);
            }
            if ((gameFieldMain[0, 0].Image == cross && gameFieldMain[0, 0].Image == gameFieldMain[1, 1].Image && gameFieldMain[1, 1].Image == gameFieldMain[2, 2].Image) ||
                    (gameFieldMain[2, 0].Image == cross && gameFieldMain[2, 0].Image == gameFieldMain[1, 1].Image && gameFieldMain[1, 1].Image == gameFieldMain[0, 2].Image))
            {
                infoBar.Text = "RED WON!";
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        gameFieldMain[j, k].Enabled = false;
                    }
                }
                tryAgainButton.Visible = true;
                backButton.Location = new Point(275, 377);
            }
        }

        public void QueueAI()
        {
            queue = false;
            int rand = rnd.Next(0, 10);
            if (rand <= 5)
            {
                infoBar.Text = "RED STARTS FIRST!";
                queue = true;
            }
            else if (rand >= 5)
            {
                infoBar.Text = "BLUE STARTS FIRST!";
                queue = false;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void tryAgainButton_Click(object sender, EventArgs e)
        {
            QueueAI();
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    gameFieldMain[i, j].Image = null;
                }
            }
            drawNumb = 0;
            tryAgainButton.Visible = false;
            backButton.Location = new Point(342, 377);
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    gameFieldMain[j, k].Enabled = true;
                }
            }
            CreateStartCards();
        }
    }
}