using Cubes.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubes.Application
{
    public class CubeService : ICubeService
    {
        #region Attribute Private
        private readonly ILogger<CubeService> _log;
        private readonly IConfiguration _config;
        #endregion

        #region Ctor

        public CubeService(ILogger<CubeService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }


        #endregion

        #region Method Run Console
        public void Run()
        {
            try
            {
                var cubeA = new Cube(new Point(2, 2, 2), 2);

                var cubeB = new Cube(new Point(10, 10, 10), 10);


                _log.LogInformation(string.Format("Result: {0}", CollidesWith(cubeA, cubeB)));
                Console.WriteLine(CollidesWith(cubeA, cubeB));


                cubeA = new Cube(new Point(2, 2, 2), 2);

                cubeB = new Cube(new Point(3, 10, 10), 2);

                _log.LogInformation(string.Format("Result: {0}", CollidesWith(cubeA, cubeB)));

                Console.WriteLine(CollidesWith(cubeA, cubeB));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
            }
        }

        #endregion

        #region Methods

        public bool CollidesWith(Cube cubeOne, Cube cubeTwo) =>
             cubeTwo.width.Collides(cubeOne.width)
             || cubeTwo.height.Collides(cubeOne.height)
             || cubeTwo.depth.Collides(cubeOne.depth);

        public double IntersectionVolumeWith(Cube cubeOne, Cube cubeTwo) =>
                   cubeTwo.width.Overlap(cubeOne.width)
                * cubeTwo.height.Overlap(cubeOne.height)
                * cubeTwo.depth.Overlap(cubeOne.depth);

        #endregion

    }


}
