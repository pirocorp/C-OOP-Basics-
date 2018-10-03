namespace Prototype
{
    using System.Collections.Generic;

    /// <summary>
    /// Prototype manager
    /// </summary>
    internal class ColorManager
    {
        private readonly Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get { return this.colors[key]; }
            set { this.colors.Add(key, value); }
        }
    }
}
