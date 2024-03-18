using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class Device : IDevice
    {
        private string _serialNumber;
        private bool _isOnline;

        public string SerialNumber 
        {
            get
            {
                return _serialNumber;
            }
            private set 
            {
                if (value == null) { _serialNumber = "null"; }
                else { _serialNumber = value; }
            }
        }

        public bool IsOnline
        {
            get
            {
                return _isOnline;
            }
            private set
            {
                _isOnline = value; 
            }
        }

        public Device()
        {
            SerialNumber = null;
            IsOnline = false; ;
        }

        public Device(DeviceSchema? schema)
        {
            SerialNumber = schema.SerialNumber;
            IsOnline = (bool)schema.IsOnline;
        }

        public string ToFormattedString()
        {
            return $"SerialNumber - {SerialNumber}, IsOnline - {IsOnline} \n";
        }
    }
}
