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
            this.finalResults = new System.Windows.Forms.RichTextBox();
            this.Time_Label = new System.Windows.Forms.Label();
            this.SurrenderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Game)).BeginInit();
            this.SuspendLayout();
            // 
            // Game
            // 
            this.Game.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Game.BackColor = System.Drawing.SystemColors.Desktop;
            this.Game.Location = new System.Drawing.Point(12, 12);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(640, 590);
            this.Game.TabIndex = 0;
            this.Game.TabStop = false;
            this.Game.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.Game.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Location = new System.Drawing.Point(808, 12);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(70, 16);
            this.ResultsLabel.TabIndex = 1;
            this.ResultsLabel.Text = "RESULTS";
            // 
            // CurrentPlayerLabel
            // 
            this.CurrentPlayerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CurrentPlayerLabel.AutoSize = true;
            this.CurrentPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPlayerLabel.Location = new System.Drawing.Point(12, 622);
            this.CurrentPlayerLabel.Name = "CurrentPlayerLabel";
            this.CurrentPlayerLabel.Size = new System.Drawing.Size(157, 20);
            this.CurrentPlayerLabel.TabIndex = 2;
            this.CurrentPlayerLabel.Text = "Current Turn: White";
            // 
            // CheckmateLabel
            // 
            this.CheckmateLabel.AutoSize = true;
            this.CheckmateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckmateLabel.Location = new System.Drawing.Point(495, 622);
            this.CheckmateLabel.Name = "CheckmateLabel";
            this.CheckmateLabel.Size = new System.Drawing.Size(0, 20);
            this.CheckmateLabel.TabIndex = 3;
            // 
            // feedbackBox
            // 
            this.feedbackBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.feedbackBox.Location = new System.Drawing.Point(668, 536);
            this.feedbackBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.feedbackBox.Name = "feedbackBox";
            this.feedbackBox.ReadOnly = true;
            this.feedbackBox.Size = new System.Drawing.Size(351, 118);
            this.feedbackBox.TabIndex = 4;
            this.feedbackBox.Text = "";
            // 
            // finalResults
            // 
            this.finalResults.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.finalResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalResults.Location = new System.Drawing.Point(724, 63);
            this.finalResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finalResults.Name = "finalResults";
            this.finalResults.ReadOnly = true;
            this.finalResults.Size = new System.Drawing.Size(259, 439);
            this.finalResults.TabIndex = 5;
            this.finalResults.Text = "";
            // 
            // Time_Label
            // 
            this.Time_Label.AutoSize = true;
            this.Time_Label.Location = new System.Drawing.Point(822, 36);
            this.Time_Label.Name = "Time_Label";
            this.Time_Label.Size = new System.Drawing.Size(0, 16);
            this.Time_Label.TabIndex = 6;
            // 
            // SurrenderButton
            // 
            this.SurrenderButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SurrenderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SurrenderButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SurrenderButton.Location = new System.Drawing.Point(214, 615);
            this.SurrenderButton.Name = "SurrenderButton";
            this.SurrenderButton.Size = new System.Drawing.Size(275, 37);
            this.SurrenderButton.TabIndex = 7;
            this.SurrenderButton.Text = "Surrender?";
            this.SurrenderButton.UseVisualStyleBackColor = true;
            this.SurrenderButton.Visible = false;
            this.SurrenderButton.Click += new System.EventHandler(this.SurrenderButton_Click);
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1029, 662);
            this.Controls.Add(this.SurrenderButton);
            this.Controls.Add(this.Time_Label);
            this.Controls.Add(this.finalResults);
            this.Controls.Add(this.feedbackBox);
            this.Controls.Add(this.CheckmateLabel);
            this.Controls.Add(this.CurrentPlayerLabel);
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.Game);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Chess";
            this.Text = "Chess";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Chess_KeyPress);
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
        private System.Windows.Forms.RichTextBox finalResults;
        private System.Windows.Forms.Label Time_Label;
        private System.Windows.Forms.Button SurrenderButton;
    }
}

