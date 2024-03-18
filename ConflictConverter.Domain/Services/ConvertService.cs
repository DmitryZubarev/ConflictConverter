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
            IDeviceInfo[] diviceInfoArray = deviceInfoArray.Data; //получаем массив объектов DeviceInfo

            Dictionary<string, List<IDevice>> conflictDictionary = new Dictionary<string, List<IDevice>>(); //Создаём словарь <brigadeCode, Device[]>

            foreach (IDeviceInfo deviceInfo in diviceInfoArray)
            {
                string brigadeCode = deviceInfo.Brigade.Code;
                IDevice device = deviceInfo.Device;

                //добавление девайса в словарь
                if (conflictDictionary.ContainsKey(brigadeCode))
                {
                    conflictDictionary[brigadeCode].Add(device);
                }
                else
                {
                    List<IDevice> devices = new List<IDevice>();
                    devices.Add(device);
                    conflictDictionary.Add(brigadeCode, devices);
                }
            }

            //Создаём словарь, в который засовываем элементы из начального словаря при выполнении условий (Кол-во_девайсов > 1 && Один_из_девайсов == онлайн)
            var selectedConflicts = conflictDictionary.Where(pair => pair.Value.Count > 1 && pair.Value.Any(x => x.IsOnline == true)); 

            //На основе словаря создаём массив объектов Conflict
            int length = selectedConflicts.Count();
            IConflict[] conflicts = new Conflict[length];
            int i = 0;
            foreach (var pair in selectedConflicts)
            {
                Conflict conflict = new Conflict(pair.Key, pair.Value.Select(x => x.SerialNumber).ToArray());
                conflicts[i] = conflict;
                i++;
            }

            return conflicts;
        }
    }
}
