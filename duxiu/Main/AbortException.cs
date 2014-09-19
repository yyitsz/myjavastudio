﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mouse.Main
{
    [global::System.Serializable]
    public class AbortException : Exception
    {
        public AbortException() { }
        public AbortException(string message) : base(message) { }
        public AbortException(string message, Exception inner) : base(message, inner) { }
        protected AbortException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
