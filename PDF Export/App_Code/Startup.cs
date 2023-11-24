using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PDF_Export.Startup))]
namespace PDF_Export
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
