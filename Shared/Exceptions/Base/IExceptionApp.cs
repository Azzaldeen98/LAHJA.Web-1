using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.Base
{
    public interface IExceptionApp
    {
        List<string> Messages { get; set; }
        string ErrorCode { get; set; }

    }
}
