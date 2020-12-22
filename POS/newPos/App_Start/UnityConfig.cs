using newPos.Services;
using PosData.Models;
using PosService;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace newPos
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<Entities>(new TransientLifetimeManager());
            container.RegisterType<CallBlueCardService>(new TransientLifetimeManager());
            container.AddNewExtension<PosServiceUnityExtension>();
            //container.AddNewExtension<FakePosServiceUnityExtension>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
        }
    }
}