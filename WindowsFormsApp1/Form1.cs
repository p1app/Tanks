using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtBoxColor.Visible = true;
            this.labelHead.Text = "Введите один из трех цветов rgb";
        }



        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.MediumBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
        }



        public async void CloseForColor()
        {
            await Task.Delay(2500);
            this.Close();
        }



        private void txtBoxColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string text = txtBoxColor.Text.ToLower();
                switch (text)
                {
                    case "red":
                    case "красный":
                        this.panelBody.BackColor = System.Drawing.Color.Red;
                        break;
                    case "green":
                    case "зеленый":
                        this.panelBody.BackColor = System.Drawing.Color.Green;
                        break;
                    case "blue":
                    case "синий":
                        this.panelBody.BackColor = System.Drawing.Color.Blue;
                        break;
                    default:
                        this.lblExsaptionColor.Visible = true;
                        CloseForColor();
                        break;
                }
            }
        }
    }
}
