using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;

namespace Depict.Core
{
    public class CurveWrapper
    {
        public Curve Curve { get; set; }
        public double Length { get; set; }

        public CurveWrapper()
        {

        }

        public CurveWrapper(Curve crv)
        {
            Curve = crv;
        }

        public int GetSpanCount()
        {
            return Curve.SpanCount;
        }
    }
}
