using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Validation
{
    public static class ValidationInstaller
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.Scan(x => x.FromAssemblyOf<IValidationHandler>()
                .AddClasses(classes => classes.AssignableTo<IValidationHandler>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }
    }
}
