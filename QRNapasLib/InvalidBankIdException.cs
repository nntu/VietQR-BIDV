using System;
using System.Runtime.Serialization;

namespace QRNapasLib
{
    [Serializable]
    internal class InvalidBankIdException : Exception
    {
        public InvalidBankIdException()
        {
        }

        public InvalidBankIdException(string message) : base(message)
        {
        }

        public InvalidBankIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBankIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}