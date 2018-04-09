using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodTruckPlus.Startup))]
namespace FoodTruckPlus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
