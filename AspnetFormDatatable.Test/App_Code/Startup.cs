using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspnetFormDatatable.Test.Startup))]
namespace AspnetFormDatatable.Test
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
