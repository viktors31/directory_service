using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

public class PositionName : ValueObject
{
    public string Value { get; }

    private PositionName(string name)
    {
        Value = name;
    }

    public static Result<PositionName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < Constants.PositionName_MINLENGTH || name.Length > Constants.PositionName_MAXLENGTH)
            return Result.Failure<PositionName>("Name is not valid");
        return Result.Success(new PositionName(name));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}