﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SforceDapper.Models
{
    class SforceSession
    {
        public string instance_url { get; set; }
        public string access_token { get; set; }
        public DateTime issue_date { get; set; }
        public string username { get; set; }
    }
}
