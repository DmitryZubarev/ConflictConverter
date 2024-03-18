using ConflictConverter.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.schemas
{
    [Newtonsoft.Json.JsonObject("brigade")]
    public class BrigadeSchema
    {
        [Newtonsoft.Json.JsonProperty("code")]
        public string? Code { get; set; }
    }
}
