using Shop.ApplicationCore.Entities;

namespace Shop.Domain.Media;

public class Picture : BaseEntity
{
    public string? MimeType { get; set; }
    public string? SeoFilename { get; set; }
    public string? AltAttribute { get; set; }
    public string? TitleAttribute { get; set; }
    public bool IsNew { get; set; }
    public string VirtualPath { get; set; } = null!;
}