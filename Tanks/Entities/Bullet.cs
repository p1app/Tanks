namespace Tanks
{
    public class Bullet : Element
    {
        public int x;
        public int y;
        public int indexList;
        private int _width = WIDTH;
        private int _height = HEIGHT;
        private const int WIDTH = 5;
        private const int HEIGHT = 10;
        private SolidBrush bulletbrush = new SolidBrush(Color.Black);
        EnDirection direction = EnDirection.Down;

        int MoveSpeed = 20;

        public Bullet(int x, int y, EnDirection direction)
        {
            this.x = x;
            this.y = y;

            Body = new Rectangle(this.x, this.y, _width, _height);
            this.direction = direction;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(bulletbrush, x, y, _width, _height);
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
            switch (direction)
            {
                case EnDirection.Up:
                _width = WIDTH;
                _height = HEIGHT;
                y -= MoveSpeed;
                    break;
                case EnDirection.Down:
                    _width = WIDTH;
                    _height = HEIGHT;
                    y += MoveSpeed;
                    break;
                case EnDirection.Left:
                    _width = HEIGHT;
                    _height = WIDTH;
                    x -= MoveSpeed;
                    break;
                case EnDirection.Right:
                    _width = HEIGHT;
                    _height = WIDTH;
                    x += MoveSpeed;
                    break;
            }
            Body = new Rectangle(x, y, _width, _height);
        }
    }
}
