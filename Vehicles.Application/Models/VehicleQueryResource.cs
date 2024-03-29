﻿namespace Vehicles.Application.Models;

public class VehicleQueryResource
{
    public int? MakeId { get; set; }
    public string SortBy { get; set; }
    public bool IsSortAscending { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}