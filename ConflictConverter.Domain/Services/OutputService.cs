using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.Entities;
using ConflictConverter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Services
{
    public class OutputService : IDomainService
    {
        IJsonWriter _jsonWriter;

        public OutputService() 
        {
            _jsonWriter = new LocalJsonWriter();
        }

        public IWriter GetWriter(TypesToWriteEnum typeToWrite)
        {
            switch(typeToWrite)
            {
                case TypesToWriteEnum.ToLocalJson:
                    return _jsonWriter;
                default:
                    return null;
            }
        }
    }
}
