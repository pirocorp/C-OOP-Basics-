namespace MassEffect.Interfaces
{
    using System.Collections.Generic;

    using GameObjects.Enhancements;

    public interface IEnhanceable
    {
        IEnumerable<Enhancement> Enhancements { get; }

        void AddEnhancement(Enhancement enhancement);
    }
}
