using RWT.Domain.Clients;
using RWT.Domain.Models.Common;

namespace RWT.Domain.User;

public class TimeEntry : Entity {
    public Guid Id { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public decimal Hours { get; set; }
    public string Description { get; set; } = null!;

    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid? TodoId { get; set; }
    public Todo? Todo { get; set; } = null!;

    public const int DescriptionMaxLength = 1000;
}
