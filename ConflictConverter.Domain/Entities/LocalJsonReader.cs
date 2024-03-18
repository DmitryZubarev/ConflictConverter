using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class LocalJsonReader : IJsonReader
    {
        public LocalJsonReader() { }

        public IDeviceInfoArray Read()
        {
            Console.WriteLine("Введите путь к .json файлу:");
            string filePath = Console.ReadLine();
            string json = File.ReadAllText(filePath);

            IDeviceInfoArray deviceInfoArray = new DeviceInfoArray(Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceInfoSchema[]>(json));

            return deviceInfoArray;
        }
    }
}
