using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class DeviceInfoArray : IDeviceInfoArray
    {
        public IDeviceInfo[] Data { get; init; }

        public DeviceInfoArray(DeviceInfoSchema[] deviceInfoSchemaArray) 
        {
            int length = deviceInfoSchemaArray.Length;
            IDeviceInfo[] array = new DeviceInfo[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = new DeviceInfo(deviceInfoSchemaArray[i]);
            }

            Data = array;
        }

        public string ToFormattedString()
        {
            string answer = "Array: \n";
            foreach (var item in Data)
            {
                answer += item.ToFormattedString();
            }
            return answer;
        }
    }
}
