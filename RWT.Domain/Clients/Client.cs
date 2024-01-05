using RWT.Domain.Models.Common;
using RWT.Domain.User;


namespace RWT.Domain.Clients;

public class Client : Entity {
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string TaxId { get; set; } = null!;
    public string ContactName { get; set; } = null!;
    public Address Address { get; set; } = null!;

    public List<TimeEntry> TimeEntries { get; set; } = new();
    public List<Todo> Todos { get; set; } = new();

    // constatns
    public const int CodeMaxLength = 10;
    public const int NameMaxLength = 250;
    public const int TaxIdMaxLength = 100;
    public const int ContactNameMaxLength = 250;
}