﻿namespace ClinicManagement.Entities;

public class Visit
{
    public int Id { get; set; }
    public required DateTime VisitDate { get; set; }
    public long Price { get; set; }
    public string? Description { get; set; }
    public List<VisitProcedure>? VisitProcedures { get; set; }
}
