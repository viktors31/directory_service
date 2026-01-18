using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Entities;

public class PositionId : ComparableValueObject
{
    public Guid Value { get; }

    private PositionId(Guid value)
    {
        Value = value;
    }

    public static PositionId NewId() => new PositionId(Guid.NewGuid());

    public static Result<PositionId> Create(Guid value)
    {
        if (value == Guid.Empty)
            return Result.Failure<PositionId>("Empty PositionId");
        return Result.Success(new PositionId(value));
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}