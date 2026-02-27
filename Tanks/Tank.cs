using System;
using System.Collections.Generic;
using System.Text;

namespace Tanks
{
    public class Tank : Element
    {
        public const int CELL_SIZE = 10;

        private int MoveSpeed = 3;

        public override Rectangle Body { get; set; }
        private int _width = 40;
        private int _height = 50;
        private SolidBrush _brush;

        private EnDirection direction;

        public int HP{ get; private set; }

        public Barrel barrel;

        int barlWidth = 5;
        int barlHeight = 20;

        public List<Bullet> bullets = [];

        public Tank(int x, int y, SolidBrush brush, Barrel barrel)
        {
            Body = new Rectangle(x, y, _width, _height);
            _brush = brush;

            this.barrel = barrel;
            barrel.BarrelBody = new Rectangle((x + _width / 2) - barlWidth / 2, y + _height, barlWidth, barlHeight);

            HP = 100;
        }

        public void SetDirection(EnDirection enDirection)
        {
            direction = enDirection;
        }

        public void Arm(params Bullet[] bulletPar)
        {
            foreach (var bullet in bulletPar)
            {
                bullets.Add(bullet);
            }
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(_brush, Body);
            g.FillRectangle(_brush, barrel.BarrelBody);
        }

        public override void Intersection(List<Element> elements)
        {
            foreach (Barrier bar in elements.OfType<Barrier>())
                if (Body.IntersectsWith(bar.Body) || barrel.BarrelBody.IntersectsWith(bar.Body))
                    HP -= 100;
        }

        public bool Die()
        {
            if(HP == 0)
                return true;

            return false;
        }

        public override bool IntersectionBullet(List<Element> elements)
        {
            foreach (Bullet bullet in elements.OfType<Bullet>())
                if (Body.IntersectsWith(bullet.Body))
                {
                    HP -= 10;
                    return true;
                }


            return false;
        }

        public override void Move()
        {
            int x = Body.X;
            int y = Body.Y;


            switch (direction)
            {
                case EnDirection.Up:
                    _width = 40;
                    _height = 50;
                    y -= MoveSpeed;
                    break;
                case EnDirection.Down:
                    _width = 40;
                    _height = 50;
                    y += MoveSpeed;
                    break;
                case EnDirection.Left:
                    _width = 50;
                    _height = 40;
                    x -= MoveSpeed;
                    break;
                case EnDirection.Right:
                    _width = 50;
                    _height = 40;
                    x += MoveSpeed;
                    break;
            }
            Body = new Rectangle(x, y, _width, _height);
            ChangeBarrel();


        }

        public void ChangeBarrel()
        {

            int barlY = barrel.BarrelBody.Y;
            int barlX = barrel.BarrelBody.X;

            switch (direction)
            {
                case EnDirection.Up:
                    barlWidth = 5;
                    barlHeight = 20;
                    barlY = Body.Y + MoveSpeed - barlHeight;
                    barlX = (Body.X + _width / 2) - barlWidth / 2;
                    barlY -= MoveSpeed;
                    break;
                case EnDirection.Down:
                    barlWidth = 5;
                    barlHeight = 20;
                    barlX = (Body.X + _width / 2) - barlWidth / 2;
                    barlY = Body.Y - MoveSpeed + _height;
                    barlY += MoveSpeed;
                    break;
                case EnDirection.Left:
                    barlWidth = 20;
                    barlHeight = 5;
                    barlY = (Body.Y + _height / 2) - barlHeight / 2;
                    barlX = Body.X + MoveSpeed - barlWidth;
                    barlX -= MoveSpeed;
                    break;
                case EnDirection.Right:
                    barlWidth = 20;
                    barlHeight = 5;
                    barlY = (Body.Y + _height / 2) - barlHeight / 2;
                    barlX = Body.X - MoveSpeed + _width;
                    barlX += MoveSpeed;
                    break;
            }
            barrel.BarrelBody = new Rectangle(barlX, barlY, barlWidth, barlHeight);
        }

        public Bullet Shot(EnDirection direction)
        {
            int bulX = 50;
            int bulY = 50;

            switch (direction)
            {
                case EnDirection.Up:
                    bulX = (Body.X + _width / 2) - barlWidth / 2;
                    bulY = Body.Y - barlHeight - 10;
                    break;
                case EnDirection.Down:
                    bulX = (Body.X + _width / 2) - barlWidth / 2;
                    bulY = Body.Y + _height + 25;
                    break;
                case EnDirection.Left:
                    bulX = Body.X - barlWidth - 10;
                    bulY = (Body.Y + _height / 2) - barlHeight / 2;
                    break;
                case EnDirection.Right:
                    bulX = Body.X + _width + 25;
                    bulY = (Body.Y + _height / 2) - barlHeight / 2;
                    break;
            }

            return new Bullet(bulX, bulY, direction);
        }


        public enum EnDirection
        {
            Down,
            Up,
            Left,
            Right
        }
    }
    public class Barrel : Element
    {
        public Rectangle BarrelBody { get; set; }

        public Barrel()
        {

        }
    }
}
