namespace Tanks
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
            lblDie = new Label();
            lblRebHP = new Label();
            lblBlueHP = new Label();
            SuspendLayout();
            // 
            // lblDie
            // 
            lblDie.BackColor = Color.LimeGreen;
            lblDie.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDie.ForeColor = SystemColors.ButtonHighlight;
            lblDie.Location = new Point(260, 176);
            lblDie.Name = "lblDie";
            lblDie.Size = new Size(294, 87);
            lblDie.TabIndex = 0;
            lblDie.Visible = false;
            // 
            // lblRebHP
            // 
            lblRebHP.AutoSize = true;
            lblRebHP.BackColor = Color.Red;
            lblRebHP.ForeColor = SystemColors.ButtonHighlight;
            lblRebHP.Location = new Point(720, 524);
            lblRebHP.Name = "lblRebHP";
            lblRebHP.Size = new Size(54, 20);
            lblRebHP.TabIndex = 1;
            lblRebHP.Text = "100 hp";
            // 
            // lblBlueHP
            // 
            lblBlueHP.AutoSize = true;
            lblBlueHP.BackColor = Color.Blue;
            lblBlueHP.ForeColor = SystemColors.ButtonHighlight;
            lblBlueHP.Location = new Point(12, 9);
            lblBlueHP.Name = "lblBlueHP";
            lblBlueHP.Size = new Size(54, 20);
            lblBlueHP.TabIndex = 2;
            lblBlueHP.Text = "100 hp";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(lblBlueHP);
            Controls.Add(lblRebHP);
            Controls.Add(lblDie);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDie;
        private Label lblRebHP;
        private Label lblBlueHP;
    }
}
