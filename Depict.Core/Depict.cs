using System;
using Rhino.Geometry;

namespace Depict.Core
{
    public static class Depict
    {
        public static Curve GetTestGeometry()
        {
            return new LineCurve(new Point3d(0, 0, 0), new Point3d(1, 1, 1)).ToNurbsCurve();
        }
    }
}
