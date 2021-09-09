using Cubes.Application;
using Cubes.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace UnitTesting
{
    public class Tests
    {
        private ICubeService _cubeService;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection().AddLogging();
            var builder = new ConfigurationBuilder();

            // test against this configuration
            IConfiguration config = new ConfigurationBuilder()
              // how to populate it via code
              .Build();


            services.AddSingleton<IConfiguration>(config);
            services.AddTransient<ICubeService, CubeService>();
            var serviceProvider = services.BuildServiceProvider();

            _cubeService = serviceProvider.GetService<ICubeService>();
        }

        [Test]
        public void cubes_that_do_not_touch()
        {
            var cubeA = new Cube(new Point(2, 2, 2), 2);

            var cubeB = new Cube(new Point(10, 10, 10), 10);

            Assert.IsFalse(_cubeService.CollidesWith(cubeA, cubeB));
        }

        [Test]
        public void cubes_that_overlap()
        {
            var cubeA = new Cube(new Point(2, 2, 2), 2);

            var cubeB = new Cube(new Point(4, 10, 10), 2);

            
            Assert.IsTrue(_cubeService.CollidesWith(cubeA, cubeB));
        }

        [Test]
        public void cubes_that_touch()
        {
            var cubeA = new Cube(new Point(2, 2, 2), 2);

            var cubeB = new Cube(new Point(4, 2, 2), 2);


            Assert.IsTrue(_cubeService.CollidesWith(cubeA, cubeB));
        }
    }
}