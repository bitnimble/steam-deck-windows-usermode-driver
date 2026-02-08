using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SWICD.Config
{
    [Serializable]
    public class AxisKeyboardMapping : ICloneable, ISerializable
    {
        private Dictionary<HardwareAxis, AxisKeyboardConfig> _mappings = new Dictionary<HardwareAxis, AxisKeyboardConfig>()
        {
            { HardwareAxis.LeftStickX, new AxisKeyboardConfig() },
            { HardwareAxis.LeftStickY, new AxisKeyboardConfig() },
            { HardwareAxis.RightStickX, new AxisKeyboardConfig() },
            { HardwareAxis.RightStickY, new AxisKeyboardConfig() },
            { HardwareAxis.LeftPadX, new AxisKeyboardConfig() },
            { HardwareAxis.LeftPadY, new AxisKeyboardConfig() },
            { HardwareAxis.RightPadX, new AxisKeyboardConfig() },
            { HardwareAxis.RightPadY, new AxisKeyboardConfig() },
            { HardwareAxis.LeftPadPressure, new AxisKeyboardConfig() },
            { HardwareAxis.RightPadPressure, new AxisKeyboardConfig() },
            { HardwareAxis.L2, new AxisKeyboardConfig() },
            { HardwareAxis.R2, new AxisKeyboardConfig() },
            { HardwareAxis.GyroAccelX, new AxisKeyboardConfig() },
            { HardwareAxis.GyroAccelY, new AxisKeyboardConfig() },
            { HardwareAxis.GyroAccelZ, new AxisKeyboardConfig() },
            { HardwareAxis.GyroRoll, new AxisKeyboardConfig() },
            { HardwareAxis.GyroPitch, new AxisKeyboardConfig() },
            { HardwareAxis.GyroYaw, new AxisKeyboardConfig() },
        };

        public AxisKeyboardMapping(Dictionary<HardwareAxis, AxisKeyboardConfig> mappings)
        {
            _mappings = mappings;
        }

        public AxisKeyboardMapping()
        {
        }

        public AxisKeyboardMapping(SerializationInfo info, StreamingContext context)
        {
            var axes = _mappings.Keys.ToArray();
            foreach (var axis in axes)
            {
                _mappings[axis] = (AxisKeyboardConfig)info.GetValue(axis.ToString(), typeof(AxisKeyboardConfig));
            }
        }

        public AxisKeyboardConfig this[HardwareAxis axis]
        {
            get
            {
                if (_mappings.ContainsKey(axis))
                    return _mappings[axis];
                return new AxisKeyboardConfig();
            }
            set
            {
                _mappings[axis] = value;
            }
        }

        public object Clone()
        {
            var clone = new AxisKeyboardMapping(_mappings.ToDictionary(entry => entry.Key,
                                               entry => (AxisKeyboardConfig)entry.Value.Clone()));
            return clone;
        }

        public override bool Equals(object obj)
        {
            return obj is AxisKeyboardMapping mapping &&
                   _mappings.EqualsWithValues(mapping._mappings);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var axis in _mappings.Keys)
            {
                info.AddValue(axis.ToString(), _mappings[axis]);
            }
        }
    }
}
