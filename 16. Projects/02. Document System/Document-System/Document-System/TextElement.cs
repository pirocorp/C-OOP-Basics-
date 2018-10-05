﻿namespace Document_System
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Web;

    public class TextElement : Element
    {
        public TextElement(string text, Font font = null)
        {
            this.Text = text;
            this.Font = font;
        }

        public string Text { get; set; }

        public Font Font { get; set; }

        public override void RenderHtml(TextWriter writer)
        {
            if (this.Font != null)
            {
                writer.Write("<span style=\"");
                this.Font.RenderHtml(writer);
                writer.Write("\">");
            }

            writer.Write(this.Text.HtmlEncode());

            if (this.Font != null)
            {
                writer.Write("</span>");
            }
        }

        public override void RenderText(TextWriter writer)
        {
            writer.Write(this.Text);
        }
    }
}