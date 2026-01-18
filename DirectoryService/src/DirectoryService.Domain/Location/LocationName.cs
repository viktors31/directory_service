using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.ValueObjects;

public class LocationName : ValueObject
{
    public string Value { get; }

    private LocationName(string name)
    {
        Value = name;
    }

    public static Result<LocationName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < Constants.Constants.LocationName_MINLENGTH || name.Length > Constants.Constants.LocationName_MAXLENGTH)
            return Result.Failure<LocationName>("Name is not valid");
        return Result.Success(new LocationName(name));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}