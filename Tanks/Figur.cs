using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static Tanks.Tank;

namespace Tanks
{
    public abstract class Element
    {

        public virtual Rectangle Body { get; set; }
        public virtual void Draw(Graphics g) { }
        
        public virtual void Move() { }

        public virtual void Intersection(List<Element> elements) { }
        public virtual bool IntersectionBullet(List<Element> elements) { return false; }
        public virtual void Intersection(List<Element> elements, List<Element> removeElement) { }
        public virtual bool IntersectionTank(List<Element> elements) { return false; }

    }
}
