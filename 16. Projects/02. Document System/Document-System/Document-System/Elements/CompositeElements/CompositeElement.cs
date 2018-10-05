namespace Document_System.Elements.CompositeElements
{
    using System.Collections.Generic;
    using System.IO;
    using Enums;

    public abstract class CompositeElement : Element
    {
        protected CompositeElement()
        {
            this.ChildElements = new List<Element>();
        }

        protected CompositeElement(params Element[] elements)
            :this()
        {
            this.Add(elements);
        }

        public IList<Element> ChildElements { get; set; }

        public void Add(params Element[] elements)
        {
            foreach (var element in elements)
            {
                this.ChildElements.Add(element);
            }
        }

        public override void Render(TextWriter writer, RenderTypes renderTypes)
        {
            foreach (var element in this.ChildElements)
            {
                element.Render(writer, renderTypes);
            }
        }
    }
}