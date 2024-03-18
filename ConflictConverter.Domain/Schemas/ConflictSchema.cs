using ConflictConverter.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Schemas
{
    [Newtonsoft.Json.JsonObject("Conflict")]
    public class ConflictSchema
    {
        [Newtonsoft.Json.JsonProperty("brigadeCode")]
        public string? BrigadeCode { get; set; }

        [Newtonsoft.Json.JsonProperty("devicesSerials")]
        public string[]? DevicesSerials { get; set; }

        public ConflictSchema(IConflict conflict)
        {
            BrigadeCode = conflict.BrigadeCode;
            DevicesSerials = conflict.DevicesSerials;
        }
    }
}
