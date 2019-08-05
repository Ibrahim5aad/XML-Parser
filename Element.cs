using System;
using System.Collections.Generic;
using OpenTK;
using OpenGL;

namespace XMLParser
{
    public class Element
    {
        private Transform transform;
        public int Id;
        public int facesNo;
        public List<Face> Faces;
        
        public Element(int id, List<Face> faces)
        {
            Faces = faces;
            facesNo = faces.Count;
            Id = id;
        }

        public Element(int id, List<Face> faces, Transform trans)
        {
            Faces = faces;
            facesNo = faces.Count;
            Id = id;
            transform = trans;
        }

        public Transform Transform
        {
            get
            {
                return transform;
            }
            set
            {
                transform = value;
            }
        }

        public Face GetFaceByIndex(int index = 0)
        {
            if (index == 0) { return Faces[0]; };
            if (index == 1) { return Faces[1]; };
            if (index == 2) { return Faces[2]; };
            if (index == 3) { return Faces[3]; };

            return Faces[0];
        }

        public List<OpenGL.Vector3> Vertices()
        {   
            List<OpenGL.Vector3> vertices = new List<OpenGL.Vector3>();

            foreach (Face f in Faces)
            {
                foreach(PointD p in f.GetPoints())
                {
                    var vec = new OpenGL.Vector3((float)p.X, (float)p.Y, (float)p.Z);
                    if (!vertices.Contains(vec))
                    {
                        vertices.Add(vec);
                    }
                }
            }
               
            return vertices;
        }   
    }
}
