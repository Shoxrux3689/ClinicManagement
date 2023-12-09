using Clinic.Services.Repositories.Generic;

namespace Clinic.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddExtensions(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
    }
}