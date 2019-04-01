using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SforceDapper.Models
{
    public class Response
    {
        public string id { get; set; }
        public List<Error> errors { get; set; }
        public bool success { get; set; }
    }
}
