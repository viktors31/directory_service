using System.Runtime.InteropServices;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Entities;

namespace DirectoryService.Domain.ValueObjects;

public class DepartmentPath : ValueObject
{
    private const char _separator = '.';

    public string Value { get; }

    private DepartmentPath(string path)
    {
        Value = path;
    }

    public static DepartmentPath CreateRoot(DepartmentIdentifier identifier)
    {
        return new DepartmentPath(identifier.Value);
    }

    public DepartmentPath CreateChild(DepartmentIdentifier identifier)
    {
        return new DepartmentPath(Value + _separator + identifier.Value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}