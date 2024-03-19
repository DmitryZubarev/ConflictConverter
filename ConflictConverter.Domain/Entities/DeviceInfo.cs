using ConflictConverter.Domain.Abstractions;
using ConflictConverter.Domain.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictConverter.Domain.Entities
{
    public class DeviceInfo : IDeviceInfo
    {
        private IDevice _device;
        private IBrigade _brigade;

        public IDevice? Device
        {
            get { return _device; }
            private set
            {
                if (value == null)
                {
                    _device = new Device();
                }
                else
                {
                    _device = value;
                }
            }
        }
        public IBrigade? Brigade 
        {
            get { return _brigade; }
            private set 
            {
                if (value == null)
                {
                    _brigade = new Brigade();
                }
                else
                {
                    _brigade = value;
                }
            }
        }

        public DeviceInfo(IDevice device, IBrigade brigade)
        {
            Device = device;
            Brigade = brigade;
        }

        public DeviceInfo(DeviceInfoSchema? schema)
        {
            Device = new Device(schema.Device);
            Brigade = new Brigade(schema.Brigade);
        }

        public string ToFormattedString()
        {
            return $"Device: {Device.ToFormattedString()}; Brigade: {Brigade.ToFormattedString()} \n";
        }
    }
}
