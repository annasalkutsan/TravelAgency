﻿namespace TravelAgency.Application.DTOs;

public class PagedResultDto<T>
{
    public ICollection<T> Items { get; set; }
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}