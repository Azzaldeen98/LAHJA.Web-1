using Shared.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.Inputs
{
    public class InvalidPasswordException: BaseExceptionApp , IExceptionApp
    {
        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string message) : base(message) { }

        public InvalidPasswordException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public InvalidPasswordException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public InvalidPasswordException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }
}
