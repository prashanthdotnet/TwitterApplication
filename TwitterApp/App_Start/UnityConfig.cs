using System;
using System.Web.Mvc;
using TwitterApp.BLL;
using TwitterApp.Controllers;
using Unity;
using Unity.Lifetime;

namespace TwitterApp
{
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container =
            new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ITwitterBO, TwitterBO>();
            container.RegisterType<IController, HomeController>("Home");

            container.RegisterType<ITwitterDataBO, TwitterDataBO>();
        }

        #endregion
    }
}
