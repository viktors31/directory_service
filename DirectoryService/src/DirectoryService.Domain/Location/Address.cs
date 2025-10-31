using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Location;

public class Address : ValueObject
{
    public string Country { get; private set; }

    public string City { get; private set; }

    public string Street { get; private set; }

    public string PostalCode { get; private set; }

    public string Building { get; private set; }

    public int Room { get; private set; }

    private Address(string country, string city, string street, string postalCode, string building, int room)
    {
        Country = country;
        City = city;
        Street = street;
        PostalCode = postalCode;
        Building = building;
        Room = room;
    }

    public static Result<Address> Create(string country, string city, string street, string postalCode, string building, int room)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<Address>("Country is not valid");
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City is not valid");
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street is not valid");
        if (string.IsNullOrWhiteSpace(postalCode))
            return Result.Failure<Address>("Postal code is not valid");
        if (string.IsNullOrWhiteSpace(building))
            return Result.Failure<Address>("Building is not valid");
        if (room <= 0)
            return Result.Failure<Address>("Room is not valid");
        return Result.Success(new Address(country, city, street, postalCode, building, room));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return City;
        yield return Street;
        yield return PostalCode;
        yield return Building;
        yield return Room;
    }
}