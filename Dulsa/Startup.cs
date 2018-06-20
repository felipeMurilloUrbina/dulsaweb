using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dulsa.Startup))]
namespace Dulsa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
