namespace Tanks
{
    public class Barrier : Element
    {
        private SolidBrush _brush = new SolidBrush(Color.Black);

        public Barrier(int x, int y, int width, int height)
        {
            Body = new Rectangle(x, y, width, height);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(_brush, Body);
        }
    }
}
