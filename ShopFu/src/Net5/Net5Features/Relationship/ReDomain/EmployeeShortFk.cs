using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Features.Relationship.ReDomain
{
    public class EmployeeShortFk
    {
        public int EmployeeShortFkId { get; set; }

        public string Name { get; set; }

        //------------------------------
        //Relationships

        public int? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]      //#A
        public EmployeeShortFk Manager { get; set; }
    }
}
