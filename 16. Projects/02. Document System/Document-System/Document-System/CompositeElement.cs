﻿namespace Document_System
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class CompositeElement : Element
    {
        public CompositeElement()
        {
            this.ChildElements = new List<Element>();
        }

        public CompositeElement(params Element[] elements)
            :this()
        {
            this.Add(elements);
        }

        private IList<Element> ChildElements { get; set; }

        public void Add(params Element[] elements)
        {
            foreach (var element in elements)
            {
                this.ChildElements.Add(element);
            }
        }

        public override void RenderHtml(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderHtml(writer);
            }
        }

        public override void RenderText(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderText(writer);
            }
        }
    }
}