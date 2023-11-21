using GeoTaggr.Infrastructure;

namespace GeoTaggr.Web.Common
{
    public class DependencyContainer(IServiceCollection services) : IDependencyContainer
    {
        public IDependencyContainer AddScoped<T>() where T : class
        {
            services.AddScoped<T>();
            return this;
        }

        public IDependencyContainer AddScoped<TInterface, TImplementation>()
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddScoped<TInterface, TImplementation>();
            return this;
        }

        public IDependencyContainer AddSingleton<T>(T instance) where T : class
        {
            services.AddSingleton(instance);
            return this;
        }
    }
}
