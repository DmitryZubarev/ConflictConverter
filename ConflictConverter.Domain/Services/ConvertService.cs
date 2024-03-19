using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Services
{
    public class ConvertService : IDomainService
    {
        public ConvertService() { }

        public IConflict[] Convert(IDeviceInfoArray deviceInfoArray)
        {
            ConflictDictionary conflictDictionary = new ConflictDictionary(deviceInfoArray);
            conflictDictionary.ClearByLength(2);
            conflictDictionary.DeleteWithoutOnline();

            return conflictDictionary.ToArray();
        }
    }
}
