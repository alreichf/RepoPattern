using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Exceptions
{
    [Serializable]
    public class EntityExistsException : Exception
    {
        public EntityExistsException()
        {

        }

        public EntityExistsException(string message) : base(message)
        {

        }

        public EntityExistsException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected EntityExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
