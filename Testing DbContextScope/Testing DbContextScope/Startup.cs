﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testing_DbContextScope.Startup))]
namespace Testing_DbContextScope
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
