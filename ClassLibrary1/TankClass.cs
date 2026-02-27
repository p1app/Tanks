using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public class Barrier
    {
        public Rectangle Body { get; private set; }
        private SolidBrush _brush = new SolidBrush(Color.Black);

        public Barrier(int x, int y, int width, int height)
        {
            Body = new Rectangle(x, y, width, height);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(_brush, Body);
        }

        public static Barrier[] Dsa(int quantity, params Barrier[] barriers)
        {
            Barrier[] arrBarriers = new Barrier[quantity];
            int count = 0;
            foreach (var item in barriers)
            {
                arrBarriers[count] = item;
                count++;
            }
            return arrBarriers;
        }
    }

    public class Tank
    {
        public Rectangle Body { get; private set; }
        public const int WIDTH = 60;
        public const int HEIGHT = 60;
        private SolidBrush _brush;


        public Tank(int x, int y, SolidBrush brush)
        {
            Body = new Rectangle(x, y, WIDTH, HEIGHT);
            _brush = brush;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(_brush, Body);
        }

        public void Move(EnDirection direction)
        {
            int x = Body.X;
            int y = Body.Y;

            switch (direction)
            {
                case EnDirection.Up:
                    y -= 10;
                    break;
                case EnDirection.Down:
                    y += 10;
                    break;
                case EnDirection.Left:
                    x -= 10;
                    break;
                case EnDirection.Right:
                    x += 10;
                    break;
            }

            Body = new Rectangle(x, y, WIDTH, HEIGHT);
        }

        public void IintersectionBar(Barrier[] barriers)
        {
            foreach (Barrier bar in barriers)
            {
                if (Body.IntersectsWith(bar.Body))
                {
                    Application.Exit();
                }
            }
        }

        public enum EnDirection
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
