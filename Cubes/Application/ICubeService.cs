using Cubes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubes.Application
{
    public interface ICubeService
    {
        public double IntersectionVolumeWith(Cube cubeOne, Cube cubeTwo);
        public bool CollidesWith(Cube cubeOne, Cube cubeTwo);
    }
}
