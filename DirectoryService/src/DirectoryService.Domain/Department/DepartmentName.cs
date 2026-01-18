using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department;

public class DepartmentName : ValueObject
{
    public string Value { get; }

    private DepartmentName(string name)
    {
        Value = name;
    }

    public static Result<DepartmentName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < Constants.Constants.DepartmentName_MINLENGTH || name.Length > Constants.Constants.DepartmentName_MAXLENGTH)
            return Result.Failure<DepartmentName>("Name is not valid");
        return Result.Success(new DepartmentName(name));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}