namespace Tanks
{
    public class Bullet : Element
    {
        private int _x;
        private int _y;

        private int _width = _WIDTH;
        private int _height = _HEIGHT;
        private const int _WIDTH = 5;
        private const int _HEIGHT = 10;

        private SolidBrush _brush = new (Color.Black);

        private EnDirection _direction;
        
        private const int _MOVE_SPEED = 20;

        public Bullet(int x, int y, EnDirection direction)
        {
            _x = x;
            _y = y;

            Body = new Rectangle(_x, _y, _width, _height);
            _direction = direction;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(_brush, _x, _y, _width, _height);
        }

        public override void Intersection(List<Element> elements, List<Element> removeElement)
        {
            foreach (Element element in elements)
            {
                if (element == this)
                    continue;

                if (Body.IntersectsWith(element.Body))
                    removeElement.Add(this);
            }
        }


        public override void Move()
        {
            switch (_direction)
            {
                case EnDirection.Up:
                _width = _WIDTH;
                _height = _HEIGHT;
                _y -= _MOVE_SPEED;
                    break;
                case EnDirection.Down:
                    _width = _WIDTH;
                    _height = _HEIGHT;
                    _y += _MOVE_SPEED;
                    break;
                case EnDirection.Left:
                    _width = _HEIGHT;
                    _height = _WIDTH;
                    _x -= _MOVE_SPEED;
                    break;
                case EnDirection.Right:
                    _width = _HEIGHT;
                    _height = _WIDTH;
                    _x += _MOVE_SPEED;
                    break;
            }
            Body = new Rectangle(_x, _y, _width, _height);
        }
    }
}
