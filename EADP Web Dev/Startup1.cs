using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EADP_Web_Dev.Code;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EADP_Web_Dev.Startup1))]

namespace EADP_Web_Dev
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            /*ConfigureAuth(app);*/
            app.MapSignalR();
        }
    }
}


