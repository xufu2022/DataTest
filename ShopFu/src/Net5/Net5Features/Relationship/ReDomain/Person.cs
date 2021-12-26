using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Features.Relationship.ReDomain
{
    public class Person
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        [MaxLength(256)]
        [Required]
        public string Email { get; set; } //#A

        //------------------------------
        //relationships

        public ContactInfo ContactInfo { get; set; }

        [InverseProperty(nameof(LibraryBook.Librarian))]   //#A
        public IList<LibraryBook>
            LibrarianBooks
        { get; set; }

        [InverseProperty(nameof(LibraryBook.OnLoanTo))]    //#B
        public IList<LibraryBook>
            BooksBorrowedByMe
        { get; set; }
    }

    public class ContactInfo
    {
        public int ContactInfoId { get; set; }

        public string MobileNumber { get; set; }
        public string LandlineNumber { get; set; }

        [MaxLength(256)]
        [Required]
        public string EmailAddress { get; set; } //#A
    }

    public class LibraryBook
    {
        public int LibraryBookId { get; set; }

        public string Title { get; set; }

        //-----------------------------------
        //Relationships

        [MaxLength(256)]
        [Required]
        public int LibrarianUserId { get; set; }

        public Person Librarian { get; set; }

        public int? OnLoanToPersonId { get; set; }
        public Person OnLoanTo { get; set; }
    }
}
