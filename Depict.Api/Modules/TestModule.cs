using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Nancy;
using Nancy.Extensions;
using Depict.Core;
using Newtonsoft.Json;

namespace Depict.Api.Modules
{
    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get("/test", args => GetTestCurve());
            Post("/test", args => TestRhino(Context));
        }

        private static Response GetTestCurve()
        {
            var data = Depict.Core.Depict.GetTestGeometry();

            var res = (Response)JsonConvert.SerializeObject(data);
            res.WithStatusCode(HttpStatusCode.OK);

            return res;
        }

        private static Response TestRhino(NancyContext ctx)
        {
            var data = "";
            using (var reader = new StreamReader(ctx.Request.Body))
            {
                data = reader.ReadToEnd();
            }

            //var body = req.Body;
            //int length = (int)body.Length; // this is a dynamic variable
            //byte[] data = new byte[length];
            //body.Read(data, 0, length);
            //var request = System.Text.Encoding.Default.GetString(data);

            var obj = JsonConvert.DeserializeObject<CurveWrapper>(data);

            //var geo = new CurveWrapper()

            var res = (Response)JsonConvert.SerializeObject(new Dictionary<string, int>() { { "spans", obj.GetSpanCount() } });
            res.WithStatusCode(HttpStatusCode.OK);

            return res;
        }
    }
}
