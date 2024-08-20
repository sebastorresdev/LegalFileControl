namespace LegalFileControl.Domain.Models;

public partial class Charge
{
    public int Id { get; set; }

    public DateTime? ReceptionDate { get; set; }

    public int UserId { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<ChargeLegalFile> ChargeLegalFiles { get; set; } = new List<ChargeLegalFile>();

    public virtual User User { get; set; } = null!;
}
