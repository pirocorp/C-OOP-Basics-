namespace EnvironmentSystem
{
    using Core;
    using Core.Generator;

    public class EnvironmentSystemMain
    {
        private const int WORLD_WIDTH = 50;
        private const int WORLD_HEIGHT = 30;

        public static void Main()
        {
            var objectGenerator = new ObjectGenerator(WORLD_WIDTH, WORLD_HEIGHT);
            var consoleRenderer = new ConsoleRenderer(WORLD_WIDTH, WORLD_HEIGHT);
            var collisionHandler = new CollisionHandler(WORLD_WIDTH, WORLD_HEIGHT);

            var engine = new ExtendedEngine(WORLD_WIDTH, 
                WORLD_HEIGHT, 
                objectGenerator, 
                collisionHandler, 
                consoleRenderer);

            engine.Run();
        }
    }
}
