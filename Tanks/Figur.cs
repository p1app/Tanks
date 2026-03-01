using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static Tanks.Tank;

namespace Tanks
{
    public abstract class Element
    {
        public Rectangle Body { get; set; }
        public virtual bool IsStart { get; set; }
        public virtual string Colorr { get; set; }
        public virtual void Draw(Graphics g) { }
        public virtual bool Die() { return false; }
        public virtual void Move() { }
        public virtual bool Intersection(List<Element> elements) { return false; }
        public virtual void Intersection(List<Element> elements, List<Element> removeElement) { }

    }
}
