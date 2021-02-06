using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoreAdmChamepe.Startup))]
namespace CoreAdmChamepe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
