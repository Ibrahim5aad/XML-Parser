using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using static OpenGL.Matrix4;

namespace XMLParser
{
    public class Transform
    {
        
        public PointD Position;
        public Matrix4 translation;
        public Matrix4 scaling;
        

        public Transform(Matrix4 tra, Matrix4 rot)
        {
            translation = tra;
            scaling = rot;
            Position = new PointD(tra[0, 3], tra[1, 3], tra[2, 3]);

        }

        public override string ToString()
        {
            return String.Format("|{0},  {1},  {2},  {3}|\n|{4},  {5},  {6},  {7}|\n|{8},  {9},  {10},  {11}|", translation[0, 0], translation[0, 1], translation[0, 2], translation[0, 3], translation[1, 0], translation[1, 1], translation[1, 2], translation[1, 3], translation[2, 0], translation[2, 1], translation[2, 2], translation[2, 3]);
        }

        public string GetPosition()
        {
            return String.Format("X = {0}, Y = {1}, Z = {2}", Position.X, Position.Y, Position.Z);
        }

        public OpenGL.Matrix4 glTranslation
        {

            get { return OpenGL.Matrix4.CreateTranslation(new OpenGL.Vector3(translation[0, 3], translation[1, 3], translation[2, 3]));  }
            set { }
    
        }

        public OpenGL.Matrix4 glScaling
        {
            get { return OpenGL.Matrix4.CreateScaling(new OpenGL.Vector3(translation[0, 0], translation[1, 1], translation[2, 2])); }
            set { }
        }

    }
}
