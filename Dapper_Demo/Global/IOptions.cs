using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Demo.Global
{
    public interface IOptions<out TOptions> where TOptions : class, new()
    {
        //
        // Summary:
        //     The default configured TOptions instance, equivalent to Get(string.Empty).
        TOptions Value { get; }
    }
}
