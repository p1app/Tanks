namespace Tanks
{
    public class Tank : Element
    {
        //private
        private int _width = WIDTH;
        private int _height = HEIGHT;
        
        private const int HEIGHT = 60;
        private const int WIDTH = 40;

        //private readonly SolidBrush _brush;

        private EnDirection _direction;

        private const int _MOVE_SPEED = 2;
        
        //sprite
        private Bitmap _spriteBody = new(@"image\makhachev.png");
        private Bitmap _spriteBarrel = new(@"image\ark.png");
        
        //prop 
        public int HP { get; private set; }

        
        //Barrel
        public Barrel barrel;
        private int _barlWidth = 6;
        private int _barlHeight = 20;

        public Tank(int x, int y, SolidBrush brush, Barrel barrel)
        {
            Body = new Rectangle(x, y, _width, _height);
            //_brush = brush;
            HP = 100;
            Colorr = brush.Color.Name;

            this.barrel = barrel;
            barrel.BarrelBody = new Rectangle((x + _width / 2) - _barlWidth / 2, y + _height, _barlWidth, _barlHeight);

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_spriteBody, Body);
            g.DrawImage(_spriteBarrel, barrel.BarrelBody);
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
                        y -= _MOVE_SPEED;
                        break;
                    case EnDirection.Down:
                        _width = WIDTH;
                        _height = HEIGHT;
                        y += _MOVE_SPEED;
                        break;
                    case EnDirection.Left:
                        _width = HEIGHT;
                        _height = WIDTH;
                        x -= _MOVE_SPEED;
                        break;
                    case EnDirection.Right:
                        _width = HEIGHT;
                        _height = WIDTH;
                        x += _MOVE_SPEED;
                        break;
                }
                Body = new Rectangle(x, y, _width, _height);
                ChangeBarrel();
            }
        }
        private void ChangeBarrel()
        {

            int barlY = barrel.BarrelBody.Y;
            int barlX = barrel.BarrelBody.X;

            switch (_direction)
            {
                case EnDirection.Up:
                    _barlWidth = 5;
                    _barlHeight = 20;
                    barlY = Body.Y + _MOVE_SPEED - _barlHeight;
                    barlX = (Body.X + _width / 2) - _barlWidth / 2;
                    barlY -= _MOVE_SPEED;
                    break;
                case EnDirection.Down:
                    _barlWidth = 5;
                    _barlHeight = 20;
                    barlX = (Body.X + _width / 2) - _barlWidth / 2;
                    barlY = Body.Y - _MOVE_SPEED + _height;
                    barlY += _MOVE_SPEED;
                    break;
                case EnDirection.Left:
                    _barlWidth = 20;
                    _barlHeight = 5;
                    barlY = (Body.Y + _height / 2) - _barlHeight / 2;
                    barlX = Body.X + _MOVE_SPEED - _barlWidth;
                    barlX -= _MOVE_SPEED;
                    break;
                case EnDirection.Right:
                    _barlWidth = 20;
                    _barlHeight = 5;
                    barlY = (Body.Y + _height / 2) - _barlHeight / 2;
                    barlX = Body.X - _MOVE_SPEED + _width;
                    barlX += _MOVE_SPEED;
                    break;
            }
            barrel.BarrelBody = new Rectangle(barlX, barlY, _barlWidth, _barlHeight);
        }

        public Bullet Shot()
        {
            int bulX = 0;
            int bulY = 0;

            switch (_direction)
            {
                case EnDirection.Up:
                    bulX = (Body.X + _width / 2) - _barlWidth / 2;
                    bulY = Body.Y - _barlHeight - 15;
                    break;
                case EnDirection.Down:
                    bulX = (Body.X + _width / 2) - _barlWidth / 2;
                    bulY = Body.Y + _height + 25;
                    break;
                case EnDirection.Left:
                    bulX = Body.X - _barlWidth - 10;
                    bulY = (Body.Y + _height / 2) - _barlHeight / 2;
                    break;
                case EnDirection.Right:
                    bulX = Body.X + _width + 25;
                    bulY = (Body.Y + _height / 2) - _barlHeight / 2;
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
