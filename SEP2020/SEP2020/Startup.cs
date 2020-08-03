using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(SEP2020.Startup))]
namespace SEP2020
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
