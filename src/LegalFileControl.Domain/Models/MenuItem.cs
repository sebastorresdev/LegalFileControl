namespace LegalFileControl.Domain.Models;

public partial class MenuItem
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public string? Icon { get; set; }

    public string? RouterLink { get; set; }

    public int? ParentId { get; set; }

    public virtual ICollection<MenuItem> InverseParent { get; set; } = new List<MenuItem>();

    public virtual MenuItem? Parent { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
