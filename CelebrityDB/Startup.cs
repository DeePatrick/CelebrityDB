using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CelebrityDB.Startup))]
namespace CelebrityDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
