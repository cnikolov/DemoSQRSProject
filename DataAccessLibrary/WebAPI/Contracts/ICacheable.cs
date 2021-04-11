using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Contracts
{
    public interface ICacheable
    {
        string CacheKey { get; }
    }
}
