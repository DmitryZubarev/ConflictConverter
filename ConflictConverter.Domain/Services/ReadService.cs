using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.Entities;
using ConflictConverter.Domain.Enums;
using ConflictConverter.Domain.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Services
{
    public class ReadService : IDomainService
    {
        private IJsonReader _jsonReader;

        public ReadService() 
        {
            _jsonReader = new LocalJsonReader();
        }

        public IDeviceInfoArray ReadData(TypesToReadEnum typeToRead)
        {
            switch (typeToRead)
            {
                case TypesToReadEnum.FromLocalJson:
                    IDeviceInfoArray data = _jsonReader.Read();
                    return data;

                default:
                    return null;
            }
        }
    }
}
