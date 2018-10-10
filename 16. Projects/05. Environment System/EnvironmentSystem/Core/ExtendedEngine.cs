namespace EnvironmentSystem.Core
{
    using System;
    using Interfaces;
    using Models.Objects;

    public class ExtendedEngine : Engine
    {
        private readonly IController controller;
        private bool isPaused = false;

        public ExtendedEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, ICollisionHandler collisionHandler, IRenderer renderer, IController controller) 
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
            this.AttachControllerEvents();
        }

        private void AttachControllerEvents()
        {
            this.controller.Pause += this.ControllerPause;
        }

        private void ControllerPause(object sender, EventArgs e)
        {
            this.isPaused = !this.isPaused;
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(this.Insert), "Object cannot be null.");
            }

            base.Insert(obj);
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();

            if (!this.isPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
        }
    }
}