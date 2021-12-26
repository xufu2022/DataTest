using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Features.Relationship.ReDomain
{
    public class DeletePrincipal
    {
        public int DeletePrincipalId { get; set; }

        public DeleteDependentDefault DependentDefault { get; set; } = null!;

        public DeleteDependentSetNull DependentSetNull { get; set; } = null!;

        public DeleteDependentRestrict DependentRestrict { get; set; } = null!;

        public DeleteDependentCascade DependentCascade { get; set; } = null!;

        public DeleteDependentClientCascade DependentClientCascade { get; set; } = null!;

        public DeleteDependentClientSetNull DependentClientSetNull { get; set; } = null!;

        public DeleteNonNullDefault DependentNonNullDefault { get; set; } = null!;
    }
    public class DeleteDependentDefault
    {
        public int Id { get; set; }

        public int? DeletePrincipalId { get; set; }
    }
    public class DeleteDependentSetNull
    {
        public int Id { get; set; }

        public int? DeletePrincipalId { get; set; }
    }
    public class DeleteDependentRestrict
    {
        public int Id { get; set; }

        public int? DeletePrincipalId { get; set; }
    }
    public class DeleteDependentCascade
    {
        public int Id { get; set; }

        public int? DeletePrincipalId { get; set; }
    }
    public class DeleteDependentClientCascade
    {
        public int Id { get; set; }

        public int? DeletePrincipalId { get; set; }
    }
    public class DeleteDependentClientSetNull
    {
        public int Id { get; set; }

        public int? DeletePrincipalId { get; set; }
    }

    /// <summary>
    /// the one require DeletePrincipalId
    /// </summary>
    public class DeleteNonNullDefault
    {
        public int Id { get; set; }

        public int DeletePrincipalId { get; set; }
    }
}
