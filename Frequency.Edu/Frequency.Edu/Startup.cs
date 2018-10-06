using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Frequency.Edu.Startup))]
namespace Frequency.Edu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
