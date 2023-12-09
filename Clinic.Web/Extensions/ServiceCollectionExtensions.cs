using System.Text.Json.Serialization;
using AutoMapper;
using Clinic.Services.AutoMapper;
using Clinic.Services.Repositories.Generic;

namespace Clinic.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddExtensions(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        
        services.AddControllers()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
    
}