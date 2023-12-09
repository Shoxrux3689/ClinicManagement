using Clinic.Domain.Entities;
using Clinic.Domain.Enums;
using Clinic.Services.Pagination;

namespace Clinic.Services.Filters;

public class PatientFilter : PaginationParams
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public Gender? Gender { get; set; }
    public int? OrganizationId { get; set; }
    public DateTime? CreatedDate { get; set; }

    
}