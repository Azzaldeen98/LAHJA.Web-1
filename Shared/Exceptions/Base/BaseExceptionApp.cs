using System.Security.Cryptography.X509Certificates;

namespace Shared.Exceptions.Base
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BaseExceptionApp : Exception, IExceptionApp
    {
        public List<string> Messages { get; set; } = new List<string>();
        public string ErrorCode { get; set; }


        public BaseExceptionApp() { }

        public BaseExceptionApp(string message, string errorCode = "GENERIC_ERROR")
            : base(message)
        {
            if (!string.IsNullOrEmpty(message))
                Messages.Add(message);

            ErrorCode = errorCode;
        }

        public  BaseExceptionApp(List<string> messages, string errorCode = "GENERIC_ERROR")
        {
            if (messages != null && messages.Any())
                Messages.AddRange(messages);

            ErrorCode = errorCode;
        }

        public BaseExceptionApp(string message, Exception innerException, string errorCode = "GENERIC_ERROR")
            : base(message, innerException)
        {
            if (!string.IsNullOrEmpty(message))
                Messages.Add(message);

            ErrorCode = errorCode;
        }

        public BaseExceptionApp SetMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
                Messages.Add(message);

            return this;
        }

        public BaseExceptionApp SetMessage(string message, string errorCode)
        {
            if (!string.IsNullOrEmpty(errorCode))
                ErrorCode = errorCode;

            if (!string.IsNullOrEmpty(message))
                Messages.Add(message);

            return this;
        }


    }



    //public class BaseExceptionApp2 :Exception, IExceptionApp
    //{

    //    public List<string> Messages { get; set; }= new List<string>();
    //    public string ErrorCode { get; set; }

    //    public BaseExceptionApp() { }


    //    public BaseExceptionApp(string message) 
    //    {
    //        if (!string.IsNullOrEmpty(message))
    //            Messages.Add(message);
    //    }

    //    public BaseExceptionApp(List<string> messages)
    //    {
    //        if(messages != null && messages.Any())
    //            Messages.AddRange(messages);
    //    }
    //}
}
