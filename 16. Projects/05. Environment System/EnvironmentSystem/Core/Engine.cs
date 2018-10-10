namespace EnvironmentSystem.Core
{
    using System.Collections.Generic;
    using System.Threading;

    using Models.DataStructures;
    using Interfaces;
    using Models.Objects;

    public class Engine
    {
        protected const int LoopIntervalInMilliseconds = 200;

        protected readonly Rectangle WorldBounds;
        protected readonly List<EnvironmentObject> Objects;
        protected readonly IRenderer Renderer;
        protected readonly IObjectGenerator<EnvironmentObject> ObjectGenerator;
        protected readonly ICollisionHandler CollisionHandler;

        public Engine(int worldWidth, 
            int worldHeight, 
            IObjectGenerator<EnvironmentObject> objectGenerator,
            ICollisionHandler collisionHandler, 
            IRenderer renderer)
        {
            this.Objects = new List<EnvironmentObject>();
            this.ObjectGenerator = objectGenerator;

            this.Renderer = renderer;
            this.CollisionHandler = collisionHandler;
            this.WorldBounds = new Rectangle(0, 0, worldWidth, worldHeight);
        }

        public virtual void Run()
        {
            var initialObjects = this.ObjectGenerator.SeedInitialObjects();
            foreach (var initialObject in initialObjects)
            {
                this.Insert(initialObject);
            }

            while (true)
            {
                this.ExecuteEnvironmentLoop();
            }
        }

        protected virtual void ExecuteEnvironmentLoop()
        {
            var dynamicallyGeneratedObjects = this.ObjectGenerator.GenerateNextObjects();
            foreach (var dynamicallyGeneratedObject in dynamicallyGeneratedObjects)
            {
                this.Insert(dynamicallyGeneratedObject);
            }

            foreach (var envObj in this.Objects)
            {
                envObj.Update();
            }

            this.CollisionHandler.HandleCollisions(this.Objects);
            this.ProcessObjectProduction();

            this.Objects.RemoveAll(x => !x.Exists ||
                !Rectangle.Intersects(this.WorldBounds, x.Bounds));

            foreach (var envObject in this.Objects)
            {
                this.Renderer.EnqueueForRendering(envObject);
            }

            this.Renderer.RenderAll();

            Thread.Sleep(LoopIntervalInMilliseconds);

            this.Renderer.ClearQueue();
        }

        protected virtual void Insert(EnvironmentObject obj)
        {
            this.Objects.Add(obj);
        }

        private void ProcessObjectProduction()
        {
            var newObjects = new List<EnvironmentObject>();
            foreach (var envObject in this.Objects)
            {
                var producedObjects = envObject.ProduceObjects();
                newObjects.AddRange(producedObjects);
            }

            foreach (var obj in newObjects)
            {
                this.Insert(obj);
            }
        }
    }
}
