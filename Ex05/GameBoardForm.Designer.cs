namespace Ex05
{
    partial class GameBoardForm
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
            this.secretButton1 = new System.Windows.Forms.Button();
            this.secretButton2 = new System.Windows.Forms.Button();
            this.secretButton3 = new System.Windows.Forms.Button();
            this.secretButton4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // secretButton1
            // 
            this.secretButton1.BackColor = System.Drawing.SystemColors.ControlText;
            this.secretButton1.Enabled = false;
            this.secretButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secretButton1.Location = new System.Drawing.Point(12, 12);
            this.secretButton1.Name = "secretButton1";
            this.secretButton1.Size = new System.Drawing.Size(40, 40);
            this.secretButton1.TabIndex = 0;
            this.secretButton1.UseVisualStyleBackColor = false;
            // 
            // secretButton2
            // 
            this.secretButton2.BackColor = System.Drawing.SystemColors.ControlText;
            this.secretButton2.Enabled = false;
            this.secretButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secretButton2.Location = new System.Drawing.Point(58, 12);
            this.secretButton2.Name = "secretButton2";
            this.secretButton2.Size = new System.Drawing.Size(40, 40);
            this.secretButton2.TabIndex = 0;
            this.secretButton2.UseVisualStyleBackColor = false;
            // 
            // secretButton3
            // 
            this.secretButton3.BackColor = System.Drawing.SystemColors.ControlText;
            this.secretButton3.Enabled = false;
            this.secretButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secretButton3.Location = new System.Drawing.Point(104, 12);
            this.secretButton3.Name = "secretButton3";
            this.secretButton3.Size = new System.Drawing.Size(40, 40);
            this.secretButton3.TabIndex = 0;
            this.secretButton3.UseVisualStyleBackColor = false;
            // 
            // secretButton4
            // 
            this.secretButton4.BackColor = System.Drawing.SystemColors.ControlText;
            this.secretButton4.Enabled = false;
            this.secretButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secretButton4.Location = new System.Drawing.Point(150, 12);
            this.secretButton4.Name = "secretButton4";
            this.secretButton4.Size = new System.Drawing.Size(40, 40);
            this.secretButton4.TabIndex = 0;
            this.secretButton4.UseVisualStyleBackColor = false;
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 366);
            this.Controls.Add(this.secretButton4);
            this.Controls.Add(this.secretButton3);
            this.Controls.Add(this.secretButton2);
            this.Controls.Add(this.secretButton1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameBoardForm";
            this.Text = "GameBoardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button secretButton1;
        private System.Windows.Forms.Button secretButton2;
        private System.Windows.Forms.Button secretButton3;
        private System.Windows.Forms.Button secretButton4;
    }
}