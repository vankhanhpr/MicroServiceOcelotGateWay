﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.area.auth
{
    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }
}
