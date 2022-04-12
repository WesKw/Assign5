namespace Assign5
{
    partial class Chess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Game = new System.Windows.Forms.PictureBox();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.CurrentPlayerLabel = new System.Windows.Forms.Label();
            this.CheckmateLabel = new System.Windows.Forms.Label();
            this.feedbackBox = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Game)).BeginInit();
            this.SuspendLayout();
            // 
            // Game
            // 
            this.Game.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Game.BackColor = System.Drawing.SystemColors.Desktop;
            this.Game.Location = new System.Drawing.Point(14, 15);
            this.Game.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(720, 738);
            this.Game.TabIndex = 0;
            this.Game.TabStop = false;
            this.Game.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.Game.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Location = new System.Drawing.Point(909, 15);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(84, 20);
            this.ResultsLabel.TabIndex = 1;
            this.ResultsLabel.Text = "RESULTS";
            // 
            // CurrentPlayerLabel
            // 
            this.CurrentPlayerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CurrentPlayerLabel.AutoSize = true;
            this.CurrentPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPlayerLabel.Location = new System.Drawing.Point(14, 778);
            this.CurrentPlayerLabel.Name = "CurrentPlayerLabel";
            this.CurrentPlayerLabel.Size = new System.Drawing.Size(200, 25);
            this.CurrentPlayerLabel.TabIndex = 2;
            this.CurrentPlayerLabel.Text = "Current Turn: White";
            // 
            // CheckmateLabel
            // 
            this.CheckmateLabel.AutoSize = true;
            this.CheckmateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckmateLabel.Location = new System.Drawing.Point(557, 778);
            this.CheckmateLabel.Name = "CheckmateLabel";
            this.CheckmateLabel.Size = new System.Drawing.Size(0, 25);
            this.CheckmateLabel.TabIndex = 3;
            // 
            // feedbackBox
            // 
            this.feedbackBox.Location = new System.Drawing.Point(752, 670);
            this.feedbackBox.Name = "feedbackBox";
            this.feedbackBox.Size = new System.Drawing.Size(394, 146);
            this.feedbackBox.TabIndex = 4;
            this.feedbackBox.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(814, 79);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(291, 548);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1158, 828);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.feedbackBox);
            this.Controls.Add(this.CheckmateLabel);
            this.Controls.Add(this.CurrentPlayerLabel);
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.Game);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Chess";
            this.Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)(this.Game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Game;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.Label CurrentPlayerLabel;
        private System.Windows.Forms.Label CheckmateLabel;
        private System.Windows.Forms.RichTextBox feedbackBox;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

