namespace EnvironmentSystem.Core.Generator
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Models.Objects;
    using Interfaces;

    public class ObjectGenerator : IObjectGenerator<EnvironmentObject>
    {
        private const int OBJECTS_COUNT = 10;
        private const int STATIC_STAR_COUNT = 20;

        private readonly int worldWidth;
        private readonly int worldHeight;
        private readonly Random randomGenerator;

        public ObjectGenerator(int worldWidth, int worldHeight)
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            this.randomGenerator = new Random();
        }

        /// <summary>
        /// Adds objects only once to the passed collection. Should be used once.
        /// </summary>
        /// <param name="objects"></param>
        public IEnumerable<EnvironmentObject> SeedInitialObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            for (var i = 0; i < STATIC_STAR_COUNT; i++)
            {
                var x = this.randomGenerator.Next(0, this.worldWidth);
                var y = this.randomGenerator.Next(0, 20);

                generatedObjects.Add(new Star(x, y));
            }

            generatedObjects.Add(new FallingStar(10, 15, new Point(1, 1)));
            generatedObjects.Add(new Ground(0, 25, 50, 2, '#'));

            return generatedObjects;
        }

        /// <summary>
        /// Adds the next portion of objects to the passed collection. Can be used many times.
        /// </summary>
        /// <param name="objects"></param>
        public IEnumerable<EnvironmentObject> GenerateNextObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            for (var i = 0; i < OBJECTS_COUNT; i++)
            {
                var generateFlag = this.randomGenerator.Next(0, 5);

                if (generateFlag == 1)
                {
                    var x = this.randomGenerator.Next(0, this.worldWidth);
                    var envObject = new Snowflake(x, 1, 1, 1, new Point(0, 1));

                    generatedObjects.Add(envObject);
                }
            }

            return generatedObjects;
        }
    }
}
