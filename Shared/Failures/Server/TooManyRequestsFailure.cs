using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Failures.Server
{
    public class TooManyRequestsFailure: ServerFailure
    {
        public TooManyRequestsFailure(string message = "تم تجاوز الحد الأقصى للطلبات.") : base(message) { }
    }
}
