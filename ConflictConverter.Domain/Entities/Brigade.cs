using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class Brigade : IBrigade
    {
        private string _code;

        public string Code 
        {
            get
            {
                return _code;
            }

            private set
            {
                if (value == null) { _code = "null"; }
                else { _code = value; }
            }
        }

        public Brigade()
        {
            Code = null;
        }

        public Brigade(BrigadeSchema? schema)
        {
            Code = schema.Code;
        }

        public Brigade(string code)
        {
            Code = code;
        }

        public string ToFormattedString()
        {
            return $"Code - {Code} \n";
        }

        public override bool Equals(object? obj)
        {
            IBrigade secondBrigade = obj as Brigade;
            if (secondBrigade == null) return false;

            if (secondBrigade.Code == this.Code) return true;
            else return false;
        }
    }
}
