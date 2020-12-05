using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigHub1.Startup))]
namespace GigHub1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
