namespace LegalFileControl.Domain.Models;

public partial class ChargeLegalFile
{
    public int Id { get; set; }

    public int ChargeId { get; set; }

    public int LegalFileId { get; set; }

    public virtual Charge Charge { get; set; } = null!;

    public virtual LegalFile LegalFile { get; set; } = null!;
}
