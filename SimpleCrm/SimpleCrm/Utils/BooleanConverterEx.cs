using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace SimpleCrm.Utils
{
    /// <summary>
    /// Converter for Boolean type. It supports Chinese and Yes/NO and Y/N
    /// </summary>
    public class BooleanConverterEx : BooleanConverter
    {
        /// <summary>
        /// Converts the given value object to a Boolean object.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/> that specifies the culture to which to convert.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted <paramref name="value"/>.
        /// </returns>
        /// <exception cref="T:System.FormatException">
        /// 	<paramref name="value"/> is not a valid value for the target type.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {

            if (value.ToString() == "Õæ" || value.ToString() == "ÊÇ" || value.ToString().ToUpper() == "YES" || value.ToString().ToUpper() == "Y")
            {
                value = "true";
            }
            else if (value.ToString() == "¼Ù" || value.ToString() == "·ñ" || value.ToString().ToUpper() == "NO" || value.ToString().ToUpper() == "N")
            {
                value = "false";
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Returns whether the given value object is valid for this type and for the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to test for validity.</param>
        /// <returns>
        /// true if the specified value is valid for this object; otherwise, false.
        /// </returns>
        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            if (value.ToString() == "Õæ" || value.ToString().ToUpper() == "YES" ||
                value.ToString().ToUpper() == "Y" || value.ToString() == "¼Ù" ||
                value.ToString().ToUpper() == "NO" || value.ToString().ToUpper() == "N")
            {
                return true;
            }
            else
            {
                return base.IsValid(context, value);
            }
        }

    }
}
