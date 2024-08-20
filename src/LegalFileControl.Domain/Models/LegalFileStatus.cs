namespace LegalFileControl.Domain.Models;

public partial class LegalFileStatus
{
    public int Id { get; set; }

    public string? StatusCode { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<LegalFile> LegalFiles { get; set; } = new List<LegalFile>();
}
