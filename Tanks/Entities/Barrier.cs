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

        public static Barrier[] ArrayBar(params Barrier[] barriers)
        {
            Barrier[] arrBarriers = new Barrier[barriers.Length];
            int count = 0;
            foreach (var item in barriers)
            {
                arrBarriers[count] = item;
                count++;
            }
            return arrBarriers;
        }
    }

}
