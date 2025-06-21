using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Service.Response
{

    public enum ServicesType
    {
        Text2Text,
        Text2Speech,
        Speech2Speech
    }
    public class ServiceClientResponse
    {
        public string Authorization { get; set; }
        public string ContentType { get; set; }
        public string Method { get; set; }
        public string TagId { get; set; }
        public string URL { get; set; }
        public string Key { get; set; }
        public string Data { get; set; }
    }
}
