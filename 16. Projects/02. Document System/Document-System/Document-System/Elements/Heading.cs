namespace Document_System.Elements
{
    using System;
    using System.IO;
    using Enums;
    using RendersFactories;
    using Utils;

    public class Heading : Element
    {
        private int headingSize;

        public Heading(string text, int headingSize = 1)
        {
            this.HeadingSize = headingSize;
            this.Text = text;
        }

        public int HeadingSize
        {
            get => this.headingSize;
            private set
            {
                if (value < 1 || value > 6)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.HeadingSize), "The hading size should be [1...6].");
                }

                this.headingSize = value;
            }
        }

        public string Text { get; private set; }

        public override void Render(TextWriter writer, RenderTypes renderTypes)
        {
            var renderer = RenderFactory.Create(renderTypes, ElementTypes.Heading, this);
            renderer.Render(writer);
        }
    }
}