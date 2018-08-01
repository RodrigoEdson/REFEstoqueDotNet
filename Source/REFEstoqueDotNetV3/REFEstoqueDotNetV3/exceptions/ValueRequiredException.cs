using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REFEstoqueDotNetV3.exceptions
{
    class ValueRequiredException : System.Exception
    {
        public ValueRequiredException() : base() { }
        public ValueRequiredException(string message) : base(message) { }
        public ValueRequiredException(string message, System.Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client. 
        protected ValueRequiredException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
    }
}
