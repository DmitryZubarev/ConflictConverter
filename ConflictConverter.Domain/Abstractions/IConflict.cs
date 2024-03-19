﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Abstractions
{
    public interface IConflict : IData
    {
        IBrigade Brigade { get; }
        IDevice[] Devices {  get; }
    }
}
