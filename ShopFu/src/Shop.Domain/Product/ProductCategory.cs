using Shop.Domain.Catalog;

namespace Shop.Domain.Product;

public class ProductCategory : BaseEntity
{
    public Product Product { get; set; }
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the category identifier
    /// </summary>
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is featured
    /// </summary>
    public bool IsFeaturedProduct { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}