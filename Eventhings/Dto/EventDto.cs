﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventhings.Dto
{
    public class EventDto
    {
        public string name { get; set; }

        public string description { get; set; }

        public string location { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public int? duration { get; set; } = 1;

        public int host_id { get; set; }

        public int active { get; set; } = 1;

        public int deleted { get; set; } = 0;
    }
}