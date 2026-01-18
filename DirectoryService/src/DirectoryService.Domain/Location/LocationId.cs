using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Entities;

public class LocationId : ComparableValueObject
{
    public Guid Value { get; }

    private LocationId(Guid value)
    {
        Value = value;
    }

    public static LocationId NewId() => new LocationId(Guid.NewGuid());

    public static Result<LocationId> Create(Guid value)
    {
        if (value == Guid.Empty)
            return Result.Failure<LocationId>("Empty PositionId");
        return Result.Success(new LocationId(value));
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}