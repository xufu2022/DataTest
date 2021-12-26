using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Net5Features.Relationship.ReDomain
{
    public class BookSummary
    {
        public int BookSummaryId { get; set; }

        public string Title { get; set; }

        public string AuthorsString { get; set; }

        public BookDetail Details { get; set; }
    }

    public class BookDetail
    {
        public int BookDetailId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderInfo //#A
    {
        public int OrderInfoId { get; set; }
        public string OrderNumber { get; set; }

        public Address BillingAddress { get; set; } //#B
        public Address DeliveryAddress { get; set; } //#B
    }

    [Owned]                                         //#C
    public class Address                            //#D
    {
        public string NumberAndStreet { get; set; }
        public string City { get; set; }
        public string ZipPostCode { get; set; }
        [Required]                                  //#E
        [MaxLength(2)]                              //#E
        public string CountryCodeIso2 { get; set; } //#E
    }

    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public Address HomeAddress { get; set; }
    }
}
