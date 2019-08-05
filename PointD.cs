using System;
using System.Collections.Generic;
using System.Drawing;

using OpenTK;

namespace XMLParser
{
    public class PointD
    {
        public double X;
        public double Y;
        public double Z;

        public PointD(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", X, Y, Z);
        }

       

        public override bool Equals(object obj)
        {
            return obj is PointD && this == (PointD)obj;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        public static bool operator ==(PointD a, PointD b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(PointD a, PointD b)
        {
            return !(a == b);
        }
    }
}
