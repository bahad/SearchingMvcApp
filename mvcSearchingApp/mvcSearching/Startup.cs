using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcSearching.Startup))]
namespace mvcSearching
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
