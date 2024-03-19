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

        private string GetPath() //Получение путя к файлу
        {
            string filePath = "";
            bool check = false;

            while (!check)
            {
                Console.WriteLine("Введите путь к .json файлу:");
                filePath = Console.ReadLine();
                check = File.Exists(filePath);
            }

            return filePath;
        }

        public IDeviceInfoArray Read()
        {
            string filePath = GetPath();
            string json = File.ReadAllText(filePath);

            IDeviceInfoArray deviceInfoArray = new DeviceInfoArray(Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceInfoSchema[]>(json));

            return deviceInfoArray;
        }
    }
}
