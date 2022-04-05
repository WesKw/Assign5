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
            ((System.ComponentModel.ISupportInitialize)(this.Game)).BeginInit();
            this.SuspendLayout();
            // 
            // Game
            // 
            this.Game.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Game.BackColor = System.Drawing.SystemColors.Desktop;
            this.Game.Location = new System.Drawing.Point(12, 6);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(640, 590);
            this.Game.TabIndex = 0;
            this.Game.TabStop = false;
            this.Game.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Location = new System.Drawing.Point(809, 9);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(70, 16);
            this.ResultsLabel.TabIndex = 1;
            this.ResultsLabel.Text = "RESULTS";
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1029, 612);
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.Game);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Chess";
            this.Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)(this.Game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Game;
        private System.Windows.Forms.Label ResultsLabel;
    }
}

