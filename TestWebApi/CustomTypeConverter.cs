using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace TestWebApi
{
    [TypeConverter(typeof(InspectionConverter))]
    public class Inspection
    {
        public List<int> Ids { get; set; }
    }

    class InspectionConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                Inspection point;
                if (TryParse((string)value, out point))
                {
                    return point;
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static bool TryParse(string s, out Inspection result)
        {
            result = null;

            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            var parts = s.Split(',');
            List<int> list = new List<int>();
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int value))
                {
                    list.Add(value);
                }
            }

            if (list.Count > 0)
            {
                result = new Inspection { Ids = list };
                return true;
            }

            return false;
        }
    }
}
