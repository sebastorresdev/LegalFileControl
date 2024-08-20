namespace LegalFileControl.Domain.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int MenuItemId { get; set; }

    public virtual MenuItem MenuItem { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
