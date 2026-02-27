namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelBody = new System.Windows.Forms.Panel();
            this.lblExsaptionColor = new System.Windows.Forms.Label();
            this.txtBoxColor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelHead = new System.Windows.Forms.Panel();
            this.labelHead = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelBody.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBody
            // 
            this.panelBody.AutoSize = true;
            this.panelBody.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panelBody.Controls.Add(this.lblExsaptionColor);
            this.panelBody.Controls.Add(this.txtBoxColor);
            this.panelBody.Controls.Add(this.button1);
            this.panelBody.Controls.Add(this.panelHead);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 0);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(657, 559);
            this.panelBody.TabIndex = 0;
            // 
            // lblExsaptionColor
            // 
            this.lblExsaptionColor.BackColor = System.Drawing.Color.Red;
            this.lblExsaptionColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExsaptionColor.Location = new System.Drawing.Point(424, 93);
            this.lblExsaptionColor.Name = "lblExsaptionColor";
            this.lblExsaptionColor.Size = new System.Drawing.Size(176, 100);
            this.lblExsaptionColor.TabIndex = 4;
            this.lblExsaptionColor.Text = "Ошибка: введен некоректный цвет\r\nИспользуйте зеленый красный или синий\r\n";
            this.lblExsaptionColor.Visible = false;
            // 
            // txtBoxColor
            // 
            this.txtBoxColor.Location = new System.Drawing.Point(246, 152);
            this.txtBoxColor.Multiline = true;
            this.txtBoxColor.Name = "txtBoxColor";
            this.txtBoxColor.Size = new System.Drawing.Size(172, 41);
            this.txtBoxColor.TabIndex = 2;
            this.txtBoxColor.Visible = false;
            this.txtBoxColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxColor_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.button1.Location = new System.Drawing.Point(246, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "Кнопка";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelHead.Controls.Add(this.labelHead);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(657, 75);
            this.panelHead.TabIndex = 0;
            // 
            // labelHead
            // 
            this.labelHead.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHead.Font = new System.Drawing.Font("Microsoft YaHei UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHead.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelHead.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelHead.Location = new System.Drawing.Point(0, 0);
            this.labelHead.Name = "labelHead";
            this.labelHead.Size = new System.Drawing.Size(657, 75);
            this.labelHead.TabIndex = 2;
            this.labelHead.Text = "Нажми на кнопку ";
            this.labelHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 559);
            this.Controls.Add(this.panelBody);
            this.Name = "Form1";
            this.Text = " ";
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panelHead.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelHead;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtBoxColor;
        private System.Windows.Forms.Label lblExsaptionColor;
    }
}

