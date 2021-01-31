using System;
using System.Runtime.Serialization;

namespace DietaApp.Controllers
{
    [Serializable]
    internal class NullReferenceExeption : Exception
    {
        public NullReferenceExeption()
        {
        }

        public NullReferenceExeption(string message) : base(message)
        {
        }

        public NullReferenceExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullReferenceExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}