using Microsoft.OData;
using Microsoft.OData.Edm;
using System;
using System.Globalization;

namespace ODataPrototype.Infrastructure
{
    public class CustomODataPayloadValueConverter : ODataPayloadValueConverter
    {
        public override object ConvertToPayloadValue(object value, IEdmTypeReference edmTypeReference)
        {
            //NOTE: don't use define Edm model like as .AsTimeOfDay()

            if (value is TimeSpan span)
               return span.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);

            return base.ConvertToPayloadValue(value, edmTypeReference);
        }

        public override object ConvertFromPayloadValue(object value, IEdmTypeReference edmTypeReference)
        {
            if (edmTypeReference.IsTimeOfDay() && value is TimeSpan)
                return TimeSpan.Parse((string)value, CultureInfo.InvariantCulture);

            return base.ConvertFromPayloadValue(value, edmTypeReference);
        }
    }
}
