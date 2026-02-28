using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static Tanks.Tank;


//подбитие в пушку

namespace Tanks
{


    public partial class Form1 : Form
    {
        private Tank tankBlue;
        private Tank tankRed;

        public List<Element> elements;
        public List<Element> removeList = new();

        public const int CELL_SIZE = 10;


        public bool isStart1 = false;
        public bool isStart2 = false;


        private static EnDirection tankBlueDir;
        private static EnDirection tankBluelastDir;

        private static EnDirection tankRedDir;
        private static EnDirection tankRedlastDir;


        System.Windows.Forms.Timer timer1 = new ();


        public Form1()
        {
            InitializeComponent();

            tankBlue = new Tank(50, 50, new SolidBrush(Color.Blue), new Barrel());
            tankRed = new Tank(700, 450, new SolidBrush(Color.Red), new Barrel());

            elements = new List<Element>(); 
            elements.Add(tankBlue);
            elements.Add(tankRed);
            elements.Add(new Barrier(200, 0, 10, 150));
            elements.Add(new Barrier(200, 150, 300, 10));
            elements.Add(new Barrier(500, 450, 10, 150));
            elements.Add(new Barrier(200, 450, 300, 10));
            elements.Add(new Barrier(0, 300, 300, 10));
            elements.Add(new Barrier(500, 300, 300, 10));

            elements.Add(new Barrier(-10, -10, 10, 600));
            elements.Add(new Barrier(-10, -10, 800, 10));
            elements.Add(new Barrier(800, -10, 10, 800));
            elements.Add(new Barrier(0, 550, 810, 10));
            

            this.DoubleBuffered = true;

            timer1.Interval = 3;
            timer1.Tick += timer1Tick;
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element item in elements)
            {
                item.Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (tankBlueDir != EnDirection.Down)
                    {
                        tankBlueDir = EnDirection.Up;
                        tankBlue.SetDirection(tankBlueDir);
                        isStart1 = true;
                    }
                    break;
                case Keys.S:
                    if (tankBlueDir != EnDirection.Up)
                    {
                        tankBlueDir = EnDirection.Down;
                        tankBlue.SetDirection(tankBlueDir);
                        isStart1 = true;
                    }
                    break;
                case Keys.A:
                    if (tankBlueDir != EnDirection.Right)
                    {
                        tankBlueDir = EnDirection.Left;
                        tankBlue.SetDirection(tankBlueDir);
                        isStart1 = true;
                    }
                    break;
                case Keys.D:
                    if (tankBlueDir != EnDirection.Left)
                    {
                        tankBlueDir = EnDirection.Right;
                        tankBlue.SetDirection(tankBlueDir);
                        isStart1 = true;
                    }
                    break;
                case Keys.E:
                    isStart1 = false;
                    break;
                case Keys.Space:
                    tankBluelastDir = tankBlueDir;
                    elements.Add(tankBlue.Shot(tankBluelastDir));
                    break;



                case Keys.Up:
                    if (tankRedDir != EnDirection.Down)
                    {
                        tankRedDir = EnDirection.Up;
                        tankRed.SetDirection(tankRedDir);
                        isStart2 = true;
                    }
                    break;
                case Keys.Down:
                    if (tankRedDir != EnDirection.Up)
                    {
                        tankRedDir = EnDirection.Down;
                        tankRed.SetDirection(tankRedDir);
                        isStart2 = true;
                    }
                    break;
                case Keys.Left:
                    if (tankRedDir != EnDirection.Right)
                    {
                        tankRedDir = EnDirection.Left;
                        tankRed.SetDirection(tankRedDir);
                        isStart2 = true;
                    }
                    break;
                case Keys.Right:
                    if (tankRedDir != EnDirection.Left)
                    {
                        tankRedDir = EnDirection.Right;
                        tankRed.SetDirection(tankRedDir);
                        isStart2 = true;
                    }
                    break;
                case Keys.OemPeriod:
                    isStart2 = false;
                    break;
                case Keys.OemQuestion:
                    tankRedlastDir = tankRedDir;
                    elements.Add(tankRed.Shot(tankRedlastDir));
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
            foreach (Element element in elements.OfType<Tank>())
            {
                element.Intersection(elements);
                element.IntersectionBullet(elements);

                if (isStart1)
                    tankBlue.Move();

                if (isStart2)
                    tankRed.Move();

                if (tankRed.Die())
                {
                    timer1.Stop();
                    lblDie.Text = "Синий танк победил";
                    lblDie.Visible = true;
                }
                if (tankBlue.Die())
                {
                    timer1.Stop();
                    lblDie.Text = "Красный танк победил";
                    lblDie.Visible = true;
                }

                if (tankBlue.Body.IntersectsWith(tankRed.Body))
                {
                    timer1.Stop();
                    lblDie.Text = "Ничья";
                    lblDie.Visible = true;
                }
            }


            RemoveToList();
            foreach (Element element in elements.OfType<Bullet>())
            {
                element.Move();
                elements.RemoveAll(x => x.IsRemove);
                //element.Intersection(elements, removeList);
            }

            lblBlueHP.Text = $"{tankBlue.HP} hp";

            lblRebHP.Text = $"{tankRed.HP} hp";

            this.Invalidate();
        }
    }
}
