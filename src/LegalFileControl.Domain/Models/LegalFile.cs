namespace LegalFileControl.Domain.Models;

public partial class LegalFile
{
    public int Id { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string Period { get; set; } = null!;

    public int LegalFileStatusId { get; set; }

    public DateTime? ValidationDate { get; set; }

    public string? RejectionReason { get; set; }

    public int Wocount { get; set; }

    public virtual ICollection<ChargeLegalFile> ChargeLegalFiles { get; set; } = new List<ChargeLegalFile>();

    public virtual LegalFileStatus LegalFileStatus { get; set; } = null!;
}
