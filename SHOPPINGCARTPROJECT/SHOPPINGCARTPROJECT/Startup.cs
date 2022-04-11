using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SHOPPINGCARTPROJECT.Startup))]
namespace SHOPPINGCARTPROJECT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
