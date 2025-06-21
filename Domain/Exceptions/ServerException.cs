using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ApiExceptionResult
    {
        public string Title { get;  set; }
        public string Message { get;  set; }
        public string Code { get;  set; }
        


    }
    public class ServerException:Exception
    {
            
        public int StatusCode { get; private set; }

        public string Response { get; private set; }


        public ServerException(string message, int StatusCode) : base(message)
        {

            this.StatusCode = StatusCode; 
        }    
        
        public ServerException(string message, int StatusCode, string Response): this(message, StatusCode)
        { 
            
            this.Response = Response;
        
        }
    }
}
