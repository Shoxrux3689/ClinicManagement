using AutoMapper;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.ViewModel.Models;

namespace Clinic.Services.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<PatientDto, PatientModel>().ReverseMap();
        CreateMap<PatientModel, Patient>().ReverseMap();
    }
    
}