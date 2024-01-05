using RWT.Domain.Models.Common;

namespace RWT.Domain.Clients;

public class Todo : Entity {
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public int Days { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }    
    public DateTimeOffset? CompletedAt { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;


    public const int TitleMaxLength = 250;
    public const int DescriptionMaxLength = 1000;
}
