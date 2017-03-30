using DAL;
using DryIoc;
using WebAPI.src.LoginComponent;

namespace WebAPI
{
    public class Bootstrap
    {
        public Bootstrap(IRegistrator r) // If you need the whole container then change parameter type rom IRegistrator to IContainer
        {
            r.Register<IDbContextFactory, DbContextFactory>(Reuse.InWebRequest);
            r.Register<IUnitOfWork, UnitOfWork>(Reuse.InWebRequest);
            r.Register<ILoginService, LoginService>(Reuse.InWebRequest);

            // r.RegisterMany(new[] { typeof(LoginService) }, nonPublicServiceTypes: true);
        }
    }
}