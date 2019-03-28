using System;
using Rhino.Geometry;

namespace Depict.Core
{
    public static class Depict
    {
        public static Curve GetTestGeometry()
        {
            return new LineCurve(Point3d.Origin, new Point3d(1, 1, 1)).ToNurbsCurve();
        }
    }
}
