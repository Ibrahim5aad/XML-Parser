using System;
using System.Collections.Generic;
using OpenGL;

namespace XMLParser
{
    public class Face
    {
        public int Id;
        public List<Edge> Edges;
        public List<PointD> Points = new List<PointD>();
        public List<Vector3> vecs = new List<Vector3>();

        public Face(int id, List<Edge> edges) {
            Edges = edges;
            Id = id;
        }

        public Edge GetEdgeByIndex(int index = 0)
        {
            if (index == 0) { return Edges[0]; };
            if (index == 1) { return Edges[1]; };
            if (index == 2) { return Edges[2]; };
            if (index == 3) { return Edges[3]; };

            return Edges[0];
        }

        public List<PointD> GetPoints()
        {
            foreach (Edge e in Edges)
            {
                foreach (PointD p in e.Points) {

                    
                    if (!this.Points.Contains(p))
                    {
                        
                        this.Points.Add(p);
                        

                    }
            }   }

            return Points;
        }

        public List<Vector3> GetVecs()
        {
            foreach (Edge e in Edges)
            {
                foreach (PointD p in e.Points)
                {
                    Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);

                    if (!this.vecs.Contains(vec))
                    {
                        
                        vecs.Add(vec);

                    }
                }
            }

            return vecs;
        }



        public override string ToString()
        {
            return String.Format("Face Id: {0}\nNo. of Edges: {1}", this.Id, this.Edges.Count);
        }
    }   

}
