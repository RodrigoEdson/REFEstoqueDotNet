using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REFEstoqueDotNetV3.exceptions
{
    public class InvalidPassworldException : System.Exception
    {
        public InvalidPassworldException() : base() { }
        public InvalidPassworldException(string message) : base(message) { }
        public InvalidPassworldException(string message, System.Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client. 
        protected InvalidPassworldException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
    }
}
