using System.Text.Json.Serialization;
using AutoMapper;
using Clinic.Services.AutoMapper;
using Clinic.Services.Repositories.Generic;
using Clinic.Services.Repositories.OrganizationRepository;
using Clinic.Services.Repositories.PatientRepositories;
using Clinic.Services.Repositories.VisitRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddExtensions(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
    
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
    
}