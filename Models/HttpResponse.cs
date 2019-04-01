using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SforceDapper.Models
{
    internal class HttpResponse
    {
        public bool IsSuccess { get; set; }
        public string Body { get; set; }
    }
}
