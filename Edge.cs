using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace XMLParser
{
    public class Edge
    {
        public int Id;
        public PointD UV0;
        public PointD UV1;
        public List<PointD> Points = new List<PointD>(); 


        public Edge(int id, PointD uv0, PointD uv1)
        {
            Id = id;
            UV0 = uv0;
            UV1 = uv1;

            Points.Add(uv0);
            Points.Add(uv1);
        }
    }
}