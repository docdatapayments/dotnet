using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    /// <summary>
    /// Runtime exception
    /// </summary>
    public class RuntimeException : System.Exception
    {
        public string messsage { get; set; }
        public Exception cause { get; set; }

        public RuntimeException()
        {
        }

        public RuntimeException(string message)
        {
            this.messsage = message;
        }

        public RuntimeException(Exception exception)
        {
            this.messsage = exception.Message;
            this.cause = exception;
        }

        /// <summary>
        /// Constructor needed for serialization when exception propagates from a remoting server to the client.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected RuntimeException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
        }
    }
}
