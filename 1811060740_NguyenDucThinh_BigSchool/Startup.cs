using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1811060740_NguyenDucThinh_BigSchool.Startup))]

namespace _1811060740_NguyenDucThinh_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}