using InDepth.Relationship.ReDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InDepth.Relationship.Configurations
{
    public class OrderInfoConfig : IEntityTypeConfiguration<OrderInfo>
    {
        public void Configure
            (EntityTypeBuilder<OrderInfo> entity)
        {
            entity
                .OwnsOne(p => p.BillingAddress);
            entity
                .OwnsOne(p => p.DeliveryAddress);
        }

        /*******************************************************************
         * ********************************************************************/
    }
}
