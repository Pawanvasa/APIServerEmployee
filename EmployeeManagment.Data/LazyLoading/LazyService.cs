using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagment.Services.LazyLoading
{
    public class LazyService<T> : Lazy<T> where T : class
    {
        public LazyService(IServiceScopeFactory scopeFactory)
            : base(() =>
            {
                var scope = scopeFactory.CreateScope();
                return scope.ServiceProvider.GetRequiredService<T>();
            })
        {
        }
    }
}
