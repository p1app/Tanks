using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tanks
{
    public class Tank : Element
    {
        //sprite
        private Bitmap spriteBody = new(@"image\makhachev.png");
        private Bitmap spriteBarrel = new(@"image\ark.png");
        //public 
        public override bool IsStart { get; set; }
        public int HP { get; private set; }
        public override string Colorr { get; set; }

        //private
        private int _width = WIDTH;
        private int _height = HEIGHT;

        private const int HEIGHT = 60;
        private const int WIDTH = 40;

        private SolidBrush _brush;

        private EnDirection _direction;

        private int _moveSpeed = 2;

        
        //Barrel
        public Barrel barrel;
        private int barlWidth = 6;
        private int barlHeight = 20;

        public Tank(int x, int y, SolidBrush brush, Barrel barrel)
        {
            Body = new Rectangle(x, y, _width, _height);
            _brush = brush;
            HP = 100;
            Colorr = brush.Color.Name;

            this.barrel = barrel;
            barrel.BarrelBody = new Rectangle((x + _width / 2) - barlWidth / 2, y + _height, barlWidth, barlHeight);

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(spriteBody, Body);
            g.DrawImage(spriteBarrel, barrel.BarrelBody);
        }
        
        public void SetDirection(EnDirection enDirection)
        {
            _direction = enDirection;
        }
       
        public override void Move()
        {
            if (IsStart)
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

        public Bullet Shot()
        {
            int bulX = 0;
            int bulY = 0;

            switch (_direction)
            {
                case EnDirection.Up:
                    bulX = (Body.X + _width / 2) - barlWidth / 2;
                    bulY = Body.Y - barlHeight - 15;
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

            return new Bullet(bulX, bulY, _direction);
        }

        public override bool Intersection(List<Element> elements)
        {
            int x = Body.X;
            int y = Body.Y;
            foreach (Element element in elements)
            {
                if (element.Body == Body)
                    continue;

                if (Body.IntersectsWith(element.Body) || barrel.BarrelBody.IntersectsWith(element.Body))
                {
                    if (element is Barrier)
                    {
                        IsStart = false; 
                    }
                    if (element is Bullet)
                        HP -= 10;
                    if(element is Tank)
                        return true;
                }
            }
            return false;
        }

        public override bool Die()
        {
            if (HP <= 0)
                return true;

            return false;
        }
    }
    public class Barrel
    {
        public Rectangle BarrelBody { get; set; }

        public Barrel()
        {

        }
    }
}
