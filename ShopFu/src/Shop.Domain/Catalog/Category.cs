using Shop.Domain.Product;

namespace Shop.Domain.Catalog;

public class Category : BaseEntity, ILocalizedEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Category? Parent { get; set; }
    public int? ParentCategoryId { get; set; }

    public int PictureId { get; set; }

    public int PageSize { get; set; }

    public bool ShowOnHomepage { get; set; }

    public bool IncludeInTopMenu { get; set; }

    public bool Published { get; set; }

    public bool Deleted { get; set; }

    public int DisplayOrder { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaTitle { get; set; }

    // experiment with many to many 
    public ICollection<Product.Product> Products { get; set; }
    public List<ProductCategory> ProductCategories { get; set; }
}