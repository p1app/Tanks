namespace Tanks
{
    public abstract class Element
    {
        public Rectangle Body { get; set; }
        public bool IsStart { get; set; }
        public string? Colorr { get; set; }
        public virtual void Draw(Graphics g) { }
        public virtual bool Die() { return false; }
        public virtual void Move() { }
        public virtual bool Intersection(List<Element> elements) { return false; }
        public virtual void Intersection(List<Element> elements, List<Element> removeElement) { }
    }
}
