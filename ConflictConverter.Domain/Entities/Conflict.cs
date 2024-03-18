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
        public string BrigadeCode { get; init; }
        public string[] DevicesSerials { get; init; }

        public Conflict(string brigadeCode, string[] devicesSerials)
        {
            BrigadeCode = brigadeCode;
            DevicesSerials = devicesSerials;
        }

        public string ToFormattedString()
        {
            string answer = $"brigadeCode : {BrigadeCode}; \n [ \n";
            foreach (var device in DevicesSerials)
            {
                answer += $"{device}, \n";
            }
            answer += "]";

            return answer;
        }
    }
}
