using Shop.Domain.Catalog;

namespace Shop.Domain.Product;

public class Product : BaseEntity, ILocalizedEntity
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public string AdminComment { get; set; }
    public bool ShowOnHomepage { get; set; }
    public string MetaKeywords { get; set; }
    public string MetaDescription { get; set; }
    public bool AllowCustomerReviews { get; set; }
    public bool IsFreeShipping { get; set; }
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the length
    /// </summary>
    public decimal Length { get; set; }

    /// <summary>
    /// Gets or sets the width
    /// </summary>
    public decimal Width { get; set; }

    /// <summary>
    /// Gets or sets the height
    /// </summary>
    public decimal Height { get; set; }

    public DateTime? AvailableStartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the available end date and time
    /// </summary>
    public DateTime? AvailableEndDateTimeUtc { get; set; }

    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time of product update
    /// </summary>
    public DateTime UpdatedOnUtc { get; set; }


}