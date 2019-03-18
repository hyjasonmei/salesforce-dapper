using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SforceDapper.Models
{
    public class SforceQueryResult<T>
    {
        public int totalSize { get; set; }
        public bool done { get; set; }
        public string nextRecordsUrl { get; set; }
        public List<T> records { get; set; }
    }
}
