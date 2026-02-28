using System;
using System.Collections.Generic;
using System.Text;

namespace Tanks
{
    public class Tank : Element
    {
        //public 
        public override Rectangle Body { get; set; }
        public int HP { get; private set; }

        //private
        private int _width = WIDTH;
        private int _height = HEIGHT;

        private const int HEIGHT = 50;
        private const int WIDTH = 40;

        private SolidBrush _brush;

        private EnDirection _direction;

        private int _moveSpeed = 1;

        
        //Barrel
        public Barrel barrel;
        private int barlWidth = 5;
        private int barlHeight = 20;

        //Bullet
        public List<Bullet> bullets = [];

        public Tank(int x, int y, SolidBrush brush, Barrel barrel)
        {
            Body = new Rectangle(x, y, _width, _height);
            _brush = brush;
            HP = 100;

            this.barrel = barrel;
            barrel.BarrelBody = new Rectangle((x + _width / 2) - barlWidth / 2, y + _height, barlWidth, barlHeight);

        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(_brush, Body);
            g.FillRectangle(_brush, barrel.BarrelBody);
        }
        
        public void SetDirection(EnDirection enDirection)
        {
            _direction = enDirection;
        }
       
        public override void Move()
        {
            int x = Body.X;
            int y = Body.Y;


            switch (_direction)
            {
                case EnDirection.Up:
                    _width = WIDTH;
                    _height = HEIGHT;
                    y -= _moveSpeed;
                    break;
                case EnDirection.Down:
                    _width = WIDTH;
                    _height = HEIGHT;
                    y += _moveSpeed;
                    break;
                case EnDirection.Left:
                    _width = HEIGHT;
                    _height = WIDTH;
                    x -= _moveSpeed;
                    break;
                case EnDirection.Right:
                    _width = HEIGHT;
                    _height = WIDTH;
                    x += _moveSpeed;
                    break;
            }
            Body = new Rectangle(x, y, _width, _height);
            ChangeBarrel();


        }
        public void ChangeBarrel()
        {

            int barlY = barrel.BarrelBody.Y;
            int barlX = barrel.BarrelBody.X;

            switch (_direction)
            {
                case EnDirection.Up:
                    barlWidth = 5;
                    barlHeight = 20;
                    barlY = Body.Y + _moveSpeed - barlHeight;
                    barlX = (Body.X + _width / 2) - barlWidth / 2;
                    barlY -= _moveSpeed;
                    break;
                case EnDirection.Down:
                    barlWidth = 5;
                    barlHeight = 20;
                    barlX = (Body.X + _width / 2) - barlWidth / 2;
                    barlY = Body.Y - _moveSpeed + _height;
                    barlY += _moveSpeed;
                    break;
                case EnDirection.Left:
                    barlWidth = 20;
                    barlHeight = 5;
                    barlY = (Body.Y + _height / 2) - barlHeight / 2;
                    barlX = Body.X + _moveSpeed - barlWidth;
                    barlX -= _moveSpeed;
                    break;
                case EnDirection.Right:
                    barlWidth = 20;
                    barlHeight = 5;
                    barlY = (Body.Y + _height / 2) - barlHeight / 2;
                    barlX = Body.X - _moveSpeed + _width;
                    barlX += _moveSpeed;
                    break;
            }
            barrel.BarrelBody = new Rectangle(barlX, barlY, barlWidth, barlHeight);
        }
        
        public void Arm(params Bullet[] bulletPar)
        {
            foreach (var bullet in bulletPar)
            {
                bullets.Add(bullet);
            }
        }
        public Bullet Shot(EnDirection direction)
        {
            int bulX = 0;
            int bulY = 0;

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

        public override void Intersection(List<Element> elements)
        {
            foreach (Barrier bar in elements.OfType<Barrier>())
                if (Body.IntersectsWith(bar.Body) || barrel.BarrelBody.IntersectsWith(bar.Body))
                    HP -= 100;


        }

        //public override bool IntersectionTank(List<Element> elements)
        //{
        //    foreach (Tank tank in elements.OfType<Tank>())
        //        if (Body.IntersectsWith(tank.Body))
        //            return true;
        //    return false;
        //}
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

        public bool Die()
        {
            if (HP <= 0)
                return true;

            return false;
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
