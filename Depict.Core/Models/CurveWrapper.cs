using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;

namespace Depict.Core
{
    public class CurveWrapper
    {
        public string Name { get; set; }
        public Curve Curve { get; set; }

        public CurveWrapper()
        {

        }

        public int GetSpanCount()
        {
            return Curve.SpanCount;
        }
    }
}
