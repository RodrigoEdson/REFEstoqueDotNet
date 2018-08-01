
namespace REFEstoqueDotNetV3.exceptions
{
    public class InvalidPropertyValueException : System.Exception
    {
        public InvalidPropertyValueException() : base() { }
        public InvalidPropertyValueException(string message) : base(message) { }
        public InvalidPropertyValueException(string message, System.Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client. 
        protected InvalidPropertyValueException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
    }
}
