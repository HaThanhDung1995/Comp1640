using System.Web.Mvc;
using ProjectEWS.Interface;
using ProjectEWS.Service;
using Unity;
using Unity.Mvc5;

namespace ProjectEWS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IMasterService, MasterService>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}