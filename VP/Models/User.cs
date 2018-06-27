using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VP.Models
{
    public class User
    {
        public long Id { get; set; }
        public string email { get; set; }
        public bool password { get; set; }
    }

}