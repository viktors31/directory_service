using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.ValueObjects;

public class DepartmentIdentifier : ValueObject
{
    public string Value { get; }

    private DepartmentIdentifier(string identifier)
    {
        Value = identifier;
    }

    public static Result<DepartmentIdentifier> Create(string identifier)
    {
        // Проверка на null оставлена, с || будет ленивое вычисление, если null первый вернет true, вызова RegExp с null не будет
        if (string.IsNullOrWhiteSpace(identifier) || Regex.IsMatch(identifier, $"^[a-zA-Z]{{{Constants.Constants.DepartmentIdentifier_MINLENGTH},{Constants.Constants.DepartmentIdentifier_MAXLENGTH}}}$" ))
            return Result.Failure<DepartmentIdentifier>("Identifier is not valid");
        return Result.Success(new DepartmentIdentifier(identifier));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}