﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project1.Models
{
    public class ResponseModel
    {
        public short status { get; set; }
        public object data { get; set; }
        public int total { get; set; }
        public string message { get; set; }
    }
}