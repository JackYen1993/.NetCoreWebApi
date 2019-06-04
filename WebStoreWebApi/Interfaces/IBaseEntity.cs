using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreWebApi.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime LastUpdated { get; set; }
    }
}
