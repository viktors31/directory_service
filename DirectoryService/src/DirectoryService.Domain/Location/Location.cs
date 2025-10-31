using CSharpFunctionalExtensions;
using DirectoryService.Domain.Location;

namespace DirectoryService.Domain.Entities;

public class Location : Entity<LocationId>
{
    public string Name { get; private set; } // UNIQUE 3-120

    public Address Address { get; private set; } // неск. столбцов/jsonb

    public IANA_TimeZone Timezone { get; private set; } // IANA_TimeZone code

    public bool IsActive { get; private set; } // for soft delete

    public DateTime CreatedAt { get; private set; } // utc

    public DateTime UpdatedAt { get; private set; } // utc

    public Location(
        string name,
        Address address,
        IANA_TimeZone timezone)
    {
        Id = LocationId.NewId();
        Name = name;
        Address = address;
        Timezone = timezone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    #pragma warning disable CS8618 // чтобы не ругался на пустой конструктор
    private Location() { } // for ef core
}