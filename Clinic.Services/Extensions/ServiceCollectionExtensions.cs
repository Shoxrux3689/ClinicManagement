using System.Text.Json.Serialization;
using AutoMapper;
using Clinic.Services.AutoMapper;
using Clinic.Services.Repositories.Generic;
using Clinic.Services.Repositories.JwtConfiguration;
using Clinic.Services.Repositories.OrganizationRepository;
using Clinic.Services.Repositories.PatientRepositories;
using Clinic.Services.Repositories.TreatmentRepositories;
using Clinic.Services.Repositories.VisitRepositories;
using Clinic.ViewModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Clinic.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddExtensions(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<ITreatmentRepository, TreatmentRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.Configure<JwtOption>(configuration.GetSection("JwtBearer"));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var signingKey = System.Text.Encoding.UTF32.GetBytes(configuration["JwtBearer:SigningKey"]!);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["JwtBearer:ValidIssuer"],
                    ValidAudience = configuration["JwtBearer:ValidAudience"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
    
    }
}