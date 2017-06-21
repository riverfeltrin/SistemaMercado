using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaMercado.Startup))]
namespace SistemaMercado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
