using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department;

public class DepartmentId : ComparableValueObject
{
    public Guid Value { get; }

    private DepartmentId(Guid value)
    {
        Value = value;
    }

    public static DepartmentId NewId() => new DepartmentId(Guid.NewGuid());

    public static Result<DepartmentId> Create(Guid value)
    {
        if (value == Guid.Empty)
            return Result.Failure<DepartmentId>("Empty PositionId");
        return Result.Success(new DepartmentId(value));
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}