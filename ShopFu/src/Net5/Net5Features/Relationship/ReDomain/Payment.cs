using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Features.Relationship.ReDomain
{
    public enum PTypes : byte { Cash = 1, Card = 2 }
    public abstract class Payment
    {
        public int PaymentId { get; set; }

        public PTypes PType { get; set; }

        public decimal Amount { get; set; }
    }

    public class PaymentCash : Payment
    { }

    public class PaymentCard : Payment
    {
        public string ReceiptCode { get; set; }
    }
}
