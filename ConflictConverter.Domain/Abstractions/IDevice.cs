using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Abstractions
{
    public interface IDevice : IData
    {
        public string SerialNumber { get; }
        public bool IsOnline { get; }
    }
}
