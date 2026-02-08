using System;
using System.Runtime.Serialization;

namespace SWICD.Config
{
    [Serializable]
    public class AxisKeyboardConfig : ICloneable, ISerializable
    {
        private string _positiveKey;
        public string PositiveKey { get => _positiveKey; set => _positiveKey = value; }

        private string _negativeKey;
        public string NegativeKey { get => _negativeKey; set => _negativeKey = value; }

        public AxisKeyboardConfig(string positiveKey, string negativeKey)
        {
            PositiveKey = positiveKey;
            NegativeKey = negativeKey;
        }

        public AxisKeyboardConfig()
        {
            PositiveKey = "NONE";
            NegativeKey = "NONE";
        }

        public AxisKeyboardConfig(SerializationInfo info, StreamingContext context)
        {
            PositiveKey = info.GetString("PositiveKey");
            NegativeKey = info.GetString("NegativeKey");
        }

        public override bool Equals(object obj)
        {
            return obj is AxisKeyboardConfig config &&
                   _positiveKey == config._positiveKey &&
                   _negativeKey == config._negativeKey;
        }

        public object Clone()
        {
            return new AxisKeyboardConfig(_positiveKey, _negativeKey);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PositiveKey", _positiveKey);
            info.AddValue("NegativeKey", _negativeKey);
        }
    }
}
