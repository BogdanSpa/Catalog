using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.GenericResponses
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }

        public string StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public bool IsError => Errors != null && Errors.Any();

        public Response()
        {
            Errors = new List<string>();
        }
    }
}
