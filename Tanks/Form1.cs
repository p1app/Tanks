using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static Tanks.Tank;


namespace Tanks
{


    public partial class Form1 : Form
    {
        private Tank tankBlue;
        private Tank tankRed;

        public List<Element> elements;
        public List<Element> removeList = new();

        private System.Windows.Forms.Timer timer1 = new ();


        public Form1()
        {
            InitializeComponent();

            tankBlue = new Tank(50, 50, new SolidBrush(Color.Blue), new Barrel());
            tankRed = new Tank(1090, 50, new SolidBrush(Color.Red), new Barrel());

            elements = [
                tankBlue,
                tankRed,

                new Barrier(-10, -10, 10, 900),
                new Barrier(-10, -10, 1200, 10),
                new Barrier(1182, -10, 10, 900),
                new Barrier(-10, 850, 1210, 10),

                new Barrier(290,0,10,300),
                new Barrier(890,0,10,300),
                new Barrier(590,300,10,300),
                new Barrier(290,600,10,300),
                new Barrier(890,600,10,300)
            ]; 

            this.DoubleBuffered = true;

            timer1.Interval = 1;
            timer1.Tick += timer1Tick;
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element element in elements)
            {
                element.Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    tankBlue.SetDirection(EnDirection.Up);
                    tankBlue.IsStart = true;
                    break;
                case Keys.S:
                    tankBlue.SetDirection(EnDirection.Down);
                    tankBlue.IsStart = true;
                    break;
                case Keys.A:
                    tankBlue.SetDirection(EnDirection.Left);
                    tankBlue.IsStart = true;
                    break;
                case Keys.D:
                    tankBlue.SetDirection(EnDirection.Right);
                    tankBlue.IsStart = true;
                    break;
                case Keys.E:
                    tankBlue.IsStart = false;
                    break;
                case Keys.Space:
                    elements.Add(tankBlue.Shot());
                    break; 



                case Keys.Up:
                    tankRed.SetDirection(EnDirection.Up);
                    tankRed.IsStart = true;
                    break;
                case Keys.Down:
                    tankRed.SetDirection(EnDirection.Down);
                    tankRed.IsStart = true;
                    break;
                case Keys.Left:
                    tankRed.SetDirection(EnDirection.Left);
                    tankRed.IsStart = true;
                    break;
                case Keys.Right:
                    tankRed.SetDirection(EnDirection.Right);
                    tankRed.IsStart = true;
                    break;
                case Keys.OemPeriod:
                    tankRed.IsStart = false;
                    break;
                case Keys.OemQuestion:
                    elements.Add(tankRed.Shot());
                    break;
            }

        }




        public void RemoveToList()
        {
            foreach (var element in removeList)
                elements.Remove(element);
            
            removeList.Clear();
        }

        public void timer1Tick(object sender, EventArgs e)
        {
            foreach (Element element in elements)
            {
                element.Intersection(elements, removeList);
                element.Move();

                if (element.Die())
                {
                    timer1.Stop();
                    lblDie.Text = $"{element.Colorr} tank lose";
                    lblDie.Visible = true;
                }

                if (element.Intersection(elements))
                {
                    timer1.Stop();
                    lblDie.Text = "Drawn";
                    lblDie.Visible = true;
                }
            }


            RemoveToList();

            lblBlueHP.Text = $"{tankBlue.HP} hp";

            lblRebHP.Text = $"{tankRed.HP} hp";

            this.Invalidate();
        }
    }
}
