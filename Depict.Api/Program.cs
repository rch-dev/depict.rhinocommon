using System;
using Nancy;
using Nancy.Hosting.Self;
using Topshelf;

namespace Depict.Api
{
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<NancySelfHost>(s =>
                {
                    s.ConstructUsing(name => new NancySelfHost());

                    s.WhenStarted(tc => { tc.Start(); });
                    s.WhenStopped(tc => { tc.Stop(); });
                });

                x.RunAsLocalSystem();
                //x.OnException(e => MessageBox.Show(e.Message));
                x.SetDescription("Microservice for converting RhinoCommon geometry into SVG drawings.");
                x.SetDisplayName("Depict.Api");
                x.SetServiceName("Depict.Api");
            });
        }
    }

    public class NancySelfHost
    {
        private NancyHost m_nancyHost;

        public void Start()
        {
            //Startup.LaunchInProcess(Startup.LoadMode.Headless, 0);
            //Console.WriteLine("Rhino loaded at port 88.");
            m_nancyHost = new NancyHost(new Uri("http://localhost:1001"));
            m_nancyHost.Start();

        }

        public void Stop()
        {
            //MessageBox.Show("Stopped!");
            m_nancyHost.Stop();
            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
