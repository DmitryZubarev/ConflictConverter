using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Abstractions
{
    public interface IConflict : IData
    {
        string? BrigadeCode { get; }
        string[]? DevicesSerials {  get; }
    }
}
