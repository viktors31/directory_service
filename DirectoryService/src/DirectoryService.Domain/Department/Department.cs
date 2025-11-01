using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department;

public class Department : Entity<DepartmentId>
{
    public DepartmentName Name { get; private set; } // Название подразделения

    public DepartmentIdentifier Identifier { get; private set; } // Краткое название на латинице

    public DepartmentPath Path { get; private set; } // Денормалилизрованный путь. Типа sales.it.dev-team

    public short Depth { get; private set;  } // Глубина подразделения в иерархии

    public bool IsActive { get; private set; } // For soft delete

    public DateTime CreatedAt { get; private set; } // Дата создания. UTC

    public DateTime UpdatedAt { get; private set; } // Дата последнего изменения. UTC

    // Связь с департаментами (иерархия, дерево)
    public DepartmentId? ParentId { get; private set; } // Id на родительское подразделение. FK -> Dep.Id, null - корень

    public Department? Parent { get; private set; } // Родительское подразделение. Навигационное (родитель)

    // связь с локациями (many - many, промежуточная сущность DepatmentLocation)
    private List<DepartmentLocation> _locations = [];

    public IReadOnlyList<DepartmentLocation> Locations => _locations.AsReadOnly();

    // Связь с позициями (many - many, промежуточная сущность DepartmentPosition)
    private List<DepartmentPosition> _positions = [];

    public IReadOnlyList<DepartmentPosition> Positions => _positions.AsReadOnly();

    private Department(
        DepartmentId id,
        DepartmentName name,
        DepartmentIdentifier identifier,
        DepartmentId? parentId,
        DepartmentPath path,
        short depth)
    {
        Id = id;
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    #pragma warning disable CS8618 // чтобы не ругался на пустой конструктор
    private Department() { } // for ef core

    public static Result<Department, string> Create(
        DepartmentName name,
        DepartmentIdentifier identifier,
        Department? parent = null,
        DepartmentId? id = null)
    {
        DepartmentId? parentId;
        DepartmentPath path;
        short depth;
        if (parent is null)
        {
            path = DepartmentPath.CreateRoot(identifier);
            depth = 0;
            parentId = null;
        }
        else
        {
            path = parent.Path.CreateChild(identifier);
            depth = (short)(parent.Depth + 1);
            parentId = parent.Id;
        }

        return new Department(
            id ?? DepartmentId.NewId(),
            name,
            identifier,
            parentId,
            path,
            depth);
    }
}