using Unity;
using Unity.Lifetime;

namespace BowlingBall.DependencyInjection
{
    public static class DependencyInjector
    {
        private static readonly UnityContainer UnityContainer = new UnityContainer();

        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }

        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}
