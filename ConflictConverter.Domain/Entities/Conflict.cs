using ConflictConverter.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class Conflict : IConflict
    {
        public IBrigade Brigade { get; init; }
        public IDevice[] Devices { get; init; }

        public Conflict(IBrigade brigade, IDevice[] devices)
        {
            Brigade = brigade;
            Devices = devices;
        }

        public string ToFormattedString()
        {
            string answer = $"brigade : {Brigade.ToFormattedString()}; \n [ \n";
            foreach (var device in Devices)
            {
                answer += $"{device.ToFormattedString}, \n";
            }
            answer += "]";

            return answer;
        }
    }
}
