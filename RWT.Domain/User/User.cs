using RWT.Domain.Models.Common;

namespace RWT.Domain.User {
    public class User: Entity {
        public Guid Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public List<TimeEntry> TimeEntries { get; set; } = new();
        
        public const int NameMaxLength = 250;
        public const int EmailMaxLength = 250;
    }
}