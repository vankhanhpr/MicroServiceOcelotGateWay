using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.area.user
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int role { get; set; }
    }
}
