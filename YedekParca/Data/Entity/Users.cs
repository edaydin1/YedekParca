﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
