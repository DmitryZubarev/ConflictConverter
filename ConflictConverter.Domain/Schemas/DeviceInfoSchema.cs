using ConflictConverter.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.schemas
{
    public class DeviceInfoSchema
    {
        [Newtonsoft.Json.JsonProperty("device")]
        public DeviceSchema? Device {  get; set; }

        [Newtonsoft.Json.JsonProperty("brigade")]
        public BrigadeSchema Brigade { get; set; }
    }
}
