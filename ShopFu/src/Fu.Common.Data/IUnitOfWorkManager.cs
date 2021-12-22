using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Fu.Common.Data
{
    public interface IUnitOfWorkManager
    {
        [CanBeNull]
        IUnitOfWork Current { get; }
    }

    public interface IUnitOfWork {}
}
