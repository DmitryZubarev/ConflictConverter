using ConflictConverter.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class ConflictDictionary : IData
    {
        public Dictionary<IBrigade, List<IDevice>> ConflictDict { get; set; }

        public ConflictDictionary(Dictionary<IBrigade, List<IDevice>> conflictDict) 
        {
            ConflictDict = conflictDict;
        }

        public ConflictDictionary(IDeviceInfoArray deviceInfoArray)
        {
            ConflictDict = new Dictionary<IBrigade, List<IDevice>>();

            foreach (IDeviceInfo deviceInfo in deviceInfoArray.Data)
            {
                IBrigade brigade = deviceInfo.Brigade;
                IDevice device = deviceInfo.Device;

                //добавление девайса в словарь
                this.AddDevice(brigade, device);
            }
        }

        public string ToFormattedString()
        {
            string answer = "[ \n";
            foreach (var conflict in ConflictDict)
            {
                answer += $"Brigade: {conflict.Key.Code}, \n";
                answer += "Device: { ";
                foreach (var device in conflict.Value)
                {
                    answer += $"serialNumber: {device.SerialNumber}, isOnline: {device.IsOnline}";
                }
                answer += "\n";
                answer += "}, \n";
            }
            answer += "] \n";

            return answer;
        }

        public void AddDevice(IBrigade brigade, IDevice device)
        {
            if (ConflictDict.ContainsKey(brigade))
            {
                ConflictDict[brigade].Add(device);
            }
            else
            {
                ConflictDict.Add(brigade, new List<IDevice>());
                ConflictDict[brigade].Add(device);
            }
        }

        public void DeleteWithoutOnline()
        {
            foreach (var conflict in ConflictDict)
            {
                if (!conflict.Value.Any(x => x.IsOnline == true))
                {
                    ConflictDict.Remove(conflict.Key);
                }
            }
        }

        public void ClearByLength(int minimalCount)
        {
            foreach (var conflict in ConflictDict)
            {
                if (conflict.Value.Count < minimalCount) 
                {
                    ConflictDict.Remove(conflict.Key); 
                }
            }
        }

        public IConflict[] ToArray()
        {
            int length = ConflictDict.Count();
            IConflict[] conflicts = new Conflict[length];
            int i = 0;
            foreach (var pair in ConflictDict)
            {
                Conflict conflict = new Conflict(pair.Key, pair.Value.ToArray());
                conflicts[i] = conflict;
                i++;
            }

            return conflicts;
        }
    }
}
