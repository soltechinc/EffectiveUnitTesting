using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolTech.Demos.UnitTesting.Startup))]
namespace SolTech.Demos.UnitTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
