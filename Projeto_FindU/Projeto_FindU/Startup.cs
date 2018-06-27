using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projeto_FindU.Startup))]
namespace Projeto_FindU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
