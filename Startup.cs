using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSV_Parser_Api.Startup))]
namespace CSV_Parser_Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
