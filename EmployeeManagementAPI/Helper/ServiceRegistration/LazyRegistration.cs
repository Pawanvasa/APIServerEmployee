using EmployeeManagment.Services.LazyLoading;

namespace EmployeeManagement.Api.Helper.ServiceRegistration
{
    public static class LazyRegistration
    {
        public static IServiceCollection AllowLazyInitialization(this IServiceCollection services)
        {
            var lastRegistration = services.Last();

            var lazyServiceType = typeof(Lazy<>).MakeGenericType(
                lastRegistration.ServiceType);

            var lazyServiceImplementationType = typeof(LazyService<>).MakeGenericType(
                lastRegistration.ServiceType);

            services.Add(new ServiceDescriptor(lazyServiceType, lazyServiceImplementationType, lastRegistration.Lifetime));
            return services;
        }
    }
}
