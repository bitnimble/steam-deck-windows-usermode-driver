using SWICD.Services;
using SWICD.Config;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using SWICD.HVDK;

namespace SWICD.Model
{
    internal class AxisKeyboardMappingModel
    {
        private EnumComboBoxItem<string> _selectedPositiveKey;
        private EnumComboBoxItem<string> _selectedNegativeKey;

        public ObservableCollection<EnumComboBoxItem<string>> KeyboardItems { get; set; } = new ObservableCollection<EnumComboBoxItem<string>>(new string[] { "NONE" }.Concat(new KeyboardUtils().GetAvailableKeysWithModifiers).Select(e => new EnumComboBoxItem<string>()
        {
            Value = e,
            Display = FontEnumMapper.MapEmulatedKeyboardKeyToFont(e),
        }));

        public string AxisText => Regex.Replace(FontEnumMapper.MapHardwareAxisToFont(HardwareAxis), "([^A-Z])([A-Z])", "$1 $2");
        public HardwareAxis HardwareAxis { get; set; }

        public EnumComboBoxItem<string> SelectedPositiveKey
        {
            get => _selectedPositiveKey;
            set
            {
                _selectedPositiveKey = value;
                if (SetPositiveKeyAction != null)
                    SetPositiveKeyAction(value.Value);
            }
        }

        public EnumComboBoxItem<string> SelectedNegativeKey
        {
            get => _selectedNegativeKey;
            set
            {
                _selectedNegativeKey = value;
                if (SetNegativeKeyAction != null)
                    SetNegativeKeyAction(value.Value);
            }
        }

        public Action<string> SetPositiveKeyAction { get; set; }
        public Action<string> SetNegativeKeyAction { get; set; }

        public string PositiveKey
        {
            get => SelectedPositiveKey.Value;
            set
            {
                SelectedPositiveKey = new EnumComboBoxItem<string>()
                {
                    Value = value,
                    Display = FontEnumMapper.MapEmulatedKeyboardKeyToFont(value),
                };
            }
        }

        public string NegativeKey
        {
            get => SelectedNegativeKey.Value;
            set
            {
                SelectedNegativeKey = new EnumComboBoxItem<string>()
                {
                    Value = value,
                    Display = FontEnumMapper.MapEmulatedKeyboardKeyToFont(value),
                };
            }
        }
    }
}
