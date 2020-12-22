
using HQPosData.Models;
using HQService;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace newHQ
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<HQEntities>(new TransientLifetimeManager());
            container.AddNewExtension<HQServiceUnityExtension>();
            //container.AddNewExtension<FakeHQServiceUnityExtension>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}