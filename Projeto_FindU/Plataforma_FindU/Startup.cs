using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plataforma_FindU.Startup))]
namespace Plataforma_FindU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
