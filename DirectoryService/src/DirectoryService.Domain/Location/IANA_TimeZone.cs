using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Location;

public class IANA_TimeZone : ValueObject
{
    public string Value { get; }

    private IANA_TimeZone(string timezone)
    {
        Value = timezone;
    }

    public static Result<IANA_TimeZone> Create(string timezone)
    {
        if (string.IsNullOrWhiteSpace(timezone))
            return Result.Failure<IANA_TimeZone>("Значение не может быть пустым.");
        bool detectedTimeZone = TimeZoneInfo.TryFindSystemTimeZoneById(timezone, out var _);
        return detectedTimeZone ? Result.Success(new IANA_TimeZone(timezone)) : Result.Failure<IANA_TimeZone>("Временная зона не найдена.");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}