using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MunicipalTrashCollection.Startup))]
namespace MunicipalTrashCollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
