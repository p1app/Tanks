using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static Tanks.Tank;

namespace Tanks
{
    public class Bullet : Element
    {
        public Rectangle Body { get; set; }
        public int x;
        public int y;
        private const int WIDTH = 5;
        private const int HEIGHT = 5;
        private SolidBrush bulletbrush = new SolidBrush(Color.Black);
        EnDirection direction = EnDirection.Down;

        int MoveSpeed = 7;

        public Bullet(int x, int y, EnDirection direction)
        {
            this.x = x;
            this.y = y;

            Body = new Rectangle(this.x, this.y, WIDTH, HEIGHT);
            this.direction = direction;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(bulletbrush, x, y, WIDTH, HEIGHT);
        }

        public override void Intersection(List<Element> elements, List<Element> removeElement)
        {
            foreach (Barrier barrier in elements.OfType<Barrier>())
                if (Body.IntersectsWith(barrier.Body))
                    switch (direction)
                    {
                        case EnDirection.Down:
                            direction = EnDirection.Up;
                            break;
                        case EnDirection.Up:
                            direction = EnDirection.Down;
                            break;
                        case EnDirection.Left:
                            direction = EnDirection.Right;
                            break;
                        case EnDirection.Right:
                            direction = EnDirection.Left;
                            break;
                        default:
                            break;
                    }

            IsRemove = true;
        }


        public override void Move()
        {
            switch (direction)
            {
                case EnDirection.Up:
                    y -= MoveSpeed;
                    break;
                case EnDirection.Down:
                    y += MoveSpeed;
                    break;
                case EnDirection.Left:
                    x -= MoveSpeed;
                    break;
                case EnDirection.Right:
                    x += MoveSpeed;
                    break;
            }
            Body = new Rectangle(x, y, WIDTH, HEIGHT);
        }
    }
}
