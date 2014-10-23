using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCrm.Utils
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DisplayAttribute : Attribute
    {
        readonly string text;

        // This is a positional argument
        public DisplayAttribute(string text)
        {
            this.text = text;
        }

        public string Text
        {
            get { return text; }
        }

    }
}
