using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Entities;

public class Position : Entity<PositionId>
{
    public PositionName Name { get; private set; } // UNIQUE, 3-100

    public string? Description { get; private set; } // <= 1000

    public bool IsActive { get; private set; } // for soft delete

    public DateTime CreatedAt { get; private set; } // utc

    public DateTime UpdatedAt { get; private set; } // utc

    public Position(
        PositionName name,
        string description)
    {
        Id = PositionId.NewId();
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    #pragma warning disable CS8618 // чтобы не ругался на пустой конструктор
    private Position() { } // for ef core
}