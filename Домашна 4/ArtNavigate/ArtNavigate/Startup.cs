using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtNavigate.Startup))]
namespace ArtNavigate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
