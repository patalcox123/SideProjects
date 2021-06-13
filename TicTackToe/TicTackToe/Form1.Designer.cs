
namespace TicTackToe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newGame = new System.Windows.Forms.Button();
            this.exitGame = new System.Windows.Forms.Button();
            this.resetGame = new System.Windows.Forms.Button();
            this.topLeft = new System.Windows.Forms.Button();
            this.middleTop = new System.Windows.Forms.Button();
            this.topRight = new System.Windows.Forms.Button();
            this.middleLeft = new System.Windows.Forms.Button();
            this.middle = new System.Windows.Forms.Button();
            this.middleRight = new System.Windows.Forms.Button();
            this.bottomMiddle = new System.Windows.Forms.Button();
            this.bottomLeft = new System.Windows.Forms.Button();
            this.bottomRight = new System.Windows.Forms.Button();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelCharmanderWins = new System.Windows.Forms.Label();
            this.labelPikachuWins = new System.Windows.Forms.Label();
            this.pikachuWinsBanner = new System.Windows.Forms.Label();
            this.charmanderWinsBanner = new System.Windows.Forms.Label();
            this.catGameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pikachuSeriesWin = new System.Windows.Forms.Label();
            this.charmanderSeriesWin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(713, 506);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(142, 73);
            this.newGame.TabIndex = 0;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // exitGame
            // 
            this.exitGame.Location = new System.Drawing.Point(802, 602);
            this.exitGame.Name = "exitGame";
            this.exitGame.Size = new System.Drawing.Size(142, 73);
            this.exitGame.TabIndex = 1;
            this.exitGame.Text = "Exit Game";
            this.exitGame.UseVisualStyleBackColor = true;
            this.exitGame.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // resetGame
            // 
            this.resetGame.Enabled = false;
            this.resetGame.Location = new System.Drawing.Point(895, 506);
            this.resetGame.Name = "resetGame";
            this.resetGame.Size = new System.Drawing.Size(142, 73);
            this.resetGame.TabIndex = 2;
            this.resetGame.Text = "Reset Game";
            this.resetGame.UseVisualStyleBackColor = true;
            this.resetGame.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // topLeft
            // 
            this.topLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topLeft.Enabled = false;
            this.topLeft.Location = new System.Drawing.Point(135, 107);
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(146, 135);
            this.topLeft.TabIndex = 3;
            this.topLeft.UseVisualStyleBackColor = true;
            this.topLeft.Click += new System.EventHandler(this.topLeft_Click);
            // 
            // middleTop
            // 
            this.middleTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.middleTop.Enabled = false;
            this.middleTop.Location = new System.Drawing.Point(330, 107);
            this.middleTop.Name = "middleTop";
            this.middleTop.Size = new System.Drawing.Size(146, 135);
            this.middleTop.TabIndex = 4;
            this.middleTop.UseVisualStyleBackColor = true;
            this.middleTop.Click += new System.EventHandler(this.middleTop_Click);
            // 
            // topRight
            // 
            this.topRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topRight.Enabled = false;
            this.topRight.Location = new System.Drawing.Point(519, 107);
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(146, 135);
            this.topRight.TabIndex = 5;
            this.topRight.UseVisualStyleBackColor = true;
            this.topRight.Click += new System.EventHandler(this.topRight_Click);
            // 
            // middleLeft
            // 
            this.middleLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.middleLeft.Enabled = false;
            this.middleLeft.Location = new System.Drawing.Point(135, 274);
            this.middleLeft.Name = "middleLeft";
            this.middleLeft.Size = new System.Drawing.Size(146, 135);
            this.middleLeft.TabIndex = 6;
            this.middleLeft.UseVisualStyleBackColor = true;
            this.middleLeft.Click += new System.EventHandler(this.middleLeft_Click);
            // 
            // middle
            // 
            this.middle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.middle.Enabled = false;
            this.middle.Location = new System.Drawing.Point(330, 274);
            this.middle.Name = "middle";
            this.middle.Size = new System.Drawing.Size(146, 135);
            this.middle.TabIndex = 7;
            this.middle.UseVisualStyleBackColor = true;
            this.middle.Click += new System.EventHandler(this.middle_Click);
            // 
            // middleRight
            // 
            this.middleRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.middleRight.Enabled = false;
            this.middleRight.Location = new System.Drawing.Point(519, 274);
            this.middleRight.Name = "middleRight";
            this.middleRight.Size = new System.Drawing.Size(146, 135);
            this.middleRight.TabIndex = 8;
            this.middleRight.UseVisualStyleBackColor = true;
            this.middleRight.Click += new System.EventHandler(this.middleRight_Click);
            // 
            // bottomMiddle
            // 
            this.bottomMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottomMiddle.Enabled = false;
            this.bottomMiddle.Location = new System.Drawing.Point(330, 434);
            this.bottomMiddle.Name = "bottomMiddle";
            this.bottomMiddle.Size = new System.Drawing.Size(146, 135);
            this.bottomMiddle.TabIndex = 9;
            this.bottomMiddle.UseVisualStyleBackColor = true;
            this.bottomMiddle.Click += new System.EventHandler(this.bottomMiddle_Click);
            // 
            // bottomLeft
            // 
            this.bottomLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottomLeft.Enabled = false;
            this.bottomLeft.Location = new System.Drawing.Point(135, 434);
            this.bottomLeft.Name = "bottomLeft";
            this.bottomLeft.Size = new System.Drawing.Size(146, 135);
            this.bottomLeft.TabIndex = 10;
            this.bottomLeft.UseVisualStyleBackColor = true;
            this.bottomLeft.Click += new System.EventHandler(this.bottomLeft_Click);
            // 
            // bottomRight
            // 
            this.bottomRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottomRight.Enabled = false;
            this.bottomRight.Location = new System.Drawing.Point(519, 434);
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(146, 135);
            this.bottomRight.TabIndex = 11;
            this.bottomRight.UseVisualStyleBackColor = true;
            this.bottomRight.Click += new System.EventHandler(this.bottomRight_Click);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer1.Location = new System.Drawing.Point(723, 127);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(298, 65);
            this.labelPlayer1.TabIndex = 12;
            this.labelPlayer1.Text = "Charmander:";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPlayer2.Location = new System.Drawing.Point(820, 231);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(201, 65);
            this.labelPlayer2.TabIndex = 13;
            this.labelPlayer2.Text = "Pikachu:";
            // 
            // labelCharmanderWins
            // 
            this.labelCharmanderWins.AutoSize = true;
            this.labelCharmanderWins.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCharmanderWins.Location = new System.Drawing.Point(1036, 127);
            this.labelCharmanderWins.Name = "labelCharmanderWins";
            this.labelCharmanderWins.Size = new System.Drawing.Size(54, 65);
            this.labelCharmanderWins.TabIndex = 14;
            this.labelCharmanderWins.Text = "0";
            // 
            // labelPikachuWins
            // 
            this.labelPikachuWins.AutoSize = true;
            this.labelPikachuWins.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPikachuWins.Location = new System.Drawing.Point(1036, 231);
            this.labelPikachuWins.Name = "labelPikachuWins";
            this.labelPikachuWins.Size = new System.Drawing.Size(54, 65);
            this.labelPikachuWins.TabIndex = 15;
            this.labelPikachuWins.Text = "0";
            // 
            // pikachuWinsBanner
            // 
            this.pikachuWinsBanner.AutoSize = true;
            this.pikachuWinsBanner.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pikachuWinsBanner.Location = new System.Drawing.Point(308, 591);
            this.pikachuWinsBanner.Name = "pikachuWinsBanner";
            this.pikachuWinsBanner.Size = new System.Drawing.Size(363, 65);
            this.pikachuWinsBanner.TabIndex = 16;
            this.pikachuWinsBanner.Text = "Pikachu Wins !!!";
            this.pikachuWinsBanner.Visible = false;
            // 
            // charmanderWinsBanner
            // 
            this.charmanderWinsBanner.AutoSize = true;
            this.charmanderWinsBanner.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.charmanderWinsBanner.Location = new System.Drawing.Point(308, 684);
            this.charmanderWinsBanner.Name = "charmanderWinsBanner";
            this.charmanderWinsBanner.Size = new System.Drawing.Size(460, 65);
            this.charmanderWinsBanner.TabIndex = 17;
            this.charmanderWinsBanner.Text = "Charmander Wins !!!";
            this.charmanderWinsBanner.Visible = false;
            // 
            // catGameLabel
            // 
            this.catGameLabel.AutoSize = true;
            this.catGameLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.catGameLabel.Location = new System.Drawing.Point(308, 636);
            this.catGameLabel.Name = "catGameLabel";
            this.catGameLabel.Size = new System.Drawing.Size(289, 65);
            this.catGameLabel.TabIndex = 18;
            this.catGameLabel.Text = "Cat Game !!!";
            this.catGameLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(218, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(688, 65);
            this.label2.TabIndex = 19;
            this.label2.Text = "Pokemon Tic Tac Toe (Best of 3)";
            // 
            // pikachuSeriesWin
            // 
            this.pikachuSeriesWin.AutoSize = true;
            this.pikachuSeriesWin.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pikachuSeriesWin.Location = new System.Drawing.Point(723, 326);
            this.pikachuSeriesWin.Name = "pikachuSeriesWin";
            this.pikachuSeriesWin.Size = new System.Drawing.Size(501, 65);
            this.pikachuSeriesWin.TabIndex = 20;
            this.pikachuSeriesWin.Text = "Pikachu Wins Series !!!";
            this.pikachuSeriesWin.Visible = false;
            // 
            // charmanderSeriesWin
            // 
            this.charmanderSeriesWin.AutoSize = true;
            this.charmanderSeriesWin.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.charmanderSeriesWin.Location = new System.Drawing.Point(723, 416);
            this.charmanderSeriesWin.Name = "charmanderSeriesWin";
            this.charmanderSeriesWin.Size = new System.Drawing.Size(598, 65);
            this.charmanderSeriesWin.TabIndex = 21;
            this.charmanderSeriesWin.Text = "Charmander Wins Series !!!";
            this.charmanderSeriesWin.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1102, 841);
            this.Controls.Add(this.charmanderSeriesWin);
            this.Controls.Add(this.pikachuSeriesWin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.catGameLabel);
            this.Controls.Add(this.charmanderWinsBanner);
            this.Controls.Add(this.pikachuWinsBanner);
            this.Controls.Add(this.labelPikachuWins);
            this.Controls.Add(this.labelCharmanderWins);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.bottomRight);
            this.Controls.Add(this.bottomLeft);
            this.Controls.Add(this.bottomMiddle);
            this.Controls.Add(this.middleRight);
            this.Controls.Add(this.middle);
            this.Controls.Add(this.middleLeft);
            this.Controls.Add(this.topRight);
            this.Controls.Add(this.middleTop);
            this.Controls.Add(this.topLeft);
            this.Controls.Add(this.resetGame);
            this.Controls.Add(this.exitGame);
            this.Controls.Add(this.newGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Button exitGame;
        private System.Windows.Forms.Button resetGame;
        private System.Windows.Forms.Button topLeft;
        private System.Windows.Forms.Button middleTop;
        private System.Windows.Forms.Button topRight;
        private System.Windows.Forms.Button middleLeft;
        private System.Windows.Forms.Button middle;
        private System.Windows.Forms.Button middleRight;
        private System.Windows.Forms.Button bottomMiddle;
        private System.Windows.Forms.Button bottomLeft;
        private System.Windows.Forms.Button bottomRight;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelCharmanderWins;
        private System.Windows.Forms.Label labelPlayer2Wins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label charmanderWinsBanner;
        private System.Windows.Forms.Label labelPikachuWins;
        private System.Windows.Forms.Label pikachuWinsBanner;
        private System.Windows.Forms.Label catGameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pikachuSeriesWin;
        private System.Windows.Forms.Label charmanderSeriesWin;
    }
}

