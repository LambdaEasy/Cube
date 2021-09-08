using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubes.Domain
{
    /// <summary>
    /// Domain Edge 
    /// </summary>
    public class Edge
    {
        #region Properties
        public double start { get; set; }
        public double end { get; set; }
        #endregion

        #region Ctor
        public Edge(double center, double length)
        {
            start = center - length / 2.0;
            end = center + length / 2.0;
        }

        #endregion


        #region Methods
        public double Overlap(Edge edge) =>
           Math.Max(0, Difference(edge));

        public bool Collides(Edge edge) =>
            Difference(edge) >= 0;

        private double Difference(Edge edge) =>
            Math.Min(end, edge.end) - Math.Max(start, edge.start);

        #endregion
    }

}
