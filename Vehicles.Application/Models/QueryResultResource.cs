namespace Vehicles.Application.Models;

public class QueryResultResource<T>
{
    public int TotalItems { get; set; }
    public IEnumerable<T> Items { get; set; }
}