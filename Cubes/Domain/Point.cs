using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubes.Domain
{
    public class Point
    {
        #region Properties
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        #endregion


        #region Ctor
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

    }
}
