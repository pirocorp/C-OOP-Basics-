namespace EnvironmentSystem.Interfaces
{
    using System.Collections.Generic;

    using Models.Objects;

    interface IObjectProducer
    {
        IEnumerable<EnvironmentObject> ProduceObjects();
    }
}
