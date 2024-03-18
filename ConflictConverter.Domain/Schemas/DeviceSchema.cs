using ConflictConverter.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.schemas
{
    [Newtonsoft.Json.JsonObject("device")]
    public class DeviceSchema
    {
        [Newtonsoft.Json.JsonProperty("serialNumber")]
        public string? SerialNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("isOnline")]
        public bool? IsOnline { get; set; }
    }
}
