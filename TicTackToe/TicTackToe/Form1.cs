using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace TicTackToe
{
    public partial class Form1 : Form
    {
        public int charmanderTurn = 0;
        public int pikachuTurn = 1;
        public int whoseTurn = 0;
        public int pikachuWins = 0;
        public int charmanderWins = 0;
        public int catGameCounter = 0;
        public static string path = Environment.CurrentDirectory;
        public static string pikachuPath = Path.Combine(path, "pikachu.png");
        public SoundPlayer soundplayer = new SoundPlayer();

        Image charmander = new Bitmap(Path.Combine(path, "Charmander.png"));
        Image pikachu = new Bitmap(pikachuPath);
        Image backgroundImage = new Bitmap(Path.Combine(path, "PikachuBackground.jpg"));
        

        public void DisableBoard()
        {
            topLeft.Enabled = false;
            middleTop.Enabled = false;
            topRight.Enabled = false;
            middleLeft.Enabled = false;
            middle.Enabled = false;
            middleRight.Enabled = false;
            bottomLeft.Enabled = false;
            bottomRight.Enabled = false;
            bottomMiddle.Enabled = false;
        }
        
        public void EnableBoard()
        {
            topLeft.Enabled = true;
            middleTop.Enabled = true ;
            topRight.Enabled = true;
            middleLeft.Enabled = true;
            middle.Enabled = true;
            middleRight.Enabled = true;
            bottomLeft.Enabled = true;
            bottomRight.Enabled = true;
            bottomMiddle.Enabled = true;

        }

        public void PikachuWins()
        {
            pikachuWins += 1;
            labelPikachuWins.Text = pikachuWins.ToString();
            DisableBoard();
            resetGame.Enabled = true;
            pikachuWinsBanner.Visible = true;
            if (pikachuWins == 2)
            {
                resetGame.Enabled = false;
                newGame.Enabled = true;
                pikachuSeriesWin.Visible = true;
            }
        }

        public void CharmanderWins()
        {
            charmanderWins += 1;
            labelCharmanderWins.Text = charmanderWins.ToString();
            DisableBoard();
            resetGame.Enabled = true;
            charmanderWinsBanner.Visible = true;
            if (charmanderWins == 2)
            {
                resetGame.Enabled = false;
                newGame.Enabled = true;
                charmanderSeriesWin.Visible = true;
            }
        }
        public void CatGame()
        {
            DisableBoard();
            resetGame.Enabled = true;
            catGameLabel.Visible = true;
        }
        
        public Form1()
        {
            InitializeComponent();

            soundplayer.SoundLocation = (Path.Combine(path, "pokemon.wav"));
            soundplayer.Play();
            BackgroundImage = backgroundImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            whoseTurn = random.Next(2);
            newGame.Enabled = false;
            middle.Enabled = true;
            topLeft.Enabled = true;
            topRight.Enabled = true;
            middleTop.Enabled = true;
            middleRight.Enabled = true;
            middleLeft.Enabled = true;
            middleRight.Enabled = true;
            bottomLeft.Enabled = true;
            bottomRight.Enabled = true;
            bottomMiddle.Enabled = true;
            pikachuWins = 0;
            charmanderWins = 0;
            catGameCounter = 0;
            labelPikachuWins.Text = "0";
            labelCharmanderWins.Text = "0";
            topRight.BackgroundImage = null;
            middleTop.BackgroundImage = null;
            topLeft.BackgroundImage = null;
            middleRight.BackgroundImage = null;
            middle.BackgroundImage = null;
            middleLeft.BackgroundImage = null;
            bottomRight.BackgroundImage = null;
            bottomMiddle.BackgroundImage = null;
            bottomLeft.BackgroundImage = null;
            pikachuWinsBanner.Visible = false;
            charmanderWinsBanner.Visible = false;
            pikachuSeriesWin.Visible = false;
            charmanderSeriesWin.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            EnableBoard();
            resetGame.Enabled = false;
            catGameCounter = 0;
            Random random = new Random();
            whoseTurn = random.Next(2);
            pikachuWinsBanner.Visible = false;
            charmanderWinsBanner.Visible = false;
            catGameLabel.Visible = false;

            topRight.BackgroundImage = null;
            middleTop.BackgroundImage = null;
            topLeft.BackgroundImage = null;
            middleRight.BackgroundImage = null;
            middle.BackgroundImage = null;
            middleLeft.BackgroundImage = null;
            bottomRight.BackgroundImage = null;
            bottomMiddle.BackgroundImage = null;
            bottomLeft.BackgroundImage = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bottomRight_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                bottomRight.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                bottomRight.Enabled = false;
                catGameCounter += 1;

                if ((middle.BackgroundImage == charmander && topLeft.BackgroundImage == charmander)
                    || (middleRight.BackgroundImage == charmander && topRight.BackgroundImage == charmander)
                    || (bottomMiddle.BackgroundImage == charmander && bottomLeft.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
            else
            {
                bottomRight.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                bottomRight.Enabled = false;
                catGameCounter += 1;

                if ((middle.BackgroundImage == pikachu && topLeft.BackgroundImage == pikachu)
                    || (middleRight.BackgroundImage == pikachu && topRight.BackgroundImage == pikachu)
                    || (bottomMiddle.BackgroundImage == pikachu && bottomLeft.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
        }

        private void topLeft_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                topLeft.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                topLeft.Enabled = false;
                catGameCounter += 1;

                if ((middleTop.BackgroundImage == charmander && topRight.BackgroundImage == charmander)
               || (middleLeft.BackgroundImage == charmander && bottomLeft.BackgroundImage == charmander)
               || (middle.BackgroundImage == charmander && bottomRight.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }

            }
            else  
            {
                topLeft.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                topLeft.Enabled = false;
                catGameCounter += 1;

               if ((middleTop.BackgroundImage == pikachu && topRight.BackgroundImage == pikachu)
               || (middleLeft.BackgroundImage == pikachu && bottomLeft.BackgroundImage == pikachu)
               || (middle.BackgroundImage == pikachu && bottomRight.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
                       
        }

        private void middleTop_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                middleTop.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                middleTop.Enabled = false;
                catGameCounter += 1;

               if ((topLeft.BackgroundImage == charmander && topRight.BackgroundImage == charmander)
               || middle.BackgroundImage == charmander && bottomMiddle.BackgroundImage == charmander)
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }

            }
            else
            {
                middleTop.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                middleTop.Enabled = false;
                catGameCounter += 1;

               if ((topLeft.BackgroundImage == pikachu && topRight.BackgroundImage == pikachu)
               || middle.BackgroundImage == pikachu && bottomMiddle.BackgroundImage == pikachu)
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
                      
           
        }

        private void topRight_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                topRight.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                topRight.Enabled = false;
                catGameCounter += 1;

                if ((middleTop.BackgroundImage == charmander && topLeft.BackgroundImage == charmander)
                || (middle.BackgroundImage == charmander && bottomLeft.BackgroundImage == charmander)
                || (middleRight.BackgroundImage == charmander && bottomRight.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }

            }
            else
            {
                topRight.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                topRight.Enabled = false; 
                catGameCounter += 1;

                if ((middleTop.BackgroundImage == pikachu && topLeft.BackgroundImage == pikachu)
                || (middle.BackgroundImage == pikachu && bottomLeft.BackgroundImage == pikachu)
                || (middleRight.BackgroundImage == pikachu && bottomRight.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
                     
            
        }

        private void middleLeft_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                middleLeft.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                middleLeft.Enabled = false;
                catGameCounter += 1;

                if ((topLeft.BackgroundImage == charmander && bottomLeft.BackgroundImage == charmander)
                || (middle.BackgroundImage == charmander && middleRight.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }

            }
            else
            {
                middleLeft.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                middleLeft.Enabled = false;
                catGameCounter += 1;

                if ((topLeft.BackgroundImage == pikachu && bottomLeft.BackgroundImage == pikachu)
                || (middle.BackgroundImage == pikachu && middleRight.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
                        
            
        }

        private void middle_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                middle.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                middle.Enabled = false;
                catGameCounter += 1;

                if ((middleLeft.BackgroundImage == charmander && middleRight.BackgroundImage == charmander) 
                    || (bottomMiddle.BackgroundImage == charmander && middleTop.BackgroundImage == charmander)
                    || (topLeft.BackgroundImage == charmander && bottomRight.BackgroundImage == charmander)
                    || (topRight.BackgroundImage == charmander && bottomLeft.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }

            }
            else
            {
                middle.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                middle.Enabled = false;
                catGameCounter += 1;

                if ((middleLeft.BackgroundImage == pikachu && middleRight.BackgroundImage == pikachu)
                    || (bottomMiddle.BackgroundImage == pikachu && middleTop.BackgroundImage == pikachu)
                    || (topLeft.BackgroundImage == pikachu && bottomRight.BackgroundImage == pikachu)
                    || (topRight.BackgroundImage == pikachu && bottomLeft.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }

            }
            
        }

        private void middleRight_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                middleRight.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                middleRight.Enabled = false;
                catGameCounter += 1;

                if ((topRight.BackgroundImage == charmander && bottomRight.BackgroundImage == charmander)
                    || (middle.BackgroundImage == charmander && middleLeft.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }

            }
            else
            {
                middleRight.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                middleRight.Enabled = false;
                catGameCounter += 1;

                if ((topRight.BackgroundImage == pikachu && bottomRight.BackgroundImage == pikachu)
                    || (middle.BackgroundImage == pikachu && middleLeft.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
            
        }

        private void bottomLeft_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                bottomLeft.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                bottomLeft.Enabled = false;
                catGameCounter += 1;

                if ((middleLeft.BackgroundImage == charmander && topLeft.BackgroundImage == charmander) 
                    || (bottomMiddle.BackgroundImage == charmander && bottomRight.BackgroundImage == charmander)
                    || (middle.BackgroundImage == charmander && topRight.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
            else
            {
                bottomLeft.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                bottomLeft.Enabled = false;
                catGameCounter += 1;

                if ((middleLeft.BackgroundImage == pikachu && topLeft.BackgroundImage == pikachu)
                    || (bottomMiddle.BackgroundImage == pikachu && bottomRight.BackgroundImage == pikachu)
                    || (middle.BackgroundImage == pikachu && topRight.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
            
        }

        private void bottomMiddle_Click(object sender, EventArgs e)
        {
            if (whoseTurn == charmanderTurn)
            {
                bottomMiddle.BackgroundImage = charmander;
                whoseTurn = pikachuTurn;
                bottomMiddle.Enabled = false;
                catGameCounter += 1;

                if ((middle.BackgroundImage == charmander && middleTop.BackgroundImage == charmander) 
                    || (bottomLeft.BackgroundImage == charmander && bottomRight.BackgroundImage == charmander))
                {
                    CharmanderWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
            else
            {
                bottomMiddle.BackgroundImage = pikachu;
                whoseTurn = charmanderTurn;
                bottomMiddle.Enabled = false;
                catGameCounter += 1;

                if ((middle.BackgroundImage == pikachu && middleTop.BackgroundImage == pikachu)
                    || (bottomLeft.BackgroundImage == pikachu && bottomRight.BackgroundImage == pikachu))
                {
                    PikachuWins();
                }
                else if (catGameCounter == 9)
                {
                    CatGame();
                }
            }
        }

        
    }
}
