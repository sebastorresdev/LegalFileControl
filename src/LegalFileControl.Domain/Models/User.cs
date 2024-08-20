namespace LegalFileControl.Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Charge> Charges { get; set; } = new List<Charge>();

    public virtual Role Role { get; set; } = null!;
}
