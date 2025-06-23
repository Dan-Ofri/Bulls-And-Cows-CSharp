namespace Ex05
{
    partial class GuessLine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guess1 = new System.Windows.Forms.Button();
            this.guess2 = new System.Windows.Forms.Button();
            this.guess3 = new System.Windows.Forms.Button();
            this.guess4 = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.feedbackButton1 = new System.Windows.Forms.Button();
            this.feedbackButton2 = new System.Windows.Forms.Button();
            this.feedbackButton4 = new System.Windows.Forms.Button();
            this.feedbackButton3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guess1
            // 
            this.guess1.Enabled = false;
            this.guess1.Location = new System.Drawing.Point(0, 3);
            this.guess1.Name = "guess1";
            this.guess1.Size = new System.Drawing.Size(40, 40);
            this.guess1.TabIndex = 0;
            this.guess1.UseVisualStyleBackColor = true;
            // 
            // guess2
            // 
            this.guess2.Enabled = false;
            this.guess2.Location = new System.Drawing.Point(46, 3);
            this.guess2.Name = "guess2";
            this.guess2.Size = new System.Drawing.Size(40, 40);
            this.guess2.TabIndex = 10;
            this.guess2.UseVisualStyleBackColor = true;
            // 
            // guess3
            // 
            this.guess3.Enabled = false;
            this.guess3.Location = new System.Drawing.Point(92, 3);
            this.guess3.Name = "guess3";
            this.guess3.Size = new System.Drawing.Size(40, 40);
            this.guess3.TabIndex = 30;
            this.guess3.UseVisualStyleBackColor = true;
            // 
            // guess4
            // 
            this.guess4.Enabled = false;
            this.guess4.Location = new System.Drawing.Point(138, 3);
            this.guess4.Name = "guess4";
            this.guess4.Size = new System.Drawing.Size(40, 40);
            this.guess4.TabIndex = 40;
            this.guess4.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(184, 13);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(40, 20);
            this.submitButton.TabIndex = 50;
            this.submitButton.Text = "-->>";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // feedbackButton1
            // 
            this.feedbackButton1.Enabled = false;
            this.feedbackButton1.Location = new System.Drawing.Point(240, 7);
            this.feedbackButton1.Name = "feedbackButton1";
            this.feedbackButton1.Size = new System.Drawing.Size(18, 18);
            this.feedbackButton1.TabIndex = 0;
            this.feedbackButton1.UseVisualStyleBackColor = true;
            // 
            // feedbackButton2
            // 
            this.feedbackButton2.Enabled = false;
            this.feedbackButton2.Location = new System.Drawing.Point(260, 7);
            this.feedbackButton2.Name = "feedbackButton2";
            this.feedbackButton2.Size = new System.Drawing.Size(18, 18);
            this.feedbackButton2.TabIndex = 0;
            this.feedbackButton2.UseVisualStyleBackColor = true;
            // 
            // feedbackButton4
            // 
            this.feedbackButton4.Enabled = false;
            this.feedbackButton4.Location = new System.Drawing.Point(260, 25);
            this.feedbackButton4.Name = "feedbackButton4";
            this.feedbackButton4.Size = new System.Drawing.Size(18, 18);
            this.feedbackButton4.TabIndex = 0;
            this.feedbackButton4.UseVisualStyleBackColor = true;
            // 
            // feedbackButton3
            // 
            this.feedbackButton3.Enabled = false;
            this.feedbackButton3.Location = new System.Drawing.Point(240, 25);
            this.feedbackButton3.Name = "feedbackButton3";
            this.feedbackButton3.Size = new System.Drawing.Size(18, 18);
            this.feedbackButton3.TabIndex = 0;
            this.feedbackButton3.UseVisualStyleBackColor = true;
            // 
            // GuessLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.feedbackButton3);
            this.Controls.Add(this.feedbackButton4);
            this.Controls.Add(this.feedbackButton2);
            this.Controls.Add(this.feedbackButton1);
            this.Controls.Add(this.guess4);
            this.Controls.Add(this.guess3);
            this.Controls.Add(this.guess2);
            this.Controls.Add(this.guess1);
            this.Name = "GuessLine";
            this.Size = new System.Drawing.Size(290, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button guess1;
        private System.Windows.Forms.Button guess2;
        private System.Windows.Forms.Button guess3;
        private System.Windows.Forms.Button guess4;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button feedbackButton1;
        private System.Windows.Forms.Button feedbackButton2;
        private System.Windows.Forms.Button feedbackButton4;
        private System.Windows.Forms.Button feedbackButton3;
    }
}
